<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insertar.aspx.cs" Inherits="WebPresentacion.Insertar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="msg" runat="server" Text="Mensajes"></asp:Label>
        <div>
            <h2>Insertar consecutiva</h2>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Categoria:"></asp:Label>
            <asp:TextBox ID="TxtCategoria" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Marca:"></asp:Label>
            <asp:TextBox ID="TxtMarca" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insertar Consecutivo" OnClick="Button1_Click" />
        </div>
        <br />

        <div>
            <h2>Insertar por posición</h2>
            <asp:Label ID="Label3" runat="server" Text="Posición:"></asp:Label>
            <asp:TextBox ID="TxtPosi" type="number" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Insertar por posición" OnClick="Button2_Click" />

        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <h2>Mostrar</h2>

        <asp:Button ID="Button6" runat="server" Text="Mostrar" OnClick="Button6_Click" />
        <asp:ListBox ID="ListBox1" runat="server" Style="margin-right: 736px" Width="949px"></asp:ListBox>
        <br />
        <br />
        <div>
            <h2>Buscar</h2>
            <asp:Label ID="Label5" runat="server" Text="Categoria:"></asp:Label>
            <asp:TextBox ID="txtCategoriaB" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Marca:"></asp:Label>
            <asp:TextBox ID="txtMarcaB" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" Text="Busca" OnClick="Button3_Click" />
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
        <div>
            <h2>Cambiar de imagenes</h2>
            <asp:Label ID="Label7" runat="server" Text="Categoria:"></asp:Label>
            <asp:TextBox ID="txtCategoriaC" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Marca:"></asp:Label>
            <asp:TextBox ID="txtMarcaC" runat="server"></asp:TextBox>

            <br />
            <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Cambiar Imagenes" OnClick="Button4_Click" />
        </div>

        <div>
            <h2>Mostrar imagenes</h2>

            <asp:Label ID="Label9" runat="server" Text="Categoria:"></asp:Label>
            <asp:TextBox ID="txtCategoriaI" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Marca:"></asp:Label>
            <asp:TextBox ID="txtMarcaI" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="Mostar Imagenes" OnClick="Button5_Click" />

            <br />
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <h2>Eliminar imagenes</h2>
            <asp:Label ID="Label12" runat="server" Text="Categoria:"></asp:Label>
            <asp:TextBox ID="txtCategoriaE" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label13" runat="server" Text="Marca:"></asp:Label>
            <asp:TextBox ID="txtMarcaE" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label14" runat="server" Text="Posición:"></asp:Label>
            <asp:TextBox ID="txtnumber" type="number" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button7" runat="server" Text="Eliminar Imagen" OnClick="Button7_Click" />

        </div>
        <div>
            <h2>Eliminar Nodo</h2>
            <asp:Label ID="Label15" runat="server" Text="Categoria:"></asp:Label>
            <asp:TextBox ID="txtCategoriaEN" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label16" runat="server" Text="Marca:"></asp:Label>
            <asp:TextBox ID="txtMarcaEN" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button8" runat="server" Text="Eliminar Nodo" OnClick="Button8_Click" />

        </div>
        <div>
            <h2>Graficador</h2>
                <img width="1300" src="../Graficador.aspx"  />
        </div>
    </form>
</body>
</html>
