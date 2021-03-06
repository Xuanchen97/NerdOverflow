﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostPreviewWithActions.ascx.cs" Inherits="Forum.UserControl.PostPreviewWithActions" %>
<div class="post">
    <asp:HiddenField ID="postId" runat="server" />
    <div class="post_left">

    </div>

    <div class="post_right">
      
        <div class="post_title">
            <asp:HyperLink ID="postUrl" runat="server">HyperLink</asp:HyperLink>
<%--            <asp:HyperLink ID="" runat="server" BorderStyle="None" NavigateUrl="<%=  %>"">
            </asp:HyperLink>--%>
        </div>
        <div class="post_metadata">
            <div class="post_category">
                <asp:Label ID="lblCategory"  runat="server" Text=""></asp:Label> 
            </div>
            <div class="post_author">Post by 
                <asp:Label ID="lblAuthor"  runat="server" Text=""></asp:Label> 
            </div>
            <div class="post_date">
                <asp:Label ID="lblPostDate"  runat="server"></asp:Label>
            </div>
            <%if (Session["userId"] != null && IsAuthour && Post.Status == "review"){%>
            <div>
                <label class="inReview">Flagged</label>
            </div>
            <%} %>
        </div>
        <div class="post_content">
        <% if (Post != null && Post.Content != null){ %>
        <pre ><%= Post.Content %></pre>
        <% } %>
        </div>
        <div class="post_others">
            <div class="post_comment">
                <i class="fas fa-comment-alt"></i>
                <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
            </div>
            <%if (Session["userId"] != null){ %>
            <div class="post_save action">
                <i class="fas fa-bookmark"></i>
                <asp:Button ID="btnBookmark" runat="server" Text="Save" OnClick="btnBookmark_Click"/>
            </div>
            <%} %>
            <% if (IsAuthour){ %>
                <div class="post_edit action">
                    <i class="fas fa-edit"></i>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click"/>
                </div>
                <div class="post_delete action">
                   <i class="fas fa-trash-alt"></i>
                    <asp:Button ID="btnDelte" runat="server" Text="Delete" OnClick="btnDelte_Click" />
                </div>
            <% }%>
        </div>
    </div>

</div> 