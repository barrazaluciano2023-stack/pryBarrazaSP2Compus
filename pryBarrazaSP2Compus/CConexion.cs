using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.OleDb;

namespace pryBarrazaSP2Compus
{
    internal class CConexion
    {
        public OleDbConnection CNN;
        public DataSet DS;
        private string ERROR = "";

        // Constructor: inicializa los objetos en null [3]
        public CConexion()
        {
            CNN = new OleDbConnection();
            DS = new DataSet();
        }
        // Método "Universal": Recibe la cadena de conexión por parámetro [7]
        public bool Conectar(string Cadena)
        {
            bool resultado = false;
            CNN.ConnectionString = Cadena;
            try
            {
                CNN.Open(); // Abre la sesión física [8]
                DS = new DataSet(); // Crea el contenedor de tablas en memoria [7, 9]
                resultado = true;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message; // Captura errores de ruta o permisos [7]
            }
            return resultado;

        }
        public string ObtenerError() { return ERROR; }
    }
}
