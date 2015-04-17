using AmgularJsTest.Data.Repositories;
using AngularJsTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AngularJsTest.Controllers
{
    public class ItemsController : ApiController
    {
        IItemsRepository _itemsRepository;

        public ItemsController(IItemsRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        // GET api/items
        [ResponseType(typeof(List<Item>))]
        public IHttpActionResult GetItems()
        {
            return Ok(_itemsRepository.GetAll().Select(x => new Item()
            {
                description = x.Des,
                id = x.id,
                measure = x.Measure,
                um = x.UM,
                unitOfMeasure = x.UnitsOfMeasure.Des
            }));
        }

        // GET api/items/6
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            var item = _itemsRepository.GetById(id);

            if (item != null)
            {
                return Ok(new Item()
                        {
                            description = item.Des,
                            id = item.id,
                            measure = item.Measure,
                            um = item.UM,
                            unitOfMeasure = item.UnitsOfMeasure.Des
                        });
            }

            return NotFound();
        }

        // PUT api/items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, [FromBody]Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != item.id)
            {
                return BadRequest();
            }

            try
            {
                var itemToUpdate = new AmgularJsTest.Data.Item() { id = id, Des = item.description, Measure = item.measure, UM = item.um };
                _itemsRepository.Update(itemToUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/items
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem([FromBody]Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToAdd = new AmgularJsTest.Data.Item()
            {
                Des = item.description,
                Measure = item.measure,
                UM = item.um
            };
            _itemsRepository.Add(itemToAdd);

            return CreatedAtRoute("DefaultApi", new { id = item.id }, item);
        }

        // DELETE api/items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            var itemToDelete = _itemsRepository.GetById(id);
            if (itemToDelete == null)
            {
                return NotFound();
            }

            _itemsRepository.Delete(itemToDelete);

            var responseItem = new Item() { id = itemToDelete.id, description = itemToDelete.Des, measure = itemToDelete.Measure, um = itemToDelete.UM };
            return Ok(responseItem);
        }

        private bool ItemExists(int id)
        {
            return _itemsRepository.Count(id) > 0;
        }
    }
}
