<%@ Page Title="" Language="C#" MasterPageFile="../Shared/Site.Master" AutoEventWireup="true"
	Inherits="System.Web.Mvc.ViewPage`1[[BlogSharp.Model.IBlog, BlogSharp.Model]]" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Blog Detail</h2>
	<form action="/Admin/Blog/Save">
	<input type="hidden" name="id" value="<%=ViewData.Model.Id %>" />
	<table>
		<tr>
			<td>
				Name
			</td>
			<td>
				<input type="text" name="name" maxlength="50" value="<%=ViewData.Model.Name %>" />
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
	</form>
</asp:Content>
