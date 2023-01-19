namespace Elasto_lib
{
    //Elastic Product Collection
    public class ProductCollection
    {
        List<Product> products = new List<Product>()
        {
            new Product(){ Id=1, Name="Dell Xps" ,Quantity = 30 , Price="$1500" ,Category="PCs", OrderCount=1000 },
            new Product(){ Id=2,Name="Ergonomic Chair", Quantity=400 , Price="$200", Category="Chairs" , OrderCount=4000},
            new Product(){ Id=3, Name="Table", Quantity=500, Price="$250", Category="Tables", OrderCount=3000},
        };

        public void DisplayCollections()
        {
            Console.WriteLine("Here");
            ElasticProductCollection elasticProducts = new(products);
            elasticProducts.DisplayProperties();            
            elasticProducts.DisplayProperties("Id", "Name", "Price");


            Console.WriteLine("********");



        }

    }

}





















