﻿using Forum.Models;
using Forum.Repositories;
using Forum.UserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserPage
{
    public partial class PostHistoryPage : System.Web.UI.Page
    {
        private List<Post> posts;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            this.Master.PostPageBtn.CssClass = "user_right_navlink active";
            posts = getPosts(new List<string> { "'reivew'", "'published'" }, "DESC");
            Render();
        }


        public List<Post> getPosts( List<string> filters, string orderBy)
        {
            int.TryParse(Page.RouteData.Values["Id"].ToString(), out int userId);
            return PostRepo.getPostsByAuthor(userId, filters, orderBy);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string orderBy = sortOpt.SelectedValue.Equals("New") ? "DESC" : "ASC";
            List<string> filters = new List<string>();
            if (cbReview.Checked) filters.Add("'review'");
            if (cbPublic.Checked) filters.Add("'published'");
            posts = getPosts(filters, orderBy);
            Render();
        }

        private void Render()
        {
            PlaceHolder1.Controls.Clear();
            foreach (var post in posts)
            {
                PostPreviewWithActions control = (PostPreviewWithActions)Page.LoadControl("..\\UserControl\\PostPreviewWithActions.ascx");
                control.Post = post;
                control.Callback = this.Refresh;
                PlaceHolder1.Controls.Add(control);
            }
        }

        public void Refresh(string message, bool err)
        {
            posts = getPosts(new List<string> { "'reivew'", "'published'" }, "DESC");
            Render();
            string e = err ? "true" : "false";
            string script = $"<script>displayAlert('{message}',{e});</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Javascript", script);
        }
    }
}