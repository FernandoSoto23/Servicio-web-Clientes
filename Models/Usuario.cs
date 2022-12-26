using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Telefono { get; set; }
        public bool Admin { get; set; }
        public bool Activo { get; set; }

        public static Usuario Loguear(string usuario,string pwd)
        {
            Datos.Conectar();
            Usuario u = new Usuario();
            string cadena = $"select * from usuario where usuario = '{usuario}' and pwd = '{pwd}'";
            
            SqlCommand cmd = new SqlCommand(cadena,Datos.conx);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u.Id = int.Parse(dr["id"].ToString());
                u.User = dr["usuario"].ToString();
                u.Nombre = dr["nombre"].ToString();
                u.Email = dr["email"].ToString();
                u.Pwd = dr["pwd"].ToString();
                u.Telefono = dr["telefono"].ToString();
                u.Admin = dr["admin"].ToString() == "s";
                u.Activo = dr["activo"].ToString() == "s";
            }
            Datos.Desconectar();
            return u;
        }
        public static bool InsertarUsuario(Usuario entidad)
        {
            Datos.Conectar();
            bool s = false;
            string cadena = $"insert into usuario(usuario,nombre,email,pwd,telefono,admin,activo) values('{entidad.User}','{entidad.Nombre}','{entidad.Email}','{entidad.Pwd}','{entidad.Telefono}','s','s')";
            SqlCommand cmd = new SqlCommand(cadena,Datos.conx);

            try
            {
                cmd.ExecuteNonQuery();
                s = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            Datos.Desconectar();
            return s;
        }
    }

}