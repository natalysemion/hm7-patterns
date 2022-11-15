using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            DecoratedChristmasTree c = new DecoratedChristmasTree();
            TreeDecorator d1 = new TreeDecorator();
            GarlandsDecorator d2 = new GarlandsDecorator();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class ChristmasTree
    {
        public abstract void Operation();
    }

    // "ConcreteComponent"
    class DecoratedChristmasTree : ChristmasTree
    {
        public override void Operation()
        {
            Console.WriteLine("Christmas Tree");
        }
    }
    // "Decorator"
    abstract class Decorator : ChristmasTree
    {
        protected ChristmasTree chrisTree;

        public void SetComponent(ChristmasTree component)
        {
            this.chrisTree = component;
        }
        public override void Operation()
        {
            if (chrisTree != null)
            {
                chrisTree.Operation();
            }
        }
    }

    // "ConcreteDecoratorA"
    class TreeDecorator : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "decorated";
            Console.WriteLine("Tree is decorated");
        }
    }

    // "ConcreteDecoratorB" 
    class GarlandsDecorator : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Garlands are on");
        }
        
    }
}
