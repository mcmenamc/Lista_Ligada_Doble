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


        public NodoLista BuscarCatalogo(string marca, string categoria)
        {
            NodoLista reco = raiz;
            NodoLista busca = null;
            while (reco != null)
            {
                if (reco.info.Marca == marca && reco.info.Categoria == categoria)
                {
                    busca = reco;
                    break;
                }
                reco = reco.sig;
            }
            return busca;
        }

        public string CambiarImagenes(Catalogo info)
        {
            NodoLista catalogo = null;
            catalogo = BuscarCatalogo(info.Marca, info.Categoria);
            if (catalogo == null)
            {
                return "No se encontro el catalogo";
            }
            else
            {
                catalogo.info.Imagenes = info.Imagenes;
                return "Se cargaron las imagenes";
            }
        }

        public string[] MostrarImagenes(string marca, string categoria)
        {
            string[] mostras = null;
            Stack<string> busca = new Stack<string>();
            NodoLista catalogo = null;
            catalogo = BuscarCatalogo(marca, categoria);
            if (catalogo != null)
            {
                busca = catalogo.info.Imagenes;
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
            NodoLista catalogo = null;
            Stack<string> imgNuevas = new Stack<string>();
            catalogo = BuscarCatalogo(marca, categoria);
            if (catalogo == null)
            {
                return "No se encontro el catalogo";
            }
            else
            {
                int contador = 1;
                if (posi > 0 && posi <= catalogo.info.Imagenes.Count)
                {
                    foreach (string img in catalogo.info.Imagenes)
                    {
                        if (contador != posi)
                        {
                            imgNuevas.Push(img);
                        }
                        contador++;
                    }
                    catalogo.info.Imagenes = imgNuevas;
                    return "Se modificaron las imagenes";
                }
                else
                    return "Fuera de los limites de las imagenes";
            }
        }
        
        public Boolean Eliminar(string marca, string categoria)
        {
            NodoLista catalogo = null;
            NodoLista antes = null;
            Boolean mensaje;
            catalogo = BuscarCatalogo(marca, categoria);
            if (catalogo == null)
            {
                return false;
            }
            else
            {
                mensaje = true;
                if (raiz.sig == null)
                {
                    raiz = null;
                }
                else
                {
                    if (catalogo.sig == null)
                    {
                        antes = catalogo.ant;
                        antes.sig = null;
                    }
                    else
                    {
                        if (catalogo.ant == null && catalogo.sig != null)
                        {
                            raiz = raiz.sig;
                            raiz.ant = null;
                        }
                        else
                        {
                            if (catalogo.sig != null && catalogo.ant != null)
                            {
                                antes = catalogo.ant;
                                antes.sig = catalogo.sig;
                                catalogo.sig.ant = antes;
                            }
                        }
                    }
                }
            }
            return mensaje;
        }
    }
}
