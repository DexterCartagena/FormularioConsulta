using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;

namespace CapaDeNegocio
{
    public class CN_Consulta
    {
        CD_Consulta oConsulta = new CD_Consulta();
        

        public string DETALLE { get; set; }
        public string FECHA { get; set; }
        public string NOMBRE_COMPLETO { get; set; }

        public Boolean Guardar()
        {
            if (NOMBRE_COMPLETO.Trim() == "")
            {
                return false;
            }
            if (DETALLE.Trim() == "")
            {
                return false;
            }
            if (FECHA.Trim() == "")
            {
                return false;
            }

            try
            {
                oConsulta.Guardar(NOMBRE_COMPLETO, DETALLE, FECHA);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }
        public bool Modificar(string idcliente)
        {
            if (NOMBRE_COMPLETO.Trim() == "")
            {
                return false;
            }
            if (DETALLE.Trim() == "")
            {
                return false;
            }
            if (FECHA.Trim() == "")
            {
                return false;
            }

            try
            {
                oConsulta.Modificar(idcliente, NOMBRE_COMPLETO, DETALLE, FECHA);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Eliminar(string idcliente)
        {
            if (string.IsNullOrWhiteSpace(idcliente))
            {
                return false;
            }
            try
            {
                oConsulta.Eliminar(idcliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Imprimir()
        {

        }
        public bool VerificarCliente(string codigo, ref DataTable TablaConsulta)
        {
            int id_cliente;
            if (!int.TryParse(codigo, out id_cliente))
            {
                
                return false;
            }
            try
            {
                TablaConsulta = oConsulta.BuscarConsulta(id_cliente.ToString());
                if (TablaConsulta.Rows.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
