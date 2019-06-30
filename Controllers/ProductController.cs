using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using market.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace market.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        #region Dependency Injection
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion


        #region GET Products 
        // api/Product
        
        [HttpGet("[action]")]
        [Authorize(Policy = "RequireLoggedin")]
        public IActionResult GetProducts()
        {
            return Ok(_db.products.ToList());
        }
        #endregion

        #region Add products
       
        [HttpPost("[action]")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel formdata)
        {
            var newProduct = new ProductModel
            {
                Name = formdata.Name,
                Description = formdata.Description,
                ImageUrl = formdata.ImageUrl,
                OutOftuck = formdata.OutOftuck,
                Price = formdata.Price

            };

             await  _db.products.AddAsync(newProduct);
             await _db.SaveChangesAsync();

            return Ok();
        }
        #endregion

        #region Update Product
        [HttpPut("[action]/{id}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> updateProduct([FromRoute] int id , [FromBody] ProductModel formdata )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var oldProduct =  _db.products.FirstOrDefault(p => p.ProductId ==id);
            if (oldProduct ==null)
            {
                return NotFound();
            }
            oldProduct.Name = formdata.Name;
            oldProduct.ImageUrl = formdata.ImageUrl;
            oldProduct.Description = formdata.Description;
            oldProduct.Price = formdata.Price;
            oldProduct.OutOftuck = formdata.OutOftuck;
            _db.Entry(oldProduct).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return Ok(new JsonResult("The product with id :"+id.ToString()+"is upadate"));

        }
        #endregion

        #region Delete product
        [HttpDelete("[action]/{id}")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product =await  _db.products.FindAsync(id);
            if (product ==null)
            {
                return NotFound();
            }
            _db.products.Remove(product);
            await  _db.SaveChangesAsync();
            return Ok(new JsonResult("The Product with id : "+id+" is Now Deleted"));
        }
        #endregion

    }
}
