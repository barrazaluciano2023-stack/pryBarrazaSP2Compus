using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryBarrazaSP2Compus
{
    public partial class frmPrincipal : Form
    {
        private CConexion miConexion;
        public frmPrincipal()
        {

            InitializeComponent();
        }
        // Método genérico para leer archivos y ejecutar el Grabar de tu clase
        private int ProcesarTxt(CConexion conexion, string nombreArchivo, string tabla)
        {
            int contador = 0;
            // StreamReader requiere: using System.IO;
            using (StreamReader lector = new StreamReader(nombreArchivo))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    string[] campos = linea.Split(','); // O el separador que usen tus archivos
                    string sql = "";

                    if (tabla == "Categorias")
                    {
                        // IdCategoria, Nombre
                        sql = $"INSERT INTO Categorias VALUES ({campos[0]}, '{campos[1]}')";
                    }
                    else
                    {
                        // IdArticulo, Nombre, IdCategoria, Precio
                        sql = $"INSERT INTO Articulos VALUES ({campos[0]}, '{campos[1]}', {campos[2]}, {campos[3]})";
                    }

                    if (conexion.Grabar(sql)) contador++;
                }
            }
            return contador;
        }

        private void btnMigracion_Click(object sender, EventArgs e)
        {
            CConexion objBD = new CConexion();
            // Ajusta la ruta a donde tengas tu archivo .mdb
            string cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Distribuidora.accdb";

            OpenFileDialog selector = new OpenFileDialog();
            selector.Filter = "Bases de Datos Access (*.accdb; *.mdb)|*.accdb;*.mdb";
            txtInfo.Clear();

            if (objBD.Conectar(cadena))
            {
                // --- PROCESAR CATEGORÍAS ---
                txtInfo.AppendText("Migrando datos de Categorias...\r\n");
                int filasCat = ProcesarTxt(objBD, "Categorias.txt", "Categorias");
                txtInfo.AppendText($"Se incorporaron: {filasCat} registros nuevos.\r\n\r\n");

                // --- PROCESAR ARTÍCULOS ---
                txtInfo.AppendText("Migrando datos de Articulos...\r\n");
                int filasArt = ProcesarTxt(objBD, "Articulos.txt", "Articulos");
                txtInfo.AppendText($"Se incorporaron: {filasArt} registros nuevos.\r\n\r\n");

                txtInfo.AppendText("Migración finalizada.");
                objBD.Cerrar();
            }
            else
            {
                MessageBox.Show("Error de conexión: " + objBD.ObtenerError());
            }

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
