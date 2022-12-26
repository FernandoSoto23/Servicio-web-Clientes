using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login

        // GET: api/Login/5


        public Models.Usuario Get(string user,string pwd)
        {
            Models.Usuario u = new Models.Usuario();
            u = Models.Usuario.Loguear(user,pwd);
            return u;
        }

        // POST: api/Login
        public void Post([FromBody]Models.Usuario newUsuario)
        {
            Models.Usuario.InsertarUsuario(newUsuario);
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
