﻿using Forum.Models;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserControl
{
    public partial class PostPreviewWithActions : System.Web.UI.UserControl
    {
        public Post Post { get; set; }
        public bool IsAuthour
        {
            get
            {
                return Session["userId"] != null && Convert.ToInt32(Session["userId"].ToString()) == Post.UserId;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Render();
        }

        private void Render()
        {
            if (Post == null) return;
            lblAuthor.Text = Post.User.Username;
            lblCategory.Text = Post.Category;
            lblPostDate.Text = Post.CreatedAt.ToString();
            postId.Value = Post.PostId.ToString();
            postUrl.NavigateUrl = "/posts/"+postId;
            postUrl.Text = Post.Title;
            int count = Post.TotalComments;
            lblComment.Text = count == 1 ? count + " Comment" : count + " Comments";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/posts/{postId}/");
        }

        protected void btnDelte_Click(object sender, EventArgs e)
        {
            if (int.TryParse(postId.Value, out int id))
            {
                PostRepo.DeletePost(id);
                Response.Redirect($"/users/{Page.RouteData.Values["Id"].ToString()}/posts/");
            }
        }

        protected void btnBookmark_Click(object sender, EventArgs e)
        {
            Bookmark bookmark = new Bookmark
            {
                PostId = Convert.ToInt32(postId.Value),
                UserId = Convert.ToInt32(Session["userId"])
            };
            BookmarkRepo.CreateBookmark(bookmark);
        }
    }
}