<%@ Page Title="" Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="BlogSharp.Web.Areas.Admin.Controllers"%>
<%@ Import Namespace="MvcContrib.UI.Html" %>
<%@ Import Namespace="MvcContrib.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Blog Detail</h2>
	<table>
		<tr>
			<td>
				Name
			</td>
			<td><%=Html.TextBox("blog.Name") %>
			</td>
		</tr>
		<tr>
			<td>
			</td>
			<td>
			</td>
		</tr>
		<tr>
			<td>
				<input type="submit" id="btnSave" value="Save" />
			</td>
		</tr>
	</table>
</asp:Content>
