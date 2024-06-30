using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
    public class CD_Consulta
    {
        ConexionBD oConexionBD = new ConexionBD();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comandoQuery = new SqlCommand();

        public void Guardar(string NOMBRE_COMPLETO, string DETALLE, string FECHA)
        {

            comandoQuery.Connection = oConexionBD.abrirBd();

            comandoQuery.CommandText = "insert into MOTIVO_CONSULTA" +
                 " values('" + DETALLE + "','" +
                 FECHA + "','" + NOMBRE_COMPLETO + "')";
            comandoQuery.CommandType = CommandType.Text;
            comandoQuery.ExecuteNonQuery();

            comandoQuery.Connection = oConexionBD.cerrarBD();
        }
        public void Modificar(string idcliente, string NOMBRE_COMPLETO, string DETALLE, string FECHA)
        {
            comandoQuery.Connection = oConexionBD.abrirBd();

            comandoQuery.CommandText = "update MOTIVO_CONSULTA" +
                 " set DETALLE = '" + DETALLE + "'," +
                 "FECHA = '" + FECHA + "',NOMBRE_COMPLETO='" + NOMBRE_COMPLETO + "'where CODIGO_ID" + idcliente;
            comandoQuery.CommandType = CommandType.Text;
            comandoQuery.ExecuteNonQuery();

            comandoQuery.Connection = oConexionBD.cerrarBD();
        }
        public void Eliminar(string idcliente)
        {
            comandoQuery.Connection = oConexionBD.abrirBd();

            comandoQuery.CommandText = "delete MOTIVO_CONSULTA" +
             "where CODIGO_ID" + idcliente;
            comandoQuery.CommandType = CommandType.Text;
            comandoQuery.ExecuteNonQuery();

            comandoQuery.Connection = oConexionBD.cerrarBD();
        }
        public void Imprimir()
        {

        }
        public DataTable BuscarConsulta(string idcliente)
        {
            comandoQuery.Connection = oConexionBD.abrirBd();

            comandoQuery.CommandText = "select DETALLE, FECHA, NOMBRE_COMPLETO " +
            "from MOTIVO_CONSULTA" +
            " where CODIGO = " + idcliente;

            comandoQuery.CommandType = CommandType.Text;
            leer = comandoQuery.ExecuteReader();
            tabla.Clear();
            tabla.Load(leer);
            oConexionBD.cerrarBD();
            return tabla;
        }

    }
}
