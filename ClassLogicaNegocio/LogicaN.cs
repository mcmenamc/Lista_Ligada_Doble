using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
using ClassEntidades;

namespace ClassLogicaNegocio
{
    public class LogicaN
    {
        private ClassLista objDAL = new ClassLista();
        public void InsertarCatalogo(Catalogo catalogo, int pos)
        {
            objDAL.Insertar(catalogo, pos);
        }
        public List<Catalogo> MostrarCatalogos()
        {
            return objDAL.Mostrar();
        }
        public Catalogo BuscarCatalogo(string marca, string categoria)
        {
            return objDAL.BuscarCatalogo(marca, categoria);
        }
        public string CambiarImagenes(Catalogo catalogo)
        {
            return objDAL.CambiarImagenes(catalogo);
        }
        public string[] MostrarImagenes(string marca, string categoria)
        {
            return objDAL.MostrarImagenes(marca, categoria);
        }
        public string EliminarImagen(string marca, string categoria, int posi) {
            return objDAL.EliminarImagen(marca, categoria, posi);
        }
        public string EliminaNodo(string marca, string categoria)
        {
            return objDAL.Eliminar(marca, categoria);
        }
    }
}
