using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArrayManipulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayCalcController : ControllerBase
    {
        // GET: api/ArrayCalc
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //, [FromQuery(Name = "productIds")] int prodid2, [FromQuery(Name = "productIds")]int prodid3, [FromQuery(Name = "productIds")]int prodid4, [FromQuery(Name = "productIds")]int prodid5
        // GET: api/ArrayCalc/5
        [HttpGet]
        [Route("reverse")]
        public Array reverse([FromQuery(Name = "productIds")]int[] prodid1)
        {
            for (int i = 0; i < prodid1.Length / 2; i++)
            {
                int tmp = prodid1[i];
                prodid1[i] = prodid1[prodid1.Length - i - 1];
                prodid1[prodid1.Length - i - 1] = tmp;
            }
            return prodid1;
        }
        
        [HttpGet]
        [Route("deletepart")]
        public Array deletepart([FromQuery(Name = "position")]int pos,[FromQuery(Name ="productIds")]int[] prodids)
        {
            int i = 0;
            int n = prodids.Length-1;
            while (i != pos - 1)
                i++;
            while (i < n)
            {
                prodids[i] = prodids[i + 1];
                i++;
            }
           prodids= prodids.Take(prodids.Count() - 1).ToArray();
           return prodids;
        }

        
    }
}
