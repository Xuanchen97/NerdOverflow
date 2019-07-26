﻿using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum.UserControl
{
    public partial class BookmarkControl : System.Web.UI.UserControl
    {
        public Bookmark Bookmark { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Bookmark != null && Bookmark.Post.Title != null)
            {
                bookmarkId.Value = Bookmark.BookmarkId.ToString();
                postUrl.NavigateUrl = "";
                lblTitle.Text = Bookmark.Post.Title;
                lblCategory.Text = Bookmark.Post.Category;
                lblAuthor.Text = Bookmark.User.Username;
                lblPostDate.Text = (Bookmark.Post.CreatedAt.ToString());
            }
        }
    }
}