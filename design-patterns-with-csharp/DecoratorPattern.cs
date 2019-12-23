using System;

public class DecoratorPattern
{
    interface IComponent
    {
        string Operation();
    }

    class Component : IComponent
    {
        public string Operation()
        {
            return "I am walking ";
        }
    }

    class DecoratorA : IComponent
    {
        readonly IComponent component;

        public DecoratorA(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "and listening to EDM music ";
            return s;
        }
    }

    class DecoratorB : IComponent
    {
        readonly IComponent component;
        public string addedState = "past the Coffee Shop";

        public DecoratorB(IComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            string s = component.Operation();
            s += "to university";
            return s;
        }

        public string AddedBehavior()
        {
            return "and I bought a cappucino";
        }
    }

    public static void Client()
    {
        static void Display(string s, IComponent c)
        {
            Console.WriteLine(s + c.Operation());
        }
        
        Console.WriteLine("Decorator Pattern\n");

        IComponent component = new Component();
        Display("1. Basic component: ", component);
        Display("2. A-decorated: ", new DecoratorA(component));
        Display("3. B-decorated: ", new DecoratorB(component));
        Display("4. B-A-decorated: ", new DecoratorB(new DecoratorA(component)));

        // Explicit DecoratorB
        DecoratorB b = new DecoratorB(new Component());
        Display("5. A-B-decorated: ", new DecoratorA(b));
        // Invoking 1ts added state and added behavior
        Console.WriteLine("\t\t\t" + b.addedState + b.AddedBehavior());
    }
}
