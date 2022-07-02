using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Catalogo
    {
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public Stack<string> Imagenes { get; set; }

        public string Mostrar()
        {
            string imgs = "";
            int contadador = 0;
            if (Imagenes != null)
            {
                contadador = Imagenes.Count;
                imgs = "" + contadador;
            }
            else
                imgs = "Ningun elmento";

            
            return "Catalogo:" +
                " Marca: " + Marca +
                " Categoria: " + Categoria +
                " Imagenes: " + imgs;
        }
    }
}
