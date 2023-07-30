<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Crud_asp.net.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Name:</td>
                    <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
                </tr>  <tr>
                    <td>Age:</td>
                    <td><asp:TextBox ID="textAge" runat="server"></asp:TextBox></td>
                </tr>
                  <tr>
                    <td>Gender:</td>
                    <td><asp:RadioButtonList ID="rbl" runat="server" RepeatColumns="3">
                        <asp:ListItem Text="Male" Selected="True"  Value="1"></asp:ListItem>
                         <asp:ListItem Text="FeMale" Selected="True"  Value="2"></asp:ListItem>
                         <asp:ListItem Text="other" Selected="True"  Value="3"></asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                  <tr>
                    <td>Address:</td>
                    <td><asp:TextBox ID="textAddress" runat="server"></asp:TextBox></td>

                </tr>
                 <tr>
                    <td></td>
                    <td><asp:Button ID="btnsave" Text="save" runat="server" OnClick="btnsave_Click"></asp:Button></td>

                </tr>
                  <tr>
                    <td></td>
                    <td><asp:GridView ID="grdview" runat="server" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false">
                     <Columns>
                         <asp:TemplateField HeaderText="Name">
                             <ItemTemplate>
                                 <%#Eval("Name") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                     
                          
                         <asp:TemplateField HeaderText="Age">
                             <ItemTemplate>
                                 <%#Eval("Age") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                     
                          
                         <asp:TemplateField HeaderText="Gender">
                             <ItemTemplate>
                                 <%#Eval("Gender") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                     
                         
                         <asp:TemplateField HeaderText="Address">
                             <ItemTemplate>
                                 <%#Eval("Address") %>
                             </ItemTemplate>
                         </asp:TemplateField>
                 
                         <asp:TemplateField HeaderText="Action">
                             <ItemTemplate>
                               <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="AA" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Action">
                             <ItemTemplate>
                               <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="BB" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>
                            
                     </Columns>

                        </asp:GridView></td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
