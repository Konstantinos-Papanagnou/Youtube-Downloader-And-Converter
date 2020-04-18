﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Enums;
using Xabe.FFmpeg.Model;

namespace Converter
{
    /// <summary>
    /// Downloads and saves the audio to mp3 format
    /// </summary>
    public class ConvertTomp3: IConvert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">The video url</param>
        /// <param name="outputFolder">The folder to save the audio in</param>
        /// <param name="Status">The IProgress to track the status</param>
        /// <param name="progress">The IProgress to track the progress</param>
        /// <param name="Completed">The IProgress to track the completition</param>
        /// <returns></returns>
        public async Task ConvertAsync(string url, string outputFolder, IProgress<string> Status, IProgress<double> progress, IProgress<bool> Completed)
        {
            try
            {
                //Create an instance of the Downloader int this API to download the audio as webm to a temp location
                Downloader downloader = new Downloader();
                string song = await downloader.GetAudioAsync(url, Status, progress);

                //Begin Convert Process
                Status.Report("Status: Converting and Saving...");
                string output = Path.ChangeExtension(song, FileExtensions.Mp3);
                //To avoid any errors of type file already exists
                if (File.Exists(output))
                    File.Delete(output);
                //Begin the actual process of convertion
                IConversionResult result = await Conversion.ExtractAudio(song, output)
                .Start();
                //Clean up Section
                //Delete the webm file and move the mp3 file to the user provided folder.
                Status.Report("Status: Clean Up...");
                File.Delete(song);
                string filename = output.Split('\\').Last();
                string finalPath = Path.Combine(outputFolder, filename);
                File.Move(output, finalPath);
                Status.Report("Status: Convertion Complete and file Saved at: \n" + finalPath);
            }
            catch (Exception ex)
            {
                Status.Report(ex.Message);
            }
            finally { Completed.Report(true); }
        }
    }
}
