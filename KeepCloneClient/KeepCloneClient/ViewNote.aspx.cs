using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KeepCloneClient
{
    public partial class ViewNote : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve diaryId from URL parameter
                if (Request.QueryString["Diaryid"] != null)
                {
                    int diaryId = Convert.ToInt32(Request.QueryString["Diaryid"]);
                    lblDiaryId.Text = $"Diary ID: {diaryId}";


                    WebClient proxy = new WebClient();
                    string serviceurl = string.Format("http://localhost:56554/NotesService.svc/GetNotesByDiaryId/{0}", diaryId);
                    byte[] _data = proxy.DownloadData(serviceurl);
                    Stream _mem = new MemoryStream(_data);

                    var reader = new StreamReader(_mem);
                    var result = reader.ReadToEnd();


                    lblNotes.Text = result;

                    List<Note> notes = JsonConvert.DeserializeObject<List<Note>>(result);


                    GridView1.DataSource = notes;
                    GridView1.DataBind();
                }
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Noteit")
            {
                int noteid = Convert.ToInt32(e.CommandArgument);



                string redirectUrl = $"/Write/?Noteid={noteid}";

                // Redirect to the new URL
                Response.Redirect(redirectUrl);

            }
            if (e.CommandName == "DeleteNote")
            {
                int noteid = Convert.ToInt32(e.CommandArgument);

                WebClient proxy = new WebClient();
                string serviceurl = string.Format("http://localhost:56554/NotesService.svc/DeleteNote/{0}", noteid);
                string response = proxy.DownloadString(serviceurl);
            }


        }


        protected void btnAddNote_Click(object sender, EventArgs e)
        {
            string noteName = txtNoteName.Text.Trim();
            string diaryId = Request.QueryString["Diaryid"];


            if (!string.IsNullOrEmpty(noteName))
            {
                using (WebClient proxy = new WebClient())
                {
                    // Specify the content type for the request
                    proxy.Headers[HttpRequestHeader.ContentType] = "application/json";

                    // Prepare the data to be sent in JSON format (optional if your service accepts empty body)

                    try
                    {
                        // Send a POST request to the AddDiary endpoint with the diary name in the request body
                        string serviceUrl = $"http://localhost:56554/NotesService.svc/AddNote/{diaryId}/{noteName}";
                        string response = proxy.DownloadString(serviceUrl);


                        // Clear the TextBox after adding the diary
                        txtNoteName.Text = "";

                    }
                    catch (WebException ex)
                    {
                        // Handle any errors or exceptions
                        
                    }
                }
            }

        }





        // Method to display notes
        private void DisplayNotes(List<Note> notes)
        {
            
        }
    }


}

