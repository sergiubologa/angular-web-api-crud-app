using AmgularJsTest.Data.Repositories;
using AngularJsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AngularJsTest.Controllers
{
    public class UnitsOfMeasureController : ApiController
    {
        IUnitOfMeasuresRepository _unitsOfMeasureRepository;

        public UnitsOfMeasureController(IUnitOfMeasuresRepository unitsOfMeasureRepository)
        {
            _unitsOfMeasureRepository = unitsOfMeasureRepository;
        }

        // GET api/unitsofmeasure
        [ResponseType(typeof(List<UnitOfMeasure>))]
        public IHttpActionResult GetItems()
        {
            return Ok(_unitsOfMeasureRepository.GetAll().Select(x => new UnitOfMeasure()
            {
                description = x.Des,
                id = x.id,
                symbol = x.Symbol
            }));
        }
    }
}
