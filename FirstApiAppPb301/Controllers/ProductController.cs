using FirstApiAppPb301.Dtos;
using FirstApiAppPb301.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiAppPb301.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> list = new()
        {
            new () { Id = 1,Name="Pr1",Description="aaaaaaaaaaaaaaa" },
            new () { Id = 2,Name="Pr2",Description="aaaaaaaaaaaaaaa" },
            new () { Id = 3,Name="Pr3",Description="aaaaaaaaaaaaaaaaa" },
            new () { Id = 4,Name="Pr4",Description="aaaaaaaaaaaaasasaa" }
        };
         
        [HttpGet] 
         public IActionResult Get()
        {
            //return Ok(list);
            return StatusCode(200,list);
        }
        [HttpGet("{id}") ]
        public IActionResult Get(int id) 
        { 
            var existPro=list.FirstOrDefault(p => p.Id == id);
            if (existPro == null) return NotFound();
            return Ok(existPro);
        }
        [HttpPost]
        public IActionResult Create (ProductCreateDto Createproduct)
        {
            var newProduct = new Product()
            {
                Name = Createproduct.Name,
                Description = Createproduct.Description,
            };
            list.Add(newProduct);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")] 
        public IActionResult Update(int id,ProductUpdateDto product)
        {
            var existtPr = list.FirstOrDefault(p => p.Id == id);
            if (existtPr == null) return NotFound();
            existtPr.Name = product.Name;
            existtPr.Description = product.Description;
            return Ok(existtPr);
        }
        [HttpPatch("{id}")]
        public IActionResult ChangeStatus(int id, bool status)
        {
            var existProduct = list.FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return NotFound();
            existProduct.IsActive = status;
            return Ok(existProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult ChangeStatus(int id)
        {
            var existProduct = list.FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return NotFound();
            list.Remove(existProduct);
            return StatusCode(204);
        }
    }

}
