namespace AspNetCoreProje.Models
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new() { Id = 1, Name = "kalem1", Price = 100, Stock = 200 },
            new() { Id = 1, Name = "kalem2", Price = 200, Stock = 300 },
            new() { Id = 1, Name = "kalem3", Price = 300, Stock = 400 }
        };
        /*listeleme tutacak olan list sınıfı oluşturduk*/
        //static olan herhangi bir üyeye classımızın ismi üzerinden direkt erişebiliriz nesne örneği almamıza gerek yok
        public List<Product> GetAll() => _products;
        //public List<Product> Products()
        //{
        //    return _products;
        //}

        public void Add(Product newProduct)=> _products.Add(newProduct);

        public void Remove(int id)
        {
            var hasproduct = _products.FirstOrDefault(x => x.Id == id);

            if (hasproduct == null)
            {
                throw new Exception($"bu id({id})'ye sahip ürün bulunmamaktadır");
            }
            _products.Remove(hasproduct);
        }

        public void Update(Product uptadeProduct)
        {
            var hasproduct = _products.FirstOrDefault(x => x.Id == uptadeProduct.Id);
            if (hasproduct == null)
            {
                throw new Exception($"Bu id({uptadeProduct.Id})'ye sahip ürün bulunmamaktadır");
            }
            hasproduct.Name = uptadeProduct.Name;
            hasproduct.Price = uptadeProduct.Price;
            hasproduct.Stock = uptadeProduct.Stock;

            var index = _products.FindIndex(x => x.Id == uptadeProduct.Id);
            _products[index] = hasproduct;
        }
    }
}
