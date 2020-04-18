using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public enum ConvertType
    {
        Video,
        Audio
    }
    public enum Pipe
    {
        mp3,
        mp4
    }
    public abstract class Factory
    {
        /// <summary>
        /// Activates an instance of the correct converter 
        /// </summary>
        /// <param name="Type">Convert Type (Audio, Video)</param>
        /// <param name="MimePipe">MimePipe (mp3, mp4)</param>
        /// <returns>The activated instance to use</returns>
        public static IConvert Activate(ConvertType Type, Pipe MimePipe)
        {
            if (Type == ConvertType.Audio)
                return new ConvertTomp3();
            else return new Downloader();
        }
    }
}
