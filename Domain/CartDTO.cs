using System.Collections.Generic;
using System.Linq;

namespace apiGuimaraesEletronica.Domain
{
    public class CartDTO
    {
        public string UserName { get; set; }
        public ICollection<ItemDTO> Itens { get; set; }
        public decimal Total
        {
            get
            {
                if (Itens.Any() == false)
                    return 0m;

                return Itens.Sum(item => item.Quantity * item.Product.Value);
            }
        }
    }

    public class ItemDTO
    {
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
    }
}