using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlConnection _conexion;
        private static SqlCommand _comando;
        #endregion

        #region Cosntructor
        static PaqueteDAO()
        {
            _conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            _comando = new SqlCommand();
            _comando.CommandType = CommandType.Text;
            _comando.Connection = _conexion;
        }
        #endregion

        #region Metodos
   
        public static bool Insertar(Paquete pkt)
        {
            bool retorno = false;
            try
            {
                _comando.CommandText = "INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES('" + pkt.DireccionEntrega + "','" + pkt.TrackingID + "', 'Jakubek Gabriel')";
                _comando.Connection.Open();
                _comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                _conexion.Close();
                throw e;
            }
            finally
            {
                if(_comando.Connection.State == ConnectionState.Open)
                {
                    _comando.Connection.Close();
                }
            }
            return retorno;
        }
        #endregion
    }
}
