<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.web.application.catalogbrowing" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
                  <% foreach (var department in this.report)
                     {%>
              <tr class="ListItem">
               <td><a href="<%= Url.to.run_conditionally<ViewTheDepartmentsInADepartmentRequest>()
                                      .or<ViewTheProductsInADepartmentRequest>()
                                      .based_on(department.has_products)
                                      .include(department, config => config.include(x => x.id));
               
               %>"><%= department.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
