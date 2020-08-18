using System;
using System.Collections.Generic;
using System.Linq;
using apiGuimaraesEletronica.Domain;
using apiGuimaraesEletronica.File;

namespace apiGuimaraesEletronica.Mock
{
    public class CartRepository
    {
        private static ICollection<CartDTO> _db;
        private FileDatabase<CartDTO> _fileDatabase;

        public CartRepository()
        {
            _fileDatabase = new FileDatabase<CartDTO>("cart.json");
            _db = _fileDatabase.Read().Result;
        }

        private static ICollection<CartDTO> Database
        {
            get
            {
                if (_db == null)
                    _db = new List<CartDTO>();

                return _db;
            }
        }

        public CartDTO Get(string userName)
        {
            var cart = Database.FirstOrDefault(db => db.UserName == userName);

            if (cart == null)
            {
                cart = CreateCart(userName);

                Database.Add(cart);
            }

            return cart;
        }

        private CartDTO CreateCart(string userName)
        {
            var cart = new CartDTO
            {
                UserName = userName,
                Itens = new List<ItemDTO>()
            };

            return cart;
        }

        public CartDTO AddItemToCart(string userName, ItemDTO item)
        {
            var cart = Get(userName);

            cart.Itens.Add(item);

            return cart;
        }
    }
}