using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Web.Models;
using SportsStore.Web.Models.BindingTargets;

namespace SportsStore.Web.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierValuesController : ControllerBase
    {
        private DataContext context;
        public SupplierValuesController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IEnumerable<Supplier> GetSuppliers()
        {
            return context.Suppliers;
        }
        [HttpPost]
        public IActionResult CreateSupplier([FromBody]SupplierData sdata)
        {
            if (ModelState.IsValid)
            {
                Supplier s = sdata.Supplier;
                context.Add(s);
                context.SaveChanges();
                return Ok(s.Id);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpPut("{id}")]
        public IActionResult ReplaceSupplier(long id, [FromBody] SupplierData sdata)
        {
            if (ModelState.IsValid) 
            { 
                Supplier s = sdata.Supplier; 
                s.Id = id; 
                context.Update(s);
                context.SaveChanges(); 
                return Ok(); 
            } else
            { 
                return BadRequest(ModelState);
            } 
        }



    }
}

      




    
    
