using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassEntidades;

namespace ClassDAL
{
    public class ClassLista
    {
        private NodoLista raiz;

        public ClassLista()
        {
            raiz = null;
        }
        public void Insertar(Catalogo info, int pos)
        {
            if (pos <= Cantidad() + 1)
            {
                NodoLista nuevo = new NodoLista();
                nuevo.info = info;
                if (pos == 1)
                {
                    nuevo.sig = raiz;
                    if (raiz != null)
                        raiz.ant = nuevo;
                    raiz = nuevo;
                }
                else
                {
                    if (pos == Cantidad() + 1)
                    {
                        NodoLista reco = raiz;
                        while (reco.sig != null)
                        {
                            reco = reco.sig;
                        }
                        reco.sig = nuevo;
                        nuevo.ant = reco;
                        nuevo.sig = null;
                    }
                    else
                    {
                        NodoLista reco = raiz;
                        for (int x = 1; x <= pos - 2; x++)
                            reco = reco.sig;
                        NodoLista siguiente = reco.sig;
                        reco.sig = nuevo;
                        nuevo.ant = reco;
                        nuevo.sig = siguiente;
                        siguiente.ant = nuevo;
                    }
                }
            }
        }
        private int Cantidad()
        {
            int cant = 0;
            NodoLista reco = raiz;
            while (reco != null)
            {
                reco = reco.sig;
                cant++;
            }
            return cant;
        }

        public List<Catalogo> Mostrar()
        {
            List<Catalogo> lista = new List<Catalogo>();

            NodoLista reco = raiz;
            while (reco != null)
            {
                lista.Add(reco.info);
                reco = reco.sig;
            }
            return lista;
        }


        public Catalogo BuscarCatalogo(string marca, string categoria)
        {
            NodoLista reco = raiz;
            Catalogo busca = null;
            while (reco != null)
            {
                if (reco.info.Marca == marca && reco.info.Categoria == categoria)
                {
                    busca = reco.info;
                    break;
                }
                reco = reco.sig;
            }
            return busca;
        }

        public string CambiarImagenes(Catalogo info)
        {
            Catalogo catalogo = null;
            catalogo = BuscarCatalogo(info.Marca, info.Categoria);
            if (catalogo == null)
            {
                return "No se encontro el catalogo";
            }
            else
            {
                catalogo.Imagenes = info.Imagenes;
                return "Se cargaron las imagenes";
            }
        }

        public string[] MostrarImagenes(string marca, string categoria)
        {
            string[] mostras = null;
            Stack<string> busca = new Stack<string>();
            Catalogo catalogo = null;
            catalogo = BuscarCatalogo(marca, categoria);
            if (catalogo != null)
            {
                busca = catalogo.Imagenes;
                mostras = new string[busca.Count];
                int x = 0;
                foreach (string img in busca)
                {
                    mostras[x] = img;
                    x++;
                }
                return mostras;
            } else
                return mostras;
        }

        public string EliminarImagen(string marca, string categoria, int posi)
        {
            Catalogo catalogo = null;
            Stack<string> imgNuevas = new Stack<string>();
            catalogo = BuscarCatalogo(marca, categoria);
            if (catalogo == null)
            {
                return "No se encontro el catalogo";
            }
            else
            {
                int contador = 1;
                if (posi > 0 && posi <= catalogo.Imagenes.Count)
                {
                    foreach (string img in catalogo.Imagenes)
                    {
                        if (contador != posi)
                        {
                            imgNuevas.Push(img);
                        }
                        contador++;
                    }
                    catalogo.Imagenes = imgNuevas;
                    return "Se modificaron las imagenes";
                }
                else
                    return "Fuera de los limites de las imagenes";
            }
        }
        
        public string Eliminar(string marca, string categoria)
        {
           
                int pos = EncuentraPosi(marca, categoria);
                if (pos <= Cantidad())
                {
                    if (pos == 1)
                    {
                        raiz = raiz.sig;
                        if (raiz != null)
                            raiz.ant = null;
                    }
                    else
                    {
                        NodoLista reco = null;
                        reco = raiz;
                        for (int f = 1; f <= pos - 2; f++)
                            reco = reco.sig;
                        if (reco == null)
                            return "No se encontro el nodo";
                        NodoLista prox = reco.sig;
                        prox = prox.sig;
                        reco.sig = prox;
                        if (prox != null)
                            prox.ant = reco;
                    }
                }
                return "Se elimino el nodo";
            
        }
        private int EncuentraPosi(string marca, string categoria)
        {
            int contador = 0;
            NodoLista reco = raiz;
            while (reco != null)
            {
                contador++;
                if (reco.info.Marca == marca && reco.info.Categoria == categoria)
                    return contador;
                reco = reco.sig;
            }
            return contador;
        }
    }
}
