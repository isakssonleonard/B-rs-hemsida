<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Börs_hemsida.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JE-banken</title>
    <link href="CSS/custom.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="main-header">
            <a id="logo" href="index.aspx">
                <h1>JE-bankens börs</h1>
            </a>
            <nav class="navigation">
                <ul id="nav-links">
                    <li>Nyheter</li>
                    <li>Opinon</li>
                    <li>Aktietjänster</li>
                    <li>Börssnack</li>
                    <li>Mer</li>
                </ul>
            </nav>
            <nav id="börs-navigation">
                <asp:Repeater ID="Repeater1" runat="server">
                   <ItemTemplate>
                       <div class="börser" style="color: orangered">
                            <asp:LinkButton ID="Text" runat="server" Text="<%#Container.DataItem%>" OnClick="button_OnClick"></asp:LinkButton>
                       </div>
                    </ItemTemplate>
                </asp:Repeater>
            </nav>
        </header>
        <div id="wrapper">
            <div class="choose-section">
                <asp:Label ID="Label2" runat="server" Text="Aktieslag"></asp:Label>
                <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                <asp:GridView ID="GridView" runat="server" CssClass="auto-style1" Width="350px">
                <HeaderStyle BackColor="Lime" />
                <RowStyle BorderColor="Black" />
            </asp:GridView>
            </div>
        </div>
        <footer class="main-footer">
            <img src="Pictures/facebook-wrap.png" alt="Logo" />
            <img src="Pictures/instagram-wrap.png" alt="Logo" />
            <img src="Pictures/twitter-wrap.png" alt="Logo" />
            <% Response.Write("<p>" + DateTime.Now.ToShortDateString() + "</p>"); %>
        </footer>
    </form>
</body>
</html>
