<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.domain" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
            <% var departments = ((IEnumerable<Department>)this.Context.Items["blah"]);

               foreach (var department in departments)
               {

%>
		<!-- for each of the main departments in the store -->
        	<tr class="ListItem">
               		 <td>                     
                     <%= department.name %>
                	</td>
           	 </tr>        
           	 <%
               }%>
	    </table>            
</asp:Content>
