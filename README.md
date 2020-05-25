# Vending Machine Test

### To run it 🚀
Just set the VendingMachine project as the startup one and run from VS.

### Tech stack 💡

**Frontend**
 - ReactJS

**Backend**
 - .net core
 - C#
 - Swagger for API testing and documentation.

### Goal 🎯
To have a virtual vending machine that would behave like a real one.

### Strategy followed for backend 🗺️

To store the coins in the wallets, I injected singleton services which have the data they need so I don’t have to worry about the state of the coins.

Then for the products list, I simulated they are in a repository and implemented that in a way that if they end up being in a database, textfile or whatever it is easy to switch.

I built it in four layers:

1.  **API** - holds the controllers and the DI configuration. Also Swagger was added to have a more readeable documentation accessing the `/swagger` endpoint. This layer references the Application & Domain layers.
    
2.  **Application** - holds the services that run the logic of the application and communicate with the domain. Here’s where all the processing happen. This layer references the Domain layer.
    
3.  **Domain** - holds the models and behavior definitions needed for the app to work.

4. **Persistence** - holds the implementation of the `IProductRepository`. This layer references the Application & Domain layers.
  

The project has essentially three models in the Domain layer:

1.  **Product** - represents the Product entity and its behavior, in this case it has the ability to take itself and to substract the unit taken.
    
2.  **UserWalletService** - represents the user's wallet and its behavior, keeps the collection of coins updated and handles them.
    
3.  **MachineWalletService** - represents the vending-machine's wallet and it has the exact same behavior as the user's wallet, with the difference that the `MachineWallet` starts with a default amount of coins.

*Each of these models has its service in the Application layer that handles them.*
    

  

Additionally I added three custom exceptions to handle three validation scenarios:

1.  **InvalidCoinException** - to avoid invalid coins to be inserted.
    
2.  **ProductNotAllowedException** - to prevent for a product to be sold if the user has not entered an enough amount or if there’s no units left for the given product.
    
3.  **NoChangeExceptions** - will happen if the vending machine has not enough coins to return the change.

### Unit tests 🧪

Since both wallets are based on the same base-class, I built two sets of tests:

1.  **WalletTest.cs** - Tests the functionality of the WalletService (coins and amount management), and since the user and the vending machine wallets implements the same logic, one is enough.
    
2.  **ProductsTest.cs** - Tests the functionality of the ProductService to ensure that the listing and the Units management work as expected.

## If I had more time I would have...

 1. Added a logging to register exceptions and monitor.
 2. Improved the flow for the method `ProductsController.Take`. I don't like having to worry about removing the coins from the machine wallet if it gets to this catch `catch (NoChangeException ex)`.
 3. Improved the UI, probably used Redux.



