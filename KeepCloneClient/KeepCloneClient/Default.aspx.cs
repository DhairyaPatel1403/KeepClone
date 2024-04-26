using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI;

namespace KeepCloneClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

            protected void btnSignIn_Click(object sender, EventArgs e)
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    // Call your sign-in service here
                    // Example:
                    string serviceUrl = $"http://localhost:56554/NotesService.svc/AddUser/{username}/{password}";
                    string response = CallService(serviceUrl);

                    Session["Username"] = username;


                    string redirectUrl = "/Home";

                    // Redirect to the new URL
                    Response.Redirect(redirectUrl);
                }
                else
                {
                    lblErrorMessage.Text = "Please enter both username and password.";
                }
            }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // Call the GetAllUsers service to retrieve all users
                string serviceUrl = "http://localhost:56554/NotesService.svc/GetAllUsers";
                string usersJson = CallService(serviceUrl);

                // Deserialize the JSON response to a list of User objects
                List<User> users = JsonConvert.DeserializeObject<List<User>>(usersJson);

                // Check if the entered username and password exist in the list of users
                bool userExists = users.Any(u => u.Username == username && u.Password == password);

                if (userExists)
                {
                    // Store the username in a session
                    Session["Username"] = username;

                    string redirectUrl = "/Home"; // Modify the redirect URL as needed

                    // Redirect to the new URL
                    Response.Redirect(redirectUrl);
                }
                else
                {
                    lblLoginErrorMessage.Text = "Invalid username or password.";
                }
            }
            else
            {
                lblLoginErrorMessage.Text = "Please enter both username and password.";
            }
        }

        // Method to call the service
        private string CallService(string serviceUrl)
        {
            using (WebClient proxy = new WebClient())
            {
                return proxy.DownloadString(serviceUrl);
            }
        }
    }
}
