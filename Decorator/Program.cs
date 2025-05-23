using System;
using System.Globalization;

delegate string Component();

class Program
{
    static string ConcreteComponent() => "ConcreteComponent";

    static Component DecoratorA(Component component) { return () => $"ConcreteDecoratorA({component})"; }
    static Component DecoratorB(Component component) { return () => $"ConcreteDecoratorB({component})"; }

    static void ClientCode(Component component) { Console.WriteLine("RESULT: " + component()); }

    static void Main()
    {
        Console.WriteLine("Client: I get a simple component: ");
        ClientCode(ConcreteComponent);
        Console.WriteLine();

        var decorated = DecoratorB(DecoratorA(ConcreteComponent));
        Console.WriteLine("Client: Now I`ve got a decorated component: ");
        ClientCode(decorated);
    }

}