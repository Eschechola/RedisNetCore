using System;

namespace RedisNetCore.Data.Entities
{
    public class Product
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }


        protected Product()
        {
        }

        public Product(
            string id,
            string name,
            decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void CreateNewId()
            => Id = Guid.NewGuid().ToString();
    }
}
