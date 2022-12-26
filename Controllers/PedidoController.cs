using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class PedidoController : ApiController
    {
        // GET: api/Pedido
        public Models.ListaPedido Get()
        {
            Models.ListaPedido p = new Models.ListaPedido();
            p = Models.Pedido.LeerPedidos();
            return p;
        }

        // GET: api/Pedido/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pedido
        public void Post([FromBody] Models.Pedido entidad)
        {
            Models.Pedido.insertarPedido(entidad);
        }

        // PUT: api/Pedido/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pedido/5
        public void Delete(int id)
        {
        }
    }
}
