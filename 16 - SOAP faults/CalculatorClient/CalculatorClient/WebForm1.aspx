<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CalculatorClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="font-family:Arial; border:1px solid black">
                <tr>
                    <td>
                        <b>Numerator:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumerator" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Denominator:</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDenominator" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDivide" runat="server" Text="Divide" Font-Bold="True"                                   onclick="btnDivide_Click" />
                    </td>  
                    <td>
                        <asp:Label ID="lblResult" runat="server" Font-Bold="true">
                        </asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
