using System;

delegate string Product();

class Program
{
    static Product CreateProduct1() => () => "{Result of ConcreteProduct1}";
    static Product CreateProduct2() => () => "{Result of ConcreteProduct2}";

    static string SomeOperation(Func<Product> factoryMethod)
    {
        var product = factoryMethod();
        return "Creator: The same creator's code has just worked with " + product();
    }

    static void ClientCode(Func<Product> factoryMethod)
    {
        Console.WriteLine("Client: I'm not aware of the creator's class, but it still works.\n" + SomeOperation(factoryMethod));
    }

    static void Main()
    {
        Console.WriteLine("App: Launched with the ConcreteCreator1.");
        ClientCode(CreateProduct1);

        Console.WriteLine();

        Console.WriteLine("App: Launched with the ConcreteCreator2.");
        ClientCode(CreateProduct2);
    }
}
