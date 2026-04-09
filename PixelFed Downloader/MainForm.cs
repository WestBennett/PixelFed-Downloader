using System.Data.SqlTypes;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace PixelFed_Downloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            int totalFiles = 0;
            int totalFailures = 0;
            int totalFilesDownloaded = 0;
            try
            {
                Enabled = false;
                Cursor = Cursors.WaitCursor;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JSON Files|*.json";
                ofd.Multiselect = false;
                ofd.Title = "Pick Your input PixelFed Status File to Process...";
                ofd.AddToRecent = false;
                if (ofd.ShowDialog() != DialogResult.OK || !File.Exists(ofd.FileName)) return;

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Choose Which Folder to Save the Files Into...";
                fbd.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                fbd.Multiselect = false;
                fbd.ShowNewFolderButton = true;
                fbd.UseDescriptionForTitle = true;
                fbd.AddToRecent = false;
                if (fbd.ShowDialog() != DialogResult.OK || !Directory.Exists(fbd.SelectedPath)) return;

                //Process the JSON file
                string jsonString = File.ReadAllText(ofd.FileName);

                // Configure options for case-insensitive matching if necessary
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize the list of posts
                List<PixelfedPost> posts = JsonSerializer.Deserialize<List<PixelfedPost>>(jsonString, options);

                if (posts == null || posts.Count == 0) 
                {
                    MessageBox.Show("No posts found in file.", "No Posts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UpdateStatus("Downloading files found in file '" + ofd.FileName + "'.");

                // Iterate through posts and access media
                int postNum = 0;
                foreach (var post in posts)
                {
                    postNum++;
                    string folderToWriteTo = (chkMakeFolders.Checked ? fbd.SelectedPath + @"\" + post.Id : fbd.SelectedPath) + @"\";
                    UpdateStatus($"Downloading Post #{postNum}/{posts.Count}, ID: {post.Id} to folder '{folderToWriteTo}'...");
                    if (!Directory.Exists(folderToWriteTo))
                    {
                        UpdateStatus($"Creating directory '{folderToWriteTo}'...");
                        Directory.CreateDirectory(folderToWriteTo);
                    }

                    int fileNum = 0;
                    foreach (var media in post.MediaAttachments)
                    {
                        fileNum++;
                        totalFiles++;
                        //Download the image to the final location, set the fileName to the fileName of the original file in the URL
                        Uri uri = new Uri(media.Url);
                        string newFileName = folderToWriteTo + Path.GetFileName(uri.AbsolutePath);
                        if (File.Exists(newFileName))
                        {
                            if (rdoRename.Checked)
                            {
                                //Perform a loop and increment a number to add to the end of the filename before the extension
                                int fileNameNum = 0
                                    ;
                                do
                                {
                                    fileNameNum++;
                                    newFileName = folderToWriteTo + Path.GetFileNameWithoutExtension(newFileName) + "_" + fileNameNum.ToString() +
                                        Path.GetExtension(newFileName);
                                } while (File.Exists(newFileName));
                            }
                            else
                            {
                                File.Delete(newFileName);
                            }
                        }

                        UpdateStatus($"Post #{postNum}/{posts.Count}, File #{fileNum}/{post.MediaAttachments.Count}, '" + newFileName +
                            $"' downloading to location '{newFileName}'...");

                        //Download the file to the new location
                        DownloadFileSync(media.Url, newFileName);

                        if (!File.Exists(newFileName))
                        {
                            totalFailures++;
                            UpdateStatus("Failed to download and write file '" + media.Url + "' to location '" + newFileName + "'.");
                        }
                        else totalFilesDownloaded++;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
            finally
            {
                Enabled = true;
                Cursor = Cursors.Default;
                //Let the user know and let them know how many files successfully downloaded
                string message = "Results: " + Environment.NewLine + totalFiles + " total file(s)" + Environment.NewLine +
                    totalFilesDownloaded + " downloaded" + Environment.NewLine + totalFailures + " failures";
                MessageBox.Show(message, "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void DownloadFileSync(string url, string outputPath)
        {
            // Best practice: Reuse HttpClient instances to avoid socket exhaustion
            using (HttpClient client = new HttpClient())
            {
                // Use .GetAwaiter().GetResult() to block the thread synchronously
                byte[] fileBytes = client.GetByteArrayAsync(url).GetAwaiter().GetResult();

                // Save the downloaded bytes to the local file system
                File.WriteAllBytes(outputPath, fileBytes);
            }
        }

        private void LogError(Exception ex)
        {
            MessageBox.Show("Error - " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Updates the status textbox and refreshes the window. The status window will do a new line per message and always put the new message on top
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatus(string message)
        {
            try
            {
                txtStatus.Text = message + Environment.NewLine + txtStatus.Text;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }


        public class PixelfedPost
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("content")]
            public string Content { get; set; }

            [JsonPropertyName("media_attachments")]
            public List<MediaAttachment> MediaAttachments { get; set; }
        }

        public class MediaAttachment
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; } // "image", "video"

            [JsonPropertyName("url")]
            public string Url { get; set; } // The actual image/video link

            [JsonPropertyName("preview_url")]
            public string PreviewUrl { get; set; } // Thumbnail
        }
    }
}
