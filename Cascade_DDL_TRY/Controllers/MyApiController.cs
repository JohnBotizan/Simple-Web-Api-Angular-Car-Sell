
using Cascade_DDL_TRY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Cascade_DDL_TRY.Controllers
{
    public class MyApiController : ApiController
    {
        IRepository repo;
        ModelFactory _modelFactory;
        public MyApiController(IRepository repo)
        {
            this.repo = repo;
            _modelFactory = new ModelFactory();
        }
        [Route("api/MyApi/GetMake")]
        public IHttpActionResult GetMake()
        {
            IHttpActionResult result = null;


            var allMakes = repo.AllMakes()
                               .ToList()
                               .Select(p => _modelFactory.Create(p));



            if (allMakes.Count() > 0)
            {
                result = Ok(allMakes);
            }
            else
            {
                result = NotFound();
            }
            
            return result; 

        }

        [Route("api/MyApi/GetModel/{makeID:int}")]
        public IHttpActionResult GetModel(int makeID)
        {
            IHttpActionResult result;
                  
          var  modelList =  repo.AllModelsFromMake(makeID)
                                .ToList()
                                .Select(p=> _modelFactory.Create(p));
           
              
            
            if(modelList.Count() >0)
            {
                result = Ok(modelList);
            }
            else
            {
                result = NotFound();
            }
            return result; 

        }
            
        [Route("api/MyApi/GetAnunt/Make/{makeID}/Model/{modelID?}/Filter")]
        public IHttpActionResult GetAnunt(int makeID, int? modelID,[FromUri]SearchAnunt search)
        {
            IHttpActionResult result;

            var anunts = (modelID != 0) ? repo.AllAnuntsFromModel(modelID)
                                                .ToList()
                                                .Select(p => _modelFactory.Create(p))
                                        : repo.AllAnuntsFromMake(makeID)
                                                .ToList()
                                                .Select(p => _modelFactory.Create(p));
           
            anunts = anunts.Where(p => (search.PriceMin == null? true : p.Price >= search.PriceMin)&& 
                                       (search.PriceMax == null? true : p.Price <=search.PriceMax)&&
                                       (string.IsNullOrEmpty(search.Fuel)? true: p.Fuel.ToString()==search.Fuel));
            if (anunts.Count() > 0)
            {
                result = Ok(anunts);
            }
            else
            {
                result = NotFound();
            }

            return result; 
        }

       
    }
}