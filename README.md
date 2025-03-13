# Smart Parking Lot Management System

This project implements a Smart Parking Lot Management System that interacts with IoT sensors to manage parking spots. The system provides a RESTful API for tracking parking spot occupancy and managing IoT devices.

## Features

- Detect when a car enters or leaves a parking spot through API calls.
- Track the number of available parking spots dynamically.
- Expose a RESTful API for the status of parking spots (occupied/free).
- Handle CRUD operations for parking spaces and IoT devices.

## API Endpoints

- **POST** `/api/v1/parking-spots/{id}/occupy`: Mark a parking spot as occupied.
- **POST** `/api/v1/parking-spots/{id}/free`: Mark a parking spot as free.
- **GET** `/api/v1/parking-spots`: Return the status of all parking spots.
- **POST** `/api/v1/parking-spots`: Add a new parking spot.
- **DELETE** `/api/v1/parking-spots/{id}`: Remove a parking spot.

## Requirements

- Only registered IoT devices can occupy or free a parking spot.
- Ensure proper validation for parking spot occupancy and freeing.

## Technologies Used

- .NET 8
- MongoDB for data storage
- Dependency Injection for service management

## Setup Instructions

1. Clone the repository:
   ```
   git clone https://github.com/igorariza/smart-parking-iot.git
   cd smart-parking-iot
   ```

2. Install the required dependencies:
   ```
   dotnet restore
   ```

3. Configure your MongoDB connection in `appsettings.json`.

4. Run the application:
   ```
   dotnet run
   ```
5. The application will be available at `http://localhost:5000`.
   postman colection:
   [postman_collection.json](postman_collection.json)

## Testing

Unit tests are included to validate core business logic. You can run the tests using:
```
dotnet test
```

