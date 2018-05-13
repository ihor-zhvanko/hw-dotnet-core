# Parking Simulator API
## Academy'18 • 2nd stage • 3. .NET Core 0__o

This project was created on .NET Core as 3rd Homework. All logic with Parking was taken from [previous project](https://github.com/ihor-zhvanko/homework-dotnet). Target of this project was to implement simple .NET Web API application. Very important was to create Class Library. For myself, and I hope You'll also find this helpfull, I've added [Swagger](https://swagger.io). I just wanted to test my API localy without any third-party apps.

## Routes:

### Cars

- ``GET /api/car `` get all cars

- ``GET /api/car/{id}`` get car by id

- ``DELETE /api/car/{id}`` delete car by id

- ``POST /api/car`` add new car

### Parking

- ``GET /api/parking/free`` get free space

- ``GET /api/parking/notfree`` get notfree space

- ``GET /api/parking/income`` get parking income

### Transactions

- ``GET /api/transaction`` get all transactions

- ``GET /api/transaction/last/{?carId}`` get transactions for the last minute (carId - optional)

- ``PUT /api/transaction/balance/topup?carId={carId}`` top up the balance of car by car id (amount in body)

## Quick start

### Mac Os

* Install XCode Tools
* Install Visual Studio For Mac
* When you've opened solution just build and enjoy :)

### Windows

* Install Visual Studio Community 2017
* If project doesn't build, then restore NuGet Packages and rebuild it.
