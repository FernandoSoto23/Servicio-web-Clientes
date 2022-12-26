using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Datos
    {
        public static SqlConnection conx = new SqlConnection();

        public static void Conectar()
        {
            conx.ConnectionString = "server=DESKTOP-S70CQ5F\\SQLEXPRESS;Database=WebServiceDesarrolloWebII;user id=sa; password=fernando1234;";
            conx.Open();
        }
        public static void Desconectar()
        {
            if (conx != null && conx.State == System.Data.ConnectionState.Open)
                conx.Close();
        }
    }
}