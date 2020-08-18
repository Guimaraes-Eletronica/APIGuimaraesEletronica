using apiGuimaraesEletronica.Domain;
using apiGuimaraesEletronica.Mock;
using Microsoft.AspNetCore.Mvc;

namespace apiGuimaraesEletronica.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.Get(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetMany()
        {
            var products = _productRepository.GetMany();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO product)
        {
            try
            {
                var newId = _productRepository.GetNextId();

                var entity = new ProductEntity
                {
                    Id = newId,
                    Name = product.Name,
                    Value = product.Value
                };

                _productRepository.Add(entity);

                return Created("", product);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}