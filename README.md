## ACN Coding Challenge

### Application URL
https://acn-exam.azurewebsites.net/

### Overview
This application allows an authorized user to check balance and all transactions (e.g. payments).<br/>
To authenticate, please see Security section.

### Project Details
Project is created using `ASP.NET Core Web API` with a framework `.NET Core 3.1`

### Api Endpoints
| HTTP method |  URI path                 | Description                              |
| ------------|---------------------------| -----------------------------------------|
| POST        | /api/authenticate         | Authenticates user and returns a token.  |
| GET         | /api/account/balance      | Checks authenticated user's balance.     |
| GET         | /api/account/transactions | Checks authenticated user's transactions.|

### Architecture and Structure
I really like exploring different application structures, architecture and patterns. I've read many blogs and watched a bunch of tutorials. As a result, I came up with this structure below:

+ Api
+ Domain
+ Infrastructure
+ Services
+ UnitTests

### Swagger
I've setup Swagger to easily test the application by just browsing in the web.<br/>
When you browse the [application url](https://acn-exam.azurewebsites.net/), you will be redirected to Swagger UI.<br/>
You can try using Postman or any other api testing tool of your preference.

### Security
In the application I've setup Bearer Authentication.<br>
For you to be able to check the balance and transactions of the current user, you need to be authenticated.<br>
To authenticate, use the credentials below:
```json
{
  "email": "test@gmail.com",
  "password": "12345"
}
```

### Testing
With regards testing, I've only tested a scenario that executes without exception which produces an expected output (or what they call happy path).
