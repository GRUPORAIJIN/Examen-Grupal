using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDato;

namespace CapaNegocio
{
    public class Categoria
    {
        private Datos datos = new DatosSQL();
        //declarar un atributo y propiedad para el mensaje del PA
        private string mensaje;

        public string Mensaje
        {
            get { return mensaje; }
        }

        private int idCategoria;
        private string nombreCategoria;
        private string descripcion;
        private byte[] image;
        public int IdCategoria { get => idCategoria; set => idCategoria = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public byte[] Image { get => image; set => image = value; }

        public DataSet ListarCate()
        {
            return datos.TraerDataSet("spListarCategorias");
        }
        public bool Agregar()
        {
            //Traer los datos de la consulta
            DataRow fila = datos.TraerDataRow("spCategoriaAgregar", idCategoria, nombreCategoria, descripcion,image );
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }
        public bool Actualizar()
        {
            //Traer los datos de la consulta
            DataRow fila = datos.TraerDataRow("spCategoriaActualizar", idCategoria, nombreCategoria, descripcion, image);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }
        public bool Eliminar()
        {
            //Traer los datos de la consulta
            DataRow fila = datos.TraerDataRow("spCategoriaEliminar", idCategoria);
            byte codError = Convert.ToByte(fila["CodError"]);
            mensaje = fila["Mensaje"].ToString();
            if (codError == 0) return true;
            else return false;
        }
        public DataSet Buscar(string texto, string criterio)
        {
            return datos.TraerDataSet("spBuscarBuscar", texto, criterio);
        }
    }
}
