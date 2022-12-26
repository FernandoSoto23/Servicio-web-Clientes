using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Pedido
    {
        public int IdPedido;
        public int IdCliente;
        public string NombreCliente;
        public string NombrePedido;
        public string Observaciones;
        public float Precio;
        public static void insertarPedido(Pedido entidad)
        {
            Datos.Conectar();
            string cadena = $"insert into pedido(idCliente,NombrePedido,Observaciones,precio) values({entidad.IdCliente},'{entidad.NombrePedido}','{entidad.Observaciones}', '{entidad.Precio}')";
            SqlCommand cmd = new SqlCommand(cadena,Datos.conx);
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            Datos.Desconectar();
            
        }
        public static ListaPedido LeerPedidos()
        {
            string cadena = "select idPedido, idCliente, c.nombre as NombreCliente,NombrePedido,Observaciones,precio from pedido as p inner join cliente as c on p.idCliente = c.id ";
            Datos.Conectar();
            SqlCommand cmd = new SqlCommand(cadena,Datos.conx);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            ListaPedido Lista = new ListaPedido();
            while (dr.Read())
            {
                Pedido entidad = new Pedido();
                entidad.IdPedido = int.Parse(dr["idPedido"].ToString());
                entidad.IdCliente = int.Parse(dr["IdCliente"].ToString());
                entidad.NombreCliente = dr["NombreCliente"].ToString();
                entidad.NombrePedido = dr["NombrePedido"].ToString();
                entidad.Observaciones = dr["Observaciones"].ToString();
                entidad.Precio = float.Parse(dr["precio"].ToString());
                Lista.Add(entidad);
            }
            Datos.Desconectar();
            return Lista;
        }
    }

    public class ListaPedido : List<Pedido>
    {

    }
}