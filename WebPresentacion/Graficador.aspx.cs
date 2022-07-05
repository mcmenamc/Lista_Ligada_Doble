using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaNegocio;
using ClassEntidades;
using System.Threading;
using System.Drawing.Imaging;

namespace WebPresentacion
{
    public partial class Graficador : System.Web.UI.Page
    {
        LogicaN bl = new LogicaN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["BL"] != null)
            {
                bl = (LogicaN)Session["BL"];

            }
            List<Catalogo> cata = new List<Catalogo>();
            cata = bl.MostrarCatalogos();
            Bitmap imagen1 = new Bitmap(1290, 1080);
            Graphics hoja = Graphics.FromImage(imagen1);
            Dibuja(hoja, imagen1.Width, imagen1.Height, cata);
            Response.ContentType = "image/jpeg";
            imagen1.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();

        }
        public void Dibuja(Graphics panel, int dimx, int dimy, List<Catalogo> catapunta)
        {
            panel.FillRectangle(new SolidBrush(Color.FromArgb(156, 220, 180)), new Rectangle(0, 0, dimx, dimy));
            Pen pen = new Pen(Color.BlueViolet);
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush brushRed = new SolidBrush(Color.Red);
            SolidBrush brushBlue = new SolidBrush(Color.Blue);
            SolidBrush brushWhite = new SolidBrush(Color.White);
            Pen GreenHard = new Pen(Color.DarkGreen, 9);
            int x1 = 10, y1 = 10;

            for (int i = 1; i <= catapunta.Count; i++)
            {

                panel.FillEllipse(brush, new Rectangle((x1 + 22), (y1 + 95), 10, 10));
                panel.FillEllipse(brush, new Rectangle((x1 + 170), (y1 + 95), 10, 10));

                panel.FillRectangle(brushBlue, new Rectangle(x1, y1, 200, 100));
                panel.FillRectangle(brushWhite, new Rectangle(x1, y1, 150, 100));
                panel.FillRectangle(brushRed, new Rectangle(x1, y1, 50, 100));

                panel.DrawRectangle(pen, x1, y1, 200, 100);
                panel.DrawRectangle(pen, (x1), (y1), 50, 100);
                panel.DrawRectangle(pen, (x1), (y1), 150, 100);


                panel.DrawLine(GreenHard, 37, y1 + 105, 37, y1 + 130);
                panel.DrawLine(GreenHard, 185, y1 + 105, 185, y1 + 130);
                panel.DrawString(catapunta[i - 1].Marca, new Font("Verdana", 11), brush, x1 + 50, y1);
                panel.DrawString(catapunta[i - 1].Categoria, new Font("Verdana", 11), brush, x1 + 50, y1 + 10);

                if (i % 6 == 0)
                {

                    panel.DrawLine(GreenHard, x1 + 27, y1 + 130, x1 + 27, y1 + 160);
                    panel.DrawLine(GreenHard, x1 + 25, y1 + 160, 280, y1 + 160);
                    panel.DrawLine(GreenHard, 250, 0, 250, y1 + 130);
                    panel.DrawLine(GreenHard, 280, 60, 280, y1 + 160);

                    panel.DrawLine(GreenHard, x1 + 240, 0, 470, 0);
                    panel.DrawLine(GreenHard, x1 + 460, 10, 470, 0);
                    panel.DrawLine(GreenHard, x1 + 270, 60, 290, 60);
                    panel.DrawLine(GreenHard, x1 + 240, y1 + 130, 185, y1 + 130);

                    y1 = 10;
                    x1 = 290;

                }
                else
                {
                    y1 = y1 + 130;
                }
            }

        }

    }
}