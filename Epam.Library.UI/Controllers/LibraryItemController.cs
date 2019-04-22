using Entities;
using Epam.Library.NinjectKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.Library.UI.Controllers
{
    public class LibraryItemController : ApiController
    {
        [Route("api/AllItems")]
        // GET: api/LibraryItem
        public IEnumerable<LibraryItem> Get()
        {
            return Initializer.CommonAccessLogic.GetAll();
        }

        // GET: api/LibraryItem/5
        public LibraryItem Get(int id)
        {
            return Initializer.CommonAccessLogic.GetItemById(id);
        }

        // POST: api/LibraryItem
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LibraryItem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LibraryItem/5
        public void Delete(int id)
        {
        }
    }
}
