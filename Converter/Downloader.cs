using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Converter
{
    public class Downloader: IConvert
    {

        /// <summary>
        /// Static method to get the MetaData of the video
        /// </summary>
        /// <param name="url">The video url</param>
        /// <param name="Status">IProgress to track the progress</param>
        /// <returns>A model of metadata</returns>
        public static async Task<MetaDataModel> GetMetaData(string url, IProgress<string> Status)
        {
            try
            {
                var youtube = new YoutubeClient();

                //Send a request to youtube to send us the video metadata
                Status.Report("Status: Retrieving Video MetaData...");
                var video = await youtube.Videos.GetAsync(url);
                WebClient client = new WebClient();
                //Ream them and save them
                Stream stream = null;
                MetaDataModel model = null;
                foreach (var thumbnail in video.Thumbnails)
                {
                    try
                    {
                        stream = client.OpenRead(thumbnail.Url);
                        //Create a model to return
                        model = new MetaDataModel()
                        {
                            Title = video.Title,
                            Artist = video.Author.ChannelTitle,
                            Duration = video.Duration.ToString(),
                            Image = new Bitmap(stream)
                        };
                        break;
                    }
                    catch { }
                }
                if (model == null)
                {
                    model = new MetaDataModel()
                    {
                        Title = video.Title,
                        Artist = video.Author.ChannelTitle,
                        Duration = video.Duration.ToString(),
                        Image = null
                    };
                }
                stream.Flush();
                stream.Close();
                client.Dispose();
                Status.Report("Status: Fetched Video MetaData");
                return model;
            }
            catch (Exception ex)
            {
                Status.Report(ex.Message);
                Status.Report("Status: Url Not Found");
                return null;
            }
        }

        /// <summary>
        /// Internal not exposed method to download the audio of the video (Only the audio. Usually it saves a .webm file)
        /// </summary>
        /// <param name="url">The video url</param>
        /// <param name="Status">The IProgress to track the status</param>
        /// <param name="progress">The IProgress to track the percentage of the download</param>
        /// <returns>The path of the file that we downlaoded</returns>
        internal async Task<string> GetAudioAsync(string url, IProgress<string> Status, IProgress<double> progress)
        {
            var youtube = new YoutubeClient();

            //Retrieve the metadata
            Status.Report("Status: Retrieving Video MetaData...");
            var video = await youtube.Videos.GetAsync(url);

            var title = video.Title;

            //Retrieve the Video Manifest to get the download link
            Status.Report("Status: Retrieving Video Manifest...");
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);

            // Select the highest Quality audio that exists
            var streamInfo = streamManifest.GetAudioOnlyStreams().OrderBy(s => s.Bitrate).Last();

            //Remove the invalid and illegal Filename chars from the title
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            title = r.Replace(title, "");
            //Download the audio
            await youtube.Videos.Streams.DownloadAsync(streamInfo, Path.Combine(Path.GetTempPath(), $"{title}.{streamInfo.Container}"), progress);
            Status.Report("Status: Download Complete");
            return Path.Combine(Path.GetTempPath(), $"{title}.{streamInfo.Container}");
        }

        /// <summary>
        /// Download the video. No need to convert the video to mp4 as it always is mp4 mimepipe.
        /// </summary>
        /// <param name="url">The video url</param>
        /// <param name="saveLocation">The folder you want to save the file in</param>
        /// <param name="Status">The IProgress to track the status</param>
        /// <param name="progress">The IProgress to track the progress</param>
        /// <param name="Completed">The IProgress to track the completition</param>
        /// <returns></returns>
        public async Task ConvertAsync(string url, string saveLocation, IProgress<string> Status, IProgress<double> progress, IProgress<bool> Completed)
        {
            try
            {
                var youtube = new YoutubeClient();

                //Retrieve the metadata
                Status.Report("Status: Retrieving Video MetaData...");
                var video = await youtube.Videos.GetAsync(url);

                var title = video.Title;

                //Retrieve the video manifest to get the download url
                Status.Report("Status: Retrieving Video Manifest...");
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);

                //Select the highest possible quality to download
                var streamInfo = streamManifest.GetMuxedStreams().OrderBy(s => s.VideoQuality).Last();

                //Remove the invalid and illegal characters from the title
                string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                title = r.Replace(title, "");
                //Dowload the video and save it 
                await youtube.Videos.Streams.DownloadAsync(streamInfo, Path.Combine(saveLocation, $"{title}.{streamInfo.Container}"), progress);
                Status.Report("Status: Download Complete");

            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                Status.Report("Could not find a download url. Try a different video");
            }
            catch (Exception ex) { Status.Report(ex.Message); }
            finally { Completed.Report(true); }
        }
    }
}
