using Microsoft.AspNetCore.Mvc;
using RESTSalesItems.Models;
using RESTSalesItems.Repositories;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTSalesItems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesItemsController : ControllerBase
    {
        private readonly SalesItemsRepository _salesItemsRepository = new();
        // GET: api/<SalesItemsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<SalesItem> Get([FromQuery] string? description = null, int? maxPrice = null, string? sellerEmail = null, string? sort_by = null)
        {
            return _salesItemsRepository.Get(description, maxPrice, sellerEmail, sort_by);
        }

        /*/ GET api/<SalesItemsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<SalesItemsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<SalesItem> Post([FromBody] SalesItem value)
        {
            SalesItem item = _salesItemsRepository.Add(value);
            string uri = Url.RouteUrl(RouteData.Values) + "/" + item.Id;
            return Created(uri, item);
        }

        /*/ PUT api/<SalesItemsController>/5
        [HttpPut("{id}")]

        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<SalesItemsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SalesItem> Delete(int id)
        {
            SalesItem? item = _salesItemsRepository.Delete(id);
            if (item == null) return NotFound("No such item " + id);
            return Ok(item);
        }
    }
}
