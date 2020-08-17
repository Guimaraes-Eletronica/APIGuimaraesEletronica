using System.Collections.Generic;
using System.Linq;
using System.Text;
using apiGuimaraesEletronica.Domain;
using apiGuimaraesEletronica.Mock;
using Microsoft.AspNetCore.Mvc;

namespace apiGuimaraesEletronica.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private CartRepository _cartRepository;

        public CartController(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("{userName}")]
        public IActionResult Get(string userName)
        {
            try
            {
                var cart = _cartRepository.Get(userName);

                return Ok(cart);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("{userName}/item")]
        public IActionResult PostItem(string userName, [FromBody] ItemDTO item)
        {
            var cart = _cartRepository.AddItemToCart(userName, item);

            return Created("", cart);
        }

        [HttpPost("Format")]
        public IActionResult Format([FromBody] CartDTO cart)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Carrinho do: {cart.UserName}");
            sb.AppendLine();
            sb.AppendLine("Itens");
            sb.AppendLine();

            foreach (var item in cart.Itens)
            {
                sb.AppendLine($"{item.Product.Name.PadRight(25, ' ')} - {item.Quantity.ToString().PadRight(3, ' ')} x {item.Product.Value.ToString("c").PadLeft(13, ' ')} = {(item.Quantity * item.Product.Value):c}");
            }

            sb.AppendLine();
            sb.AppendLine($"Total: {cart.Total:c}");

            return Ok(sb.ToString());
        }
    }
}