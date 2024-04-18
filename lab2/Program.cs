using System;
namespace lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Context context = new Context();
            int first_number = Int32.Parse(Console.ReadLine());
            int second_number = Int32.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            string addition = "+";
            string subtraction = "-";
            string multiplication = "*";
            if (operation == addition)
            {
                context.setStrategy(new StrategyAdd());
            }
            if (operation == subtraction)
            {
                context.setStrategy(new StrategySub());

            }
            if (operation == multiplication)
            {
                context.setStrategy(new StrategyMul());
            }
            int result = context.executeStrategy(first_number, second_number);
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}


