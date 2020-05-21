using System;

namespace OC_GOL
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(null, 24);

            while (Console.ReadLine() != "Exit")
            {
                Console.Clear();
                game.Transform();
                game.Print();
            }
        }
    }
}
