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

        CConexion objetoConeccionBaseDatos = new CConexion();
        
        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void btnMigracion_Click(object sender, EventArgs e)
        {
            txtInfo.Clear();

            EscribirLog("🔌 Estado conexión: " + objetoConeccionBaseDatos.estadoConexion);

          
            LimpiarTablas();
            CargarCategorias();
            CargarArticulos();
        }

        public void CargarCategorias()
        {
            string ruta = "Categorias.txt";
            objetoConeccionBaseDatos.ConectarBaseDatos();
            try
            {
                EscribirLog("📂 Leyendo Categorias...");

                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea = sr.ReadToEnd();
                    string[] categorias = linea.Split(',');

                    foreach (string categoria in categorias)
                    {
                        try
                        {
                            string query = "INSERT INTO Categorias (Nombre) VALUES (?)";

                            using (OleDbCommand cmd = new OleDbCommand(query, objetoConeccionBaseDatos.conectorBaseDatos))
                            {
                                cmd.Parameters.AddWithValue("@Nombre", categoria.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            EscribirLog($"✔ Categoria insertada: {categoria}");
                        }
                        catch (Exception ex)
                        {
                            EscribirLog($"❌ Error insertando categoria '{categoria}': {ex.Message}");
                        }
                    }
                }

                EscribirLog("✅ Carga de categorias finalizada");
            }
            catch (Exception ex)
            {
                EscribirLog("❌ Error general: " + ex.Message);
            }
        }
        public void CargarArticulos()
        {
            string ruta = "Articulos.txt";
            objetoConeccionBaseDatos.ConectarBaseDatos();
            try
            {
                EscribirLog("📂 Leyendo Articulos...");

                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        try
                        {
                            string[] datos = linea.Split(',');

                            if (datos.Length != 4)
                            {
                                EscribirLog($"⚠ Línea inválida: {linea}");
                                continue;
                            }

                            int idArticulo = int.Parse(datos[0]);
                            string Nombre = datos[1];
                            int idCategoria = int.Parse(datos[2]);
                            double precio = double.Parse(datos[3]);

                            string query = "INSERT INTO Articulos (idArticulo, Nombre, IdCategoria, Precio) VALUES (?, ?, ?, ?)";

                            using (OleDbCommand cmd = new OleDbCommand(query, objetoConeccionBaseDatos.conectorBaseDatos))
                            {
                                cmd.Parameters.AddWithValue("@idArticulo", idArticulo);
                                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                                cmd.Parameters.AddWithValue("@Precio", precio);

                                cmd.ExecuteNonQuery();
                            }

                            EscribirLog($"✔ Artículo insertado: {Nombre}");
                        }
                        catch (Exception ex)
                        {
                            EscribirLog($"❌ Error en línea '{linea}': {ex.Message}");
                        }
                    }
                }

                EscribirLog("✅ Carga de artículos finalizada");
            }
            catch (Exception ex)
            {
                EscribirLog("❌ Error general: " + ex.Message);
            }
        }

        private void EscribirLog(string mensaje)
        {
            txtInfo.AppendText(mensaje + Environment.NewLine);
        }
        public void LimpiarTablas()
        {
            objetoConeccionBaseDatos.ConectarBaseDatos();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM Categorias", objetoConeccionBaseDatos.conectorBaseDatos);
            OleDbCommand cmd2 = new OleDbCommand("DELETE FROM Articulos", objetoConeccionBaseDatos.conectorBaseDatos);
            cmd.ExecuteNonQuery();
        }
    }
}
