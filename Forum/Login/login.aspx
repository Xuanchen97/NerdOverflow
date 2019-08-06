﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Login/login.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Forum.Login.login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="login100-form-title p-b-49">
						Login
					</span>

					<div class="wrap-input100 validate-input m-b-23" data-validate = "Username is reauired">
						<span class="label-input100">Username</span>
						<!--<input class="input100" type="text" name="username" placeholder="Type your username">-->
                        <asp:TextBox ID="txtUserName" runat="server" class="input100" type="text" name="username" placeholder="Type your username"></asp:TextBox>
                        <span class="focus-input100" data-symbol="&#xf206;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Password is required">
						<span class="label-input100">Password</span>
						<!--<input class="input100" type="password" name="pass" placeholder="Type your password">-->
                        <asp:TextBox ID="txtPassword" runat="server" class="input100" type="password" name="pass" placeholder="Type your password"></asp:TextBox>
                        <span class="focus-input100" data-symbol="&#xf190;"></span>
					</div>
					
					<div class="text-right p-t-8 p-b-31">
						<a href="#">
							Forgot password?
						</a>
					</div>
					
					<div class="container-login100-form-btn">
						<div class="wrap-login100-form-btn">
							<div class="login100-form-bgbtn"></div>
                            <!--
							<button class="login100-form-btn">
								Login
							</button>-->
                          
                                <asp:Button class="login100-form-btn" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Style="background-color:none" />
                       
                            
						</div>
					</div>

					<div class="txt1 text-center p-t-54 p-b-20">
						<span style="line-height: 95%;">
							Create your own <a href="http://localhost:60104/Registration/Registration.aspx" style="text-decoration: underline;text-transform: uppercase;font-weight: bold;">account</a> <br>
                            Or Sign Up Using
						</span>
					</div>
    
					<div class="flex-c-m">
						<a href="#" class="login100-social-item bg1">
							<i class="fa fa-facebook"></i>
						</a>

						<a href="#" class="login100-social-item bg2">
							<i class="fa fa-twitter"></i>
						</a>

						<a href="#" class="login100-social-item bg3">
							<i class="fa fa-google"></i>
						</a>
					</div>

					<div class="flex-col-c p-t-155">
						<span class="txt1 p-b-17">
							Or Sign Up Using
						</span>

						<a href="#" class="txt2">
							Sign Up
						</a>
					</div>
</asp:Content>
