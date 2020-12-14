using FFmpeg.AutoGen;
using System.Collections.Generic;

namespace Project2C.Core {
    public unsafe class VideoHelper {
        private int frameRate;

        public VideoHelper(int _frameRate) { frameRate = _frameRate; }
        public unsafe AVStream* AddVideoStream(AVFormatContext* oc, AVCodecID codec_id) {

            AVStream* st = ffmpeg.avformat_new_stream(oc, null);
            AVCodec* codec = null;
            if (st == null) {
                System.Console.WriteLine("Could not alloc stream\n");
                return null;
            }
            codec = ffmpeg.avcodec_find_encoder(codec_id);//查找mjpeg解码器  
            if (codec == null) {
                System.Console.WriteLine("codec not found\n");
                return null;
            }
            ffmpeg.avcodec_get_context_defaults3(st->codec, codec);//申请AVStream->codec(AVCodecContext对象)空间并设置默认值(由avcodec_get_context_defaults3()设置  

            st->codec->bit_rate = 400000;//设置采样参数，即比特率    
            st->codec->width = 3200;//设置视频宽高，这里跟图片的宽高保存一致即可  
            st->codec->height = 2200;
            st->codec->time_base.den = frameRate;//设置帧率  
            st->codec->time_base.num = 1;
            st->codec->framerate.den = 1;
            st->codec->framerate.num = frameRate;
            st->codec->pix_fmt = AVPixelFormat.AV_PIX_FMT_YUV420P;//设置像素格式    
            st->codec->codec_tag = 0;
            if ((oc->oformat->flags & ffmpeg.AVFMT_GLOBALHEADER) == ffmpeg.AVFMT_GLOBALHEADER)//一些格式需要视频流数据头分开  
                st->codec->flags |= ffmpeg.AV_CODEC_FLAG_GLOBAL_HEADER;
            return st;
        }


        public unsafe void Convert(List<byte[]> img, string aviName) {

            AVFormatContext* ofmt_ctx = null;//其包含码流参数较多，是一个贯穿始终的数据结构，很多函数都要用到它作为参数  
            string out_filename = aviName;//输出文件路径，在这里也可以将mkv改成别的ffmpeg支持的格式，如mp4，flv，avi之类的  


            ffmpeg.av_register_all();//初始化解码器和复用器  
            //ffmpeg.avcodec_register_all();
            ffmpeg.avformat_alloc_output_context2(&ofmt_ctx, null, null, out_filename);//初始化一个用于输出的AVFormatContext结构体，视频帧率和宽高在此函数里面设置  
            if (ofmt_ctx == null) {
                System.Console.WriteLine("Could not create output context\n");
                return;
            }

            AVStream* out_stream = AddVideoStream(ofmt_ctx, AVCodecID.AV_CODEC_ID_MJPEG);//创造输出视频流  
            ffmpeg.av_dump_format(ofmt_ctx, 0, out_filename, 1);//该函数会打印出视频流的信息，如果看着不开心可以不要  

            int ret;//返回标志  
            if ((ofmt_ctx->oformat->flags & ffmpeg.AVFMT_NOFILE) == 0) {//打开输出视频文件              
                ret = ffmpeg.avio_open(&ofmt_ctx->pb, out_filename, ffmpeg.AVIO_FLAG_WRITE);
                if (ret < 0) {
                    System.Console.WriteLine("Could not open output file '%s'", out_filename);
                    return;
                }
            }
            AVDictionary* opt = null;
            ffmpeg.av_dict_set_int(&opt, "video_track_timescale", frameRate, 0);
            if (ffmpeg.avformat_write_header(ofmt_ctx, &opt) < 0) {//写文件头（Write file header）  
                System.Console.WriteLine("Error occurred when opening output file\n");
                return;
            }



            AVPacket pkt = new AVPacket();

            ffmpeg.av_init_packet(&pkt);
            pkt.flags |= ffmpeg.AV_PKT_FLAG_KEY;
            pkt.stream_index = out_stream->index;//获取视频信息，为压入帧图像做准备  
            for (int i = 0; i < img.Count; ++i) { //将图像压入视频中  
                byte[] item = img[i];
                pkt.size = item.Length;// fread(mydata, 1, DATASIZE, file);


                fixed (byte* p = item) {
                    pkt.data = p;
                }

                if (ffmpeg.av_interleaved_write_frame(ofmt_ctx, &pkt) < 0) //写入图像到视频  
                {
                    System.Console.WriteLine("Error muxing packet\n");
                    break;
                }
                System.Console.WriteLine("Write %8d frames to output file\n", i);//打印出当前压入的帧数  
            }
            ffmpeg.av_packet_unref(&pkt);//释放掉帧数据包对象  
            ffmpeg.av_write_trailer(ofmt_ctx);//写文件尾（Write file trailer）  
                                              //  delete[] mydata;//释放数据对象  
            if (ofmt_ctx != null && (ofmt_ctx->oformat->flags & ffmpeg.AVFMT_NOFILE) == 0)
                ffmpeg.avio_close(ofmt_ctx->pb);//关闭视频文件  
            ffmpeg.avformat_free_context(ofmt_ctx);//释放输出视频相关数据结构  
            return;
        }
    }


}