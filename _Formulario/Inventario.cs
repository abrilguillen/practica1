using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Formulario
{
    class Inventario
    {
        //se crea un arreglo de tipo producto que lleva por nombre inventario 
        private Producto[] _inventario;

        //almacena el indice que tienen los productos (numero de productos)
        private int _indiceProducto;
        
        /// <summary>
        /// Coonstructor que inicializa el arreglo y el indice
        /// </summary>
        public Inventario()
        {
            _inventario = new Producto[20];
            _indiceProducto = 0;
        }

        public override string ToString()
        {
            return "Total de productos: " + _indiceProducto;
        }

        /// <summary>
        /// agregar un producto tiene un parametro un objeto de tipo producto
        /// </summary>
        /// <param name="producto"></param>
        public void agregarProducto(Producto producto)
        {
            if (_indiceProducto < 20)
            {
                //inventario en el indice 0 sea agrega el producto
                _inventario[_indiceProducto] = producto;
                
                //se aumemta un producto
                _indiceProducto++;
            }
        }

        /// <summary>
        /// Este metodo obtiene el indice de un producto
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private int obtenerIndiceProducto(string nombre)
        {
            //recorre desde 0 hasta el total de productos que tengas
            for (int index = 0; index < _indiceProducto; index++)
            {
                //en la posicion que coincida el nombre del producto
                if (_inventario[index].nombre == nombre)
                {
                    //retorna la posicion en la que se encuentra
                    return index;
                }
            }

            return -250;
        }

        /// <summary>
        /// se busca y se pasa de parametro el nombre del producto
        /// y se retorna el producto como tal.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Producto buscar(string nombre)
        {
            //obtinees el indice del producto
            int index = obtenerIndiceProducto(nombre);


            if (index >= 0)
            {
                //retorna el producto que este en el indice determinado
                return _inventario[index];
            }
            //retorna nulo (no se encontro)
            return null;
        }

        /// <summary>
        /// al eliminar se pasa de parametro el nombre
        /// </summary>
        /// <param name="nombre"></param>
        public void eliminar(string nombre)
        {
            //obtinees el indice del producto
            int index = obtenerIndiceProducto(nombre);

            //si el indice el mayor que cero
            if(index >= 0)
            {
                //iteras sobre los productos
                for (int i = index; i < _indiceProducto - 1; i++)
                {
                    _inventario[i] = _inventario[i + 1];
                }

                //se elimina el producto
                _inventario[_indiceProducto - 1] = null;

                //se le resta uno al indice (del que se borró)
                _indiceProducto--;
            }
        }

        public void insertar(Producto producto, int posicion)
        {
            //si la posicion es menor al total de productos
            if (posicion < _indiceProducto)
            {
                for (int index = _indiceProducto - 1; index >= posicion; index--)
                {
                    _inventario[index] = _inventario[index - 1];
                }

                //se agrega el rpoducto en la posicio determinada
                _inventario[posicion] = producto;
            }
        }

        public string reporte()
        {
            string mostrar = ToString() + Environment.NewLine;

            for (int index = 0; index < _indiceProducto; index++)
            {
                mostrar += "################################################" + "\n";
                mostrar += _inventario[index].ToString();
            }

            return mostrar;
        }
    }
}
