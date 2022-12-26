using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        public Models.ListaClientes Get()
        {
            Models.ListaClientes c = new Models.ListaClientes();
            c = Models.Cliente.LeerClientes();
            return c;
        }

        // GET: api/Cliente/5
        public Models.Cliente Get(int id)
        {
            Models.Cliente c = new Models.Cliente();
            c = Models.Cliente.ObtenerCliente(id);
            return c;

        }

        // POST: api/Cliente
        public void Post([FromBody]Models.Cliente cliente)
        {
            Models.Cliente.ActualizarClientes(cliente);
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
            Models.Cliente.borrarCliente(id);
        }
    }
}
