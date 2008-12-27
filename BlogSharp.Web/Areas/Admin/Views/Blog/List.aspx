<%@ Page Title="" Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewPage`1[[System.Collections.Generic.List`1[[BlogSharp.Model.IBlog, BlogSharp.Model]], mscorlib]]" %>
<%@ Import Namespace="BlogSharp.Model"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Blog Overview</h2>
	<table>
		<tr>
			<td>
				Name
			</td>
		</tr>
		<%--
		<% foreach (var blog in ViewData.Model)
		 { %>
		<tr><td><%=blog.Name %></td></tr>
		<%} %>
		--%>
	</table>
</asp:Content>
