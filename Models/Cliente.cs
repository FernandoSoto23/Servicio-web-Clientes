using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebService.Models
{
    public class Cliente
    {
        public int Id;
        public string Nombre;
        public string Direccion;
        public string RFC;
        public string Correo;
        public string Telefono;


        public static Cliente ObtenerCliente(int id)
        {
            Datos.Conectar();
            StringBuilder Cadena = new StringBuilder();
            Cadena.AppendLine("spConsultar " + id);
            SqlCommand Comando = new SqlCommand(Cadena.ToString(),Datos.conx);
            SqlDataReader dr = Comando.ExecuteReader();

            Cliente Entidad = new Cliente();

            if (dr.Read())
            {
                Entidad.Id= dr.GetInt32(0);
                Entidad.Nombre = dr.GetString(1);
                Entidad.Direccion = dr.GetString(2);
                Entidad.RFC = dr.GetString(3);
                Entidad.Correo = dr.GetString(4);
                Entidad.Telefono = dr.GetString(5);
            }
            Datos.Desconectar();
            return Entidad;
        }

        public bool insertarCliente(Cliente entidad)
        {
            Datos.Conectar();
            bool s = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spAddClient @numero,@nombre,@direccion,@rfc,@correo,@telefono";
            cmd.Parameters.AddWithValue("@numero",entidad.Id);
            cmd.Parameters.AddWithValue("@nombre",entidad.Nombre);
            cmd.Parameters.AddWithValue("@direccion", entidad.Direccion);
            cmd.Parameters.AddWithValue("@RFC",entidad.RFC);
            cmd.Parameters.AddWithValue("@correo",entidad.Correo);
            cmd.Parameters.AddWithValue("@telefono",entidad.Telefono);

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
        public static ListaClientes LeerClientes()
        {
            Datos.Conectar();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            cmd.CommandText = "select * from cliente";
            cmd.Connection = Datos.conx;
            dr = cmd.ExecuteReader();

            ListaClientes Lista = new ListaClientes();
            while (dr.Read())
            {
                Cliente entidad = new Cliente();
                entidad.Id = int.Parse(dr["id"].ToString());
                entidad.Nombre = dr["nombre"].ToString();
                entidad.Direccion = dr["direccion"].ToString();
                entidad.RFC = dr["rfc"].ToString();
                entidad.Correo = dr["correo"].ToString();
                entidad.Telefono = dr["telefono"].ToString();
                Lista.Add(entidad);
            }
            Datos.Desconectar();
            return Lista;
        }
        public static bool ActualizarClientes(Cliente entidad)
        {
            Datos.Conectar();
            bool s = false;
            string cadena = $"spAddClient {entidad.Id},'{entidad.Nombre}','{entidad.Direccion}','{entidad.RFC}','{entidad.Correo}','{entidad.Telefono}'";
            SqlCommand cmd = new SqlCommand(cadena,Datos.conx);
            try
            {
                cmd.ExecuteNonQuery();
                s = true;
            }
            catch (Exception e)
            {
                Datos.Desconectar();
                throw e;
            }
            Datos.Desconectar();
            return s;

        }
        public static bool borrarCliente(int id)
        {
            Datos.Conectar();
            bool s = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Datos.conx;
            cmd.CommandText = "spDeleteClient @id";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.ExecuteNonQuery();
                s = true;
            }
            catch (Exception e)
            {
                Datos.Desconectar();
                throw e;
            }
            Datos.Desconectar();
            return s;
        }

    }

    public class ListaClientes : List<Cliente>
    {

    }

}