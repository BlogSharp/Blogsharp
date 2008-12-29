<%@ Page Title="" Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewPage`1[[System.Collections.Generic.List`1[[BlogSharp.Model.IBlog, BlogSharp.Model]], mscorlib]]" %>
<%@ Import Namespace="BlogSharp.Model"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Blog Overview</h2>
		<a href="Blog/Detail">New Blog</a>
	<table>
		<tr>
			<td>
				<b>Name</b>
			</td>
		</tr>
		
		<% foreach (var blog in ViewData.Model)
		 { %>
		<tr><td><a href="Blog/Detail/<%=blog.Id %>"><%=blog.Name %></a></td></tr>
		<%} %>
		
	</table>
</asp:Content>
