using System;
using System.Collections.Generic;
using System.Linq;

namespace apiGuimaraesEletronica.Mock
{
    public class ProductRepository
    {
        private static ICollection<ProductEntity> _db;

        private static ICollection<ProductEntity> Database
        {
            get
            {
                if (_db == null)
                    _db = new List<ProductEntity>();

                return _db;
            }
        }

        public void Import(ICollection<ProductEntity> itemDb)
        {
            _db = itemDb;
        }

        public ProductEntity Get(int id)
        {
            var product = Database.FirstOrDefault(db => db.Id == id);

            return product;
        }

        public ICollection<ProductEntity> GetMany()
        {
            return Database.ToList();
        }

        public void Add(ProductEntity product)
        {
            if (Database.Any(p => p.Id == product.Id))
                throw new Exception("Product already exists");

            Database.Add(product);
        }

        public void Update(ProductEntity product)
        {
            if (Database.Any(p => p.Id == product.Id))
            {
                var old = Database.FirstOrDefault(db => db.Id == product.Id);
                Database.Remove(old);

                Database.Add(product);
            }
            else
            {
                throw new Exception("Product doesn't exists");
            }
        }

        public int GetNextId()
        {
            if (Database.Any() == false)
                return 1;

            return Database.Max(db => db.Id) + 1;
        }
    }
}