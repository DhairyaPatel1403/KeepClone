using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KeepCloneClient
{
    public partial class Write : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve note ID from URL parameter
                if (Request.QueryString["Noteid"] != null)
                {
                    lblNoteId.Text = $"Note ID: {Request.QueryString["Noteid"]}";

                    using (WebClient proxy = new WebClient())
                    {
                        // Specify the content type for the request
                        proxy.Headers[HttpRequestHeader.ContentType] = "application/json";


                        // Send a PUT request to the UpdateNote endpoint with the note ID in the URL
                        string serviceUrl = $"http://localhost:56554/NotesService.svc/GetNoteById/{Request.QueryString["Noteid"]}";
                        string response = proxy.DownloadString(serviceUrl);

                        List<Note> resultList = JsonConvert.DeserializeObject<List<Note>>(response);

                        string notecontent = resultList[0].Notecontent;

                        txtNoteContent.Text = notecontent;

                        // Display the result
                        lblResult.Text = "Note updated successfully.";
                    }
                }
                else
                {
                    lblNoteId.Text = "Note ID not found.";
                }
            }
        }

        protected void btnUpdateNote_Click(object sender, EventArgs e)
        {
            // Retrieve note ID from URL parameter
            string noteId = Request.QueryString["Noteid"];

            // Retrieve note content from textarea
            string noteContent = txtNoteContent.Text;

            // Call the service to update the note content
            UpdateNoteContent(noteId, noteContent);
        }

        private void UpdateNoteContent(string noteId, string noteContent)
        {
            try
            {
                using (WebClient proxy = new WebClient())
                {
                    // Specify the content type for the request
                    proxy.Headers[HttpRequestHeader.ContentType] = "application/json";

                    // Prepare the data to be sent in JSON format
                    string requestData = $"{{\"newContent\": \"{noteContent}\"}}";

                    // Send a PUT request to the UpdateNote endpoint with the note ID in the URL
                    string serviceUrl = $"http://localhost:56554/NotesService.svc/UpdateNote/{noteId}/{noteContent}";
                    string response = proxy.DownloadString(serviceUrl);

                    // Display the result
                    lblResult.Text = "Note updated successfully.";
                }
            }
            catch (WebException ex)
            {
                // Handle any errors or exceptions
                lblResult.Text = "Error: " + ex.Message;
            }
        
        }



        
    }
}