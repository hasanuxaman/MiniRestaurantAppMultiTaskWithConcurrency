namespace MiniRestaurantAppMultiTaskWithConcurrency.Model
{
    public class OrderRequest
    {
        public string TableNumber { get; set; }
        public string[] Items { get; set; }
    }
}
