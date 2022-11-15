using System;
namespace FactoryMethodExample
{
    //використовуючи шаблон Factory Method, реалізувати класи Footballer та Biathlete, які є нащадками класу Sportsman
    public abstract class Creator
    {
        public abstract ISportsman Create(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override ISportsman Create(int type)
        {
            switch (type)
            {
                case 1: return new Footballer();
                case 2: return new Biathlete();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }
    public interface ISportsman 
    {
        string GetTeam()
        {
            return "Ukraine";
        }
        string GetName();
        string GetSeason();

    } 

    //конкретні продукти з різною реалізацією
    public class Footballer : ISportsman 
    {
        public string GetName()
        {
            return "Footballer";
        }
        public string GetSeason()
        {
            return "summer";
        }
    }

    public class Biathlete : ISportsman 
    {
        public string GetName()
        {
            return "Biathlete";
        }
        public string GetSeason()
        {
            return "winter";
        }
    }

    class MainApp
    {
        static void Main()
        {       
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 2; i++)
            {
                var product = creator.Create(i);
                Console.WriteLine("Where id = {0}, Team: {1}, Season: {2}, Name: {3}", i, product.GetTeam(), product.GetSeason(), product.GetName());
            }
            Console.ReadKey();
        }
    }
}

