using Converter;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_to_mp3_Converter
{
    public partial class PapConverter : Form
    {
        string folder; // Folder selected to save
        IConvert Converter = Factory.Activate(ConvertType.Audio, Pipe.mp3); //Converter that defaults to Convert type of Audio with mimepipe of mp3

        public PapConverter()
        {
            InitializeComponent();
            Url.TextChanged += Url_TextChanged;
        }

        private void Url_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Url.Text) && !string.IsNullOrEmpty(Url.Text))
                _ = SetData(); // discarding the await since we want it to work asynchronous
        }

        private async Task SetData()
        {
            //Setup a IProgress Variable to get some live feedback from the API
            var Status = new Progress<string>(p => Statuslbl.Text = p);

            //Grab the metadata from the youtube
            Converter.MetaDataModel data = await Downloader.GetMetaData(Url.Text, Status);
            //If returned null some error occured that will be indicated at the status
            if (data == null)
            {
                Convert.Enabled = false;
                return;
            }
            //If everything are ok then populate the fields 
            Titlelbl.Text = data.Title;
            Artistlbl.Text = data.Artist;
            Image.Image = data.Image;
            Duration.Text = data.Duration;
            Convert.Enabled = true;
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            //Make sure the progress bar is set to 0
            progressBar.Value = 0;
            if (string.IsNullOrEmpty(Url.Text))
            {
                MessageBox.Show("No url Specified!", "Error");
                return;
            }
            //Prompt the user to select his desired folder
            FolderBrowserDialog diag = new FolderBrowserDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                folder = diag.SelectedPath;
                GetVideo();
            }
            else Statuslbl.Text = "Convertion Cancelled by User";
        }

        private void GetVideo()
        {
            //Set the IProgress indicators
            var Status = new Progress<string>(p => Statuslbl.Text = p);
            var progress = new Progress<double>(p => { Statuslbl.Text = $"Status: Downloading Video [{p:P0}]"; progressBar.Value = (int)(p * 100); });
            var Completed = new Progress<bool>(p => { Convert.Enabled = p; Url.Enabled = p; });
            //Make sure we have grabed a converter 
            if (Converter != null)
                Converter.ConvertAsync(Url.Text, folder, Status, progress, Completed); // Convert and save the file (API call)
            Convert.Enabled = false;
            Url.Enabled = false;
        }

        private void mp3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Change the converter to the specified parameters. (API call)
            Converter = Factory.Activate(ConvertType.Audio, Pipe.mp3);
            mp3ToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            mp4ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            videoToolStripMenuItem.BackColor = System.Drawing.Color.White;
            audioToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
        }

        private void mp4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Change the converter to the specified parameters. (API call)
            Converter = Factory.Activate(ConvertType.Video, Pipe.mp4);
            mp3ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            mp4ToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            videoToolStripMenuItem.BackColor = System.Drawing.Color.Blue;
            audioToolStripMenuItem.BackColor = System.Drawing.Color.White;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pap Converter is an OpenSource Project created by Konstantinos Pap that helps you download and convert to specific formats youtube videos.\nYou can select the format and type you want to download (e.g. Video or Audio, mp3 or mp4) to download and convert the video.\nThe only thing you have to do is paste the url and press Convert when the metadata are loaded.\nYou do not have the option to select the video quality or the audio quality but by default we are downloading the best video and/or audio quality we can find on youtube!\n\n Konstantinos Pap \n\n No Copyrights --OpenSource Project--", "About Us", MessageBoxButtons.OK);
        }

        private void troubleshootingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The main issue we can find at the momment is the Access Denied error. When an error like that occurs you will see an Access Denied indicator on the status at the bottom left side of the program. The cause of that is probably your antivirus blocking us from saving the converted file to the folder you specified (Filter should be called \"Safe Files\") and you can take one of the following actions to fix it.\n\n   Fix N.1: Give permissions to our app in your antivirus to be able to write to those folders.\n  Fix N.2: If you don't like the idea of our app having permissions to change the protected folders, select another folder to save your file.", "Troubleshooting", MessageBoxButtons.OK);
        }
    }
}
