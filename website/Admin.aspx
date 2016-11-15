<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="global.css"/>
    <link rel="stylesheet" type="text/css" href="Admin.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <nav>
			<ul>
				<li><a href="Default.aspx">Logout</a></li>
                <li style="width:80%"></li>
			</ul>
		</nav>
    </header>
    <main>
        <section id="uploadSection">
            <h1>Upload an excel file</h1>
                <input id="fileUploadfield" type="file" runat="Server" />
                <br /><br />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" />
        </section>
        <section id="otherSection">
            <h1>List of Questions and Answers</h1>
            <table>
                <tbody>
                    <tr>
                        <td><asp:TextBox ID="TextBox1" runat="server" placeholder="Category" CssClass="manTxt"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox2" runat="server" placeholder="Question" CssClass="manTxt"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox3" runat="server" placeholder="True" CssClass="manTxt"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox4" runat="server" placeholder="False" CssClass="manTxt"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox5" runat="server" placeholder="False" CssClass="manTxt"></asp:TextBox></td>
                        <td><asp:TextBox ID="TextBox6" runat="server" placeholder="False" CssClass="manTxt"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="cat1" runat="server" Text="category" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="q1" runat="server" Text="This is a question" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a11" runat="server" Text="Right Answer" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a12" runat="server" Text="Wrong Answer" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a13" runat="server" Text="Wrong Answer" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a14" runat="server" Text="Wrong Answer" CssClass="FormText"></asp:Label></td>
                        <td><asp:Button ID="btnDelRow1" runat="server" Text="X" CssClass="delBtn"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="cat2" runat="server" Text="webdev" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="q2" runat="server" Text="contents of uploads will also appear here" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a21" runat="server" Text="Right" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a22" runat="server" Text="Yes" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a23" runat="server" Text="No Kidding" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a24" runat="server" Text="True" CssClass="FormText"></asp:Label></td>
                        <td><asp:Button ID="btnDelRow2" runat="server" Text="X" CssClass="delBtn"/></td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="cat3" runat="server" Text="Backend" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="q3" runat="server" Text="This will be a datagrid later" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a31" runat="server" Text="Right" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a32" runat="server" Text="Yes" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a33" runat="server" Text="Of course" CssClass="FormText"></asp:Label></td>
                        <td><asp:Label ID="a34" runat="server" Text="True" CssClass="FormText"></asp:Label></td>
                        <td><asp:Button ID="btnDelRow3" runat="server" Text="X" CssClass="delBtn"/></td>
                    </tr>
                </tbody>
            </table>
        </section>
    </main>
    </form>
</body>
</html>
