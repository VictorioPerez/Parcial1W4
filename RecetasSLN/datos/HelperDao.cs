using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSLN.dominio;

namespace RecetasSLN.datos
{
    internal class HelperDao
    {
        //1-Dominio 2-HelperDap 3-InombreDao 4-nombreDao 5-Servicio 6-IServicio
        // 7-AbstractFS 8-ServiceFactIMpl 9-FormularioCodigo
        private SqlConnection conn;
        private SqlCommand cmd;
        private static HelperDao instancia;

        public HelperDao()
        {
            conn = new SqlConnection(@"");
            cmd = new SqlCommand();
        }
        public static HelperDao obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new HelperDao();
            }
            return instancia;
        }
        public int proximoID(string nombreSP,string parametroSP)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            SqlParameter pOUT = new SqlParameter();
            pOUT.ParameterName = parametroSP;
            pOUT.DbType = DbType.Int32;
            pOUT.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOUT);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.Close();
            return (int)pOUT.Value;
        }

        public bool CrearMaestroDetalleReceta(string nombreSP, string detalleSP, Receta receta)
        {
            bool aux = false;
            SqlTransaction t = null;
            try
            {
                conn.Open();
                t = conn.BeginTransaction();

                SqlCommand comando = new SqlCommand(nombreSP, conn, t);
                comando.CommandType = CommandType.StoredProcedure;
                //comando.Parameters.AddWithValue("nombreColumnaSQL", parametroDeDato primeraTabla);
                    //comando.Parameters.AddWithValue("@tipo_receta", receta.tipoReceta);
                    //comando.Parameters.AddWithValue("@cheff", receta.nombreCheff);
                    //comando.Parameters.AddWithValue("@nombre", receta.nombreReceta);

                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                comando.Parameters.Add(pOut);

                comando.ExecuteNonQuery();
                int identificador = (int)pOut.Value;

                SqlCommand comandoD = null;
                foreach (DetalleRecetas det in receta.detalleRecetas)
                {
                    comandoD = new SqlCommand(detalleSP, conn, t);
                    comandoD.CommandType = CommandType.StoredProcedure;
                        //comandoD.Parameters.AddWithValue("@id_receta", identificador);
                    //comandoD.Parameters.AddWithValue("nombreColumnaSQLDetalles", parametroDato);
                        //comandoD.Parameters.AddWithValue("@id_ingrediente", det.ingrediente.ingredienteID);
                        //comandoD.Parameters.AddWithValue("@cantidad", det.cantidad);
                        //comandoD.ExecuteNonQuery();
                }
                t.Commit();
                aux = true;
            }
            catch (Exception ex)
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            return aux;
        }
        public DataTable combo(string nombreSP)
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            cmd.Parameters.Clear();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            return dt;
        }
    }
}
