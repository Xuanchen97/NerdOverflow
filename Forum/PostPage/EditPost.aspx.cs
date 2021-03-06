﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Forum.Models;
using Forum.Repositories;

namespace Forum.PostPage
{
    public partial class EditPost : System.Web.UI.Page
    {
        // Instance of a Post class
        Post post = new Post();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Assigning the ID of the post to postId variable.
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int postId);

            // Retrieving the data from the database that matches the postID.
            post = Repositories.PostRepo.GetPost(postId);

            // Assigning the values we got from the code above to the textboxes.
            txtTitle.Text = post.Title;
            ddCategory.SelectedValue = post.Category;
            txtContent.Text = post.Content;
 
        }

        // Submit button event
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // If all the fields are not filled, this means the user did not update anything and an alert will pop up. 
            if (txtTitle.Text == post.Title && ddCategory.SelectedValue == post.Category
               && txtContent.Text == post.Content && chkDelete.Checked == false && !FileUpload1.HasFile)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Info", "noUpdate()", true);
            }
            // If any of the fields are changed, this checks if the FileUpload and checkbox both have values because this is an error.
            // If not, then the program will proceed to update the post and uncheck the checkbox.
            else if (txtTitle.Text != post.Title || ddCategory.SelectedValue != post.Category
               || txtContent.Text != post.Content || chkDelete.Checked != false || FileUpload1.HasFile)
            {
                if (FileUpload1.HasFile && chkDelete.Checked == true)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "errorImage()", true);
                } else
                {
                    updatePost();
                    chkDelete.Checked = false;
                }
                            
            }
        }

        // UPDATE THE POST
        void updatePost()
        {
            SqlConnection dbConnect = new SqlConnection();

            SqlCommand cmd = dbConnect.CreateCommand();

            dbConnect.ConnectionString =
                System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ForumConnectionString"].ToString();

            try
            {
                string query;

                // IF the post has an image
                if (FileUpload1.HasFile)
                {
                    query = "UPDATE Post " +
                    "SET title = @Title , category = @Category , content = @Content , post_image = @Image , updated_at = '" + DateTime.Now + "'" +
                    "WHERE post_id = " + post.PostId;

                    SqlParameter image = new SqlParameter();
                    image.ParameterName = "@Image";

                    HttpPostedFile postedFile = FileUpload1.PostedFile;
                    string fileName = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(fileName);

                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                    || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".jpeg")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                        image.Value = bytes;
                        cmd.Parameters.Add(image);
                    }
                }
                // Checks if the user wants to delete the current photo their post has.
                else if(chkDelete.Checked == true)
                {
                    query = "UPDATE Post " +
                    "SET title = @Title , category = @Category , content = @Content , post_image = NULL , updated_at = '" + DateTime.Now + "'" +
                    "WHERE post_id = " + post.PostId;
                } else
                {
                    query = "UPDATE Post " +
                    "SET title = @Title , category = @Category , content = @Content , updated_at = '" + DateTime.Now + "'" +
                    "WHERE post_id = " + post.PostId;
                }

                SqlParameter title = new SqlParameter();
                title.ParameterName = "@Title";
                title.Value = txtTitle.Text;

                SqlParameter content = new SqlParameter();
                content.ParameterName = "@Content";
                content.Value = txtContent.Text;

                SqlParameter category = new SqlParameter();
                category.ParameterName = "@Category";
                category.Value = ddCategory.SelectedValue.ToString();

                // step 5: Set the commandtext to the query you made
                cmd.CommandText = query;

                // step 6: Add the parameters to the SqlCommand
                cmd.Parameters.Add(title);
                cmd.Parameters.Add(content);
                cmd.Parameters.Add(category);


                // Open the sql Connection
                dbConnect.Open();

                // execute the query code
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "postUpdated()", true);
                }
            }
            catch (SqlException ex)
            {
                if (FileUpload1.HasFile)
                {
                    string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName).ToLower();

                    if (ext != "jpg" || ext != "bmp" || ext != "png" || ext != "gif" || ext != ".jpeg")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", "error()", true);
                    }

                }
                else
                {
                    
                }
            }
            finally
            {
                cmd.Dispose();
                dbConnect.Close();
            }
        }
    }
}