# MiniRestaurantAppMultiTaskWithConcurrency

An ASP.NET Core REST API project simulating a mini restaurant order processing system using multitasking and concurrency.

---

## Features

- Process multiple restaurant orders concurrently.
- Each order handles cooking, billing, and serving tasks concurrently.
- Uses async/await and Task.WhenAll for efficient multitasking.
- Supports cancellation tokens for graceful task cancellation.
- Simple REST API for placing single or multiple orders.

---

## Technologies Used

- ASP.NET Core 8.0
- C# 11
- .NET SDK (8.0)
- Visual Studio 2022 / VS Code
- Postman (for API testing)

---

## Project Structure

MiniRestaurantAppMultiTaskWithConcurrency/
├── Controllers/
│ └── RestaurantController.cs
├── Models/
│ └── OrderRequest.cs
├── Services/
│ └── RestaurantService.cs
├── Program.cs
├── MiniRestaurantAppMultiTaskWithConcurrency.csproj
├── README.md

---

## API Endpoints

### POST `/api/restaurant/handle-order`

Place a single order which will process cooking, billing, and serving concurrently.

**Request Body:**

```json
{
  "tableNumber": "T1",
  "items": ["Burger", "Fries", "Coke"]
}
Response:

"Order for table T1 processed successfully."
POST /api/restaurant/multi-order
Place multiple orders simultaneously. Each order will be processed concurrently.

Request Body:


[
  {
    "tableNumber": "T1",
    "items": ["Burger", "Fries"]
  },
  {
    "tableNumber": "T2",
    "items": ["Pizza", "Cola"]
  }
]
Response:


[
  { "Table": "T1", "Message": "Table T1: Order received with 2 items: Burger, Fries." },
  { "Table": "T2", "Message": "Table T2: Order received with 2 items: Pizza, Cola." }
]

How to Run
Clone the repository:

Navigate to the project directory:

cd MiniRestaurantAppMultiTaskWithConcurrency
Restore dependencies:

dotnet restore
Run the project:

dotnet run
The API will be available at https://localhost:5001 (or http://localhost:5000).

Use Postman or any API client to test the endpoints.

Notes
This project simulates delays with Task.Delay to mimic real-world cooking, billing, and serving times.

The concurrency implementation allows multiple orders to be processed efficiently.

Cancellation tokens are supported to cancel running tasks gracefully if needed.

Author
Md Hasanuzzaman Rony
Software Developer | ASP.NET Core Enthusiast
Email: hasanuxaman.rony@gmail.com

License
MIT License

---

If you want, I can help you customize it with your GitHub repo link, email, or add more sections!


