using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        class Pizza
        {
            string dough;
            string sauce;
            string topping;
            string spices; //новий прошарок 
            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void SetSpices(string sp) { spices = sp; }
            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSause: {1}\nTopping: {2}\nSpices: {3}", dough, sauce, topping, spices);
            }
        }

        //Abstract Builder
        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }

            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
            public abstract void BuildSpices();
        }
        //Concrete Builder
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
            public override void BuildSpices() { pizza.SetSpices("papper"); }
        }
        //Concrete Builder
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("pan baked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() { pizza.SetTopping("pepparoni+salami"); }
            public override void BuildSpices() { pizza.SetSpices("salt"); }
        }

        //Concrete Builder
        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("baked"); }
            public override void BuildSauce() { pizza.SetSauce("mayonnaise"); }
            public override void BuildTopping() { pizza.SetTopping("mozzarella+tomato"); }
            public override void BuildSpices() { pizza.SetSpices("basil"); }


        }
        /** "Director" */
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
                pizzaBuilder.BuildSpices();
            }
        }
        /** A customer ordering a pizza. */
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();
                
                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza1 = waiter.GetPizza();
                pizza1.Info();

                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza2 = waiter.GetPizza();
                pizza2.Info();

                waiter.SetPizzaBuilder(margaritaPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza3 = waiter.GetPizza();
                pizza3.Info();

                Console.ReadKey();
            }
        }
    }
}