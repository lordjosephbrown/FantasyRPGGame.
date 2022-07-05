// See https://aka.ms/new-console-template for more information
using FantasyRPGGame.Model;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class MyRandom : IRandom
    {
        public int Next(int num)
        {
            Random rnd = new Random();
            return rnd.Next(num);
        }

        public int Next(int num1, int num2)
        {
            Random rnd = new Random();
            return rnd.Next(num1,num2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyRandom _random = new MyRandom();
            int Creature1WinCondition1 = 0;
            int Creature1WinCondition2 = 0;
            int draw = 0;
            int simulationRunTime = 100;

            for (int i = 0; i < simulationRunTime; i++)
            {
                var human = new Humans(_random);
                var balrog = new Balrogs(_random);
                var battle = new Battle();
                battle.AddCreature(human);
                battle.AddCreature(balrog);
                List<string> messages = new List<string>();
                Console.WriteLine($"A battle between a {human.Race} and a {balrog.Race}.");
                Console.WriteLine($"Battle {i+1} begins");
                int number = battle.Due1(0, 1);
                foreach (string message in battle.Messages) { Console.WriteLine(message); }
                Console.WriteLine(Environment.NewLine);
                if (number == 0)
                {
                    Creature1WinCondition1++;
                }
                else if (number == 1)
                {
                    Creature1WinCondition2++;
                }
                else { draw++; }
            }

            Console.WriteLine($"Atfer {simulationRunTime} simulations, Human won {Creature1WinCondition1} times, Balrog won {Creature1WinCondition2} times and {draw} number of ties");
            
        }
    }
}





