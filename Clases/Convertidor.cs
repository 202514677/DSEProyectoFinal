using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEProyectoFinal.Clases
{
    public static class Convertidor
    {
        public static int Entero(
            object valor)
        {
            return valor == DBNull.Value
                ? 0
                : Convert.ToInt32(valor);
        }

        public static decimal Decimal(
            object valor)
        {
            return valor == DBNull.Value
                ? 0
                : Convert.ToDecimal(valor);
        }

        public static DateTime Fecha(
            object valor)
        {
            return valor == DBNull.Value
                ? DateTime.Today
                : Convert.ToDateTime(valor);
        }

        public static bool Booleano(
            object valor)
        {
            return valor != DBNull.Value
                &&
                Convert.ToBoolean(valor);
        }

        public static string Texto(
            object valor)
        {
            return valor == DBNull.Value
                ? ""
                : valor.ToString();
        }
    }
}
