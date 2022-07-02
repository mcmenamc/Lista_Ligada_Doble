using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaNegocio;
using ClassEntidades;

namespace WebPresentacion
{
    public partial class Insertar : System.Web.UI.Page
    {
        LogicaN bl = new LogicaN();
        int countador = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BL"] != null && Session["count"] != null)
            {
                bl = (LogicaN)Session["BL"];
                countador = (int)Session["count"];
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bl.InsertarCatalogo(new Catalogo()
            {
                Categoria = TxtCategoria.Text,
                Marca = TxtMarca.Text,
                Imagenes = null
            }, countador);

            TxtCategoria.Text = "";
            TxtMarca.Text = "";

            msg.Text = "Se inserto en la posición " + countador;
            countador++;
            Session["count"] = countador;
            Session["BL"] = bl;

            Mostrar();
        }

        private void Mostrar()
        {
            ListBox1.Items.Clear();
            var catalogos = bl.MostrarCatalogos();
            foreach (Catalogo catalogo in catalogos)
            {
                ListBox1.Items.Add(catalogo.Mostrar());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            msg.Text = "";

            int posi = Convert.ToInt32(TxtPosi.Text);
            if (posi > 0)
                if (posi <= countador)
                {
                    bl.InsertarCatalogo(new Catalogo()
                    {
                        Categoria = TxtCategoria.Text,
                        Marca = TxtMarca.Text,
                        Imagenes = null
                    }, posi);
                    TxtCategoria.Text = "";
                    TxtMarca.Text = "";
                    TxtPosi.Text = "";
                    Session["BL"] = bl;
                    Mostrar();
                }
                else
                    msg.Text = "Solo acepta posiciones dentro del rango";
            else
                msg.Text = "Solo acepta posición mayor a 0";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            msg.Text = "";
            Catalogo busca = bl.BuscarCatalogo(txtMarcaB.Text, txtCategoriaB.Text);
            if (busca != null)
                Label4.Text = busca.Mostrar();
            else
                Label4.Text = "";
                msg.Text = "¡No se encontró los elementos!";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            msg.Text = "";
            if (!FileUpload1.HasFiles)
            {
                msg.Text = "Ningun archivo cargado";
            }
            else
            {

                if (FileUpload1.PostedFiles.Count > 0 && FileUpload1.PostedFiles.Count < 5)
                {
                    Stack<string> pila = new Stack<string>(4);

                    //int imagenes = 0;
                    foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                    {
                    
                        string nombreArchivo = System.IO.Path.GetFileName(FileUpload1.FileName);
                        string Ruta = Server.MapPath("imagenes") + "\\" + nombreArchivo;
                        try
                        {
                            pila.Push(nombreArchivo);
                            uploadedFile.SaveAs(Ruta);
                            //imagenes++;
                        }
                        catch (Exception ex)
                        {
                            msg.Text = "Error" + ex.Message;
                        }
                    }

                    msg.Text = bl.CambiarImagenes(new Catalogo()
                    {
                        Categoria = txtCategoriaC.Text,
                        Marca = txtMarcaC.Text,
                        Imagenes = pila
                    });
                    Mostrar();
                }
                else
                {
                    msg.Text = "¡Seleciona 1 hasta 4 imagenes";
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Label11.Text = "";
            string[] imagenes = bl.MostrarImagenes(txtMarcaI.Text, txtCategoriaI.Text);
            if (imagenes != null)
            {
                foreach (string img in imagenes)
                {
                    Label11.Text = Label11.Text + "<img width='350px' src='imagenes/" + img + "' /> </br>";
                    //Response.Write("<img src='imagenes/" + img + "' />");
                }
            }
            else
                Label11.Text = "Ninguna Imagen";

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            msg.Text = "";
            try
            {
                msg.Text = bl.EliminarImagen(txtMarcaE.Text, txtCategoriaE.Text, Convert.ToInt32(txtnumber.Text));
            }
            catch(Exception ex)
            {
                msg.Text = ex.Message;
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            bl.EliminaNodo("m1", "c1");
            countador--;
            Session["count"] = countador;
            Mostrar();
        }
    }
}