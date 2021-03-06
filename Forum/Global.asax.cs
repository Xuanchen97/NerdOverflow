﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Forum
{
    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            //string id = Page.RouteData.Values["Id"].ToString();
            routeCollection.MapPageRoute("admin", "adminControl/", "~/Admin/admin.aspx");
            routeCollection.MapPageRoute("login", "signin/", "~/Login/login.aspx");
            routeCollection.MapPageRoute("register", "register/", "~/Registration/Registration.aspx");
            routeCollection.MapPageRoute("RouteForBookmarks", "users/{Id}/bookmarks/", "~/UserPage/BookmarkPage.aspx");
            routeCollection.MapPageRoute("RouteForPostHistory", "users/{Id}/posts/", "~/UserPage/PostHistoryPage.aspx");
            routeCollection.MapPageRoute("RouteForUserProfile", "users/{Id}/", "~/UserPage/ProfilePage.aspx");
            routeCollection.MapPageRoute("RouteForCreatePost", "posts/new/", "~/PostPage/CreatePost.aspx");
            routeCollection.MapPageRoute("RouteForEditPost", "posts/{Id}/edit/", "~/PostPage/EditPost.aspx");
            routeCollection.MapPageRoute("RouteForPost", "posts/{Id}/", "~/PostPage/ViewPost.aspx");
            routeCollection.MapPageRoute("RouteForPosts", "posts/", "~/PostsPage/PostListPage.aspx");
            routeCollection.MapPageRoute("RouteForHomePage", "", "~/StaticPages/HomePage.aspx");

        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}