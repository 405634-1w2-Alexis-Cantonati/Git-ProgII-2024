using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Data
{
    internal class HelperDB
    {
        private SqlConnection conexion;
        private static HelperDB instance;
        public HelperDB()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-HUKFAHD\MSSQLSERVER01;
                                        Initial Catalog=DB_FACTURACION;Integrated Security=True");
        }
        public static HelperDB GetInstance()
        {
            if (instance == null)
            {
                instance = new HelperDB();
            }
            return instance;
        }
        public SqlConnection GetConnection()
        {
            return conexion;
        }
        public DataTable Consultar(string nombreSP)
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;

                dt.Load(comando.ExecuteReader());
                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine($"El DataTable está vacío después de la asignación.{"\n"}" +
                        $"Nombre del SP: {nombreSP}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la base de datos " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return dt;
        }
        public DataTable Consultar(string nombreSP, List<Parametros> Lparametros)
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = nombreSP;
                foreach (Parametros param in Lparametros)
                {
                    comando.Parameters.AddWithValue(param.Name, param.Value);
                }
                dt.Load(comando.ExecuteReader());
                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine($"El DataTable está vacío después de la asignación.{"\n"}" +
                        $"Nombre del SP: {nombreSP}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la base de datos " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return dt;
        }
        public int EjecutarSql(string sp, List<Parametros> Lparametros)
        {
            int FilasAfectadas = 0;
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = sp;
                foreach (Parametros o in Lparametros)
                {
                    comando.Parameters.AddWithValue(o.Name, o.Value);
                }
                FilasAfectadas = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al Ejecutar Sql" + "\n" + ex.Message
                    + "Nombre del SP:" + sp);
            }
            finally { conexion.Close(); }

            return FilasAfectadas;
        }
    }
}
