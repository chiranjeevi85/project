<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CurrencyConverterApp._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .content {
            margin-top: 50px;
        }

        .labelstyle {
            width: 16%;
            padding: 6px 6px;
            margin: 8px 0;
        }

        .labelstyle2 {
            width: 16%;
            padding: 6px 6px;
            float: left;
            margin-top: 10px;
        }

          .labelstyle3 {
            width: 16%;
            padding: 6px 6px;
            margin-top: 10px;
            color:red;
        }

        .inputtextbox {
            width: 16%;
            padding: 6px 6px;
            margin: 8px 0;
            box-sizing: border-box;
        }

        .combobox {
            width: 16%;
            padding: 6px 6px;
            margin: 8px 13px;
            box-sizing: border-box;
        }

        .buttonstyle {
            width: 10%;
            padding: 6px 6px;
            margin-left: 8%;
        }
    </style>
    <div class="content">
        <asp:Label ID="Label1" runat="server" Text="Enter The Amount" CssClass="labelstyle"></asp:Label>
        :

        <asp:TextBox ID="TextBox1" runat="server" CssClass="inputtextbox"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Convertion To GBP" CssClass="labelstyle"></asp:Label>
        :

        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="combobox">
            <asp:ListItem Enabled="true" Text="Select Currency" Value="-1"></asp:ListItem>
            <asp:ListItem Text="USD" Value="1"></asp:ListItem>
            <asp:ListItem Text="AUD" Value="2"></asp:ListItem>
            <asp:ListItem Text="EUR" Value="3"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Convert" CssClass="buttonstyle" OnClick="CurrencyConvertor_Click" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Convertion Rate: " CssClass="labelstyle2"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="" CssClass="labelstyle2"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="" CssClass="labelstyle3"></asp:Label>
    </div>

    <span>------------------------------------------------------------------------------------------------</span>
    <br />
    <br />
    <br />

    <div>Audit Report</div>
    <asp:Label ID="Label6" runat="server" Text="Select Start and End Date To Get The Report" CssClass="labelstyle"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" textmode="Date" CssClass="inputtextbox"></asp:TextBox>
    <asp:TextBox ID="TextBox3" runat="server" textmode="Date" CssClass="inputtextbox"></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Generate Report" CssClass="buttonstyle" OnClick="GenerateReport_Click" />

    <br />
    <br />

    <asp:Table ID="myTable" runat="server" Width="100%"> 
    <asp:TableRow>
        <asp:TableCell>Number of User Did Converation</asp:TableCell>
    </asp:TableRow>
</asp:Table>  
    

</asp:Content>
