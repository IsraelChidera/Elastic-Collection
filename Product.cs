using System.Dynamic;

namespace Elasto_lib
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public int OrderCount { get; set; }

    }

    public class ElasticProductCollection
    {
        //ExpandoObject list
        public List<ExpandoObject> Products { get; set; }

        public ElasticProductCollection(List<Product> products)
        {
            Products = new List<ExpandoObject>();
            foreach (var product in products)
            {
                dynamic expandoProduct = new ExpandoObject();
                expandoProduct.Id = product.Id;
                expandoProduct.Name = product.Name;
                expandoProduct.Quantity = product.Quantity;
                expandoProduct.Price = product.Price;
                expandoProduct.Category = product.Category;
                expandoProduct.OrderCount = product.OrderCount;
                Products.Add(expandoProduct);
            }
        }

        public void DisplayProperties(params string[] properties)
        {
            Console.WriteLine("test");
            if (properties.Length == 0)
            {
                properties = new string[] { "Id", "Name", "Quantity", "Price", "Category", "OrderCount" };
            }

            foreach (var product in Products)
            {
                string output = "";
                foreach (var property in properties)
                {
                    output += product.GetType().GetProperty(property)?.GetValue(product) + ", ";
                }
                Console.WriteLine(output.TrimEnd(',', ' '));
            }
        }




    }

    /*class ElasticCollection<T>
    {
        public IEnumerable<dynamic> FilterProperties(IEnumerable<T> collection, params string[] properties)
        {
            foreach (var item in collection)
            {
                var expando = new ExpandoObject();
                var itemProperties = item.GetType().GetProperties();
                var expandoDict = (IDictionary<string, object>)expando;
                if (properties.Length == 0)
                {
                    foreach (var prop in itemProperties)
                    {
                        expandoDict.Add(prop.Name, prop.GetValue(item));
                    }
                }
                else
                {
                    foreach (var prop in itemProperties.Where(p => properties.Contains(p.Name)))
                    {
                        expandoDict.Add(prop.Name, prop.GetValue(item));
                    }
                }
                yield return expando;
            }
        }
    }*/

    /*class ElasticCollection<T>
    {
        private List<T> _items;
        public ElasticCollection()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public List<ExpandoObject> List(List<string> properties = null)
        {
            List<ExpandoObject> result = new List<ExpandoObject>();
            foreach (var item in _items)
            {
                dynamic expando = new ExpandoObject();
                var dict = expando as IDictionary<string, object>;

                if (properties == null)
                {
                    dict = item as IDictionary<string, object>;
                }
                else
                {
                    foreach (var prop in properties)
                    {
                        dict[prop] = item.GetType().GetProperty(prop).GetValue(item);
                    }
                }

                result.Add(expando);
            }
            return result;
        }
    }*/
}


















