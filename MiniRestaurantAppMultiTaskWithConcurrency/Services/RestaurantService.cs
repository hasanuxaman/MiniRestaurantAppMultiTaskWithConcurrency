using MiniRestaurantAppMultiTaskWithConcurrency.Model;

namespace MiniRestaurantAppMultiTaskWithConcurrency.Services
{
    public class RestaurantService
    {


        public async Task<string> ProcessOrderAsync(OrderRequest order, CancellationToken cancellationToken)
        {
            //  CONCURRENCY HERE: Simulate a time-consuming task
            await Task.Delay(3000, cancellationToken);
            await HandleOrderAsync(order);
            return $"Table {order.TableNumber}: Order received with {order.Items.Length} items: {string.Join(", ", order.Items)}.";
        }

        public async Task<List<string>> ProcessMultipleOrdersAsync(List<OrderRequest> orders, CancellationToken cancellationToken)
        {
            //  MULTITASKING WITH CONCURRENCY: Run multiple orders concurrently
            var processingTasks = orders.Select(order =>
                Task.Run(() => ProcessOrderAsync(order, cancellationToken), cancellationToken)
            ).ToList();

            var results = await Task.WhenAll(processingTasks);
            return results.ToList();
        }

        public async Task HandleOrderAsync(OrderRequest request)
        {
            Console.WriteLine($" Table {request.TableNumber}: Order received for {string.Join(", ", request.Items)}");

            var cooking = CookFoodAsync(request);
            var billing = GenerateBillAsync(request);
            var serving = ServeFoodAsync(request);

            await Task.WhenAll(cooking, billing, serving);

            Console.WriteLine($" Table {request.TableNumber}: Order completed.\n");
        }

        private async Task CookFoodAsync(OrderRequest req)
        {
            Console.WriteLine($" Table {req.TableNumber}: Cooking {string.Join(", ", req.Items)}...");
            await Task.Delay(2000);
            Console.WriteLine($" Table {req.TableNumber}: Cooking done.");
        }

        private async Task GenerateBillAsync(OrderRequest req)
        {
            Console.WriteLine($" Table {req.TableNumber}: Generating bill...");
            await Task.Delay(1000);
            Console.WriteLine($" Table {req.TableNumber}: Bill ready.");
        }

        private async Task ServeFoodAsync(OrderRequest req)
        {
            Console.WriteLine($"Table {req.TableNumber}: Serving food...");
            await Task.Delay(1500);
            Console.WriteLine($" Table {req.TableNumber}: Food served.");
        }
    }
}
