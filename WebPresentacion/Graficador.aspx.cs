using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaNegocio;
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

            Bitmap imagen1 = new Bitmap(1290, 1080);
            Graphics hoja = Graphics.FromImage(imagen1);
            Dibuja(hoja, imagen1.Width, imagen1.Height);
            Response.ContentType = "image/jpeg";
            imagen1.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
        }
        public void Dibuja(Graphics papel, int dimx, int dimy)
        {
            Pen lapiz = new Pen(Color.FromArgb(244, 217, 255), 1); // lapiz
            Color Rosa = Color.FromArgb(244, 217, 255);
            SolidBrush Brocha = new SolidBrush(Color.Black); // Brocha Verde 
            Font Times = new Font("Times", 8); // tipografia 
            papel.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(0, 0, dimx, dimy)); // fondo de mi imagen

        }

    }
}