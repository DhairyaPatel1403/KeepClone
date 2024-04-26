using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;


namespace KeepCloneClient
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }



        private void BindGridView()
        {
            using (WebClient proxy = new WebClient())
            {
                string username = Session["Username"].ToString();
                string serviceurl = $"http://localhost:56554/NotesService.svc/GetAllDiaries/{username}";
                string jsonResult = proxy.DownloadString(serviceurl);

                // Deserialize the JSON response to a list of Note objects
                List<Diary> diaries = JsonConvert.DeserializeObject<List<Diary>>(jsonResult);




                // Bind the list of notes to the GridView
                GridView1.DataSource = diaries;
                GridView1.DataBind();
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Noteit")
            {
                int diaryId = Convert.ToInt32(e.CommandArgument);

                WebClient proxy = new WebClient();
                string serviceurl = string.Format("http://localhost:56554/NotesService.svc/GetNotesByDiaryId/{0}", diaryId);
                byte[] _data = proxy.DownloadData(serviceurl);
                Stream _mem = new MemoryStream(_data);

                var reader = new StreamReader(_mem);
                var result = reader.ReadToEnd();

                string redirectUrl = $"/ViewNote/?Diaryid={diaryId}";

                // Redirect to the new URL
                Response.Redirect(redirectUrl);

                lblResult.Text = result;
            }
            if (e.CommandName == "DeleteDiary")
            {
                int diaryid = Convert.ToInt32(e.CommandArgument);

                WebClient proxy = new WebClient();
                string serviceurl = string.Format("http://localhost:56554/NotesService.svc/DeleteDiary/{0}", diaryid);
                string response = proxy.DownloadString(serviceurl);
            }


        }

        protected void btnAddDiary_Click(object sender, EventArgs e)
        {
            string diaryName = txtDiaryName.Text.Trim();

            if (!string.IsNullOrEmpty(diaryName))
            {
                using (WebClient proxy = new WebClient())
                {
                    // Specify the content type for the request
                    proxy.Headers[HttpRequestHeader.ContentType] = "application/json";

                    // Prepare the data to be sent in JSON format (optional if your service accepts empty body)

                    try
                    {
                        string username = Session["Username"].ToString();
                        // Send a POST request to the AddDiary endpoint with the diary name in the request body
                        string serviceUrl = $"http://localhost:56554/NotesService.svc/AddDiary/{diaryName}/{username}";
                        string response = proxy.DownloadString(serviceUrl);

                        // Refresh the GridView after adding the diary
                        BindGridView();

                        // Clear the TextBox after adding the diary
                        txtDiaryName.Text = "";

                        lblResult.Text = "Diary added successfully.";
                    }
                    catch (WebException ex)
                    {
                        // Handle any errors or exceptions
                        lblResult.Text = "Error: " + ex.Message;
                    }
                }
            }
            else
            {
                lblResult.Text = "Please enter a diary name.";
            }
        }


    }
}