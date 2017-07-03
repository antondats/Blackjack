using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player { Name = "Anton"};
            Game game = new Game { _player = player};

            while (true)
            {
                game.Play();
                bool response = GameIO.PlayerStep("Do you want continue?(Y/N)", "Y", "N");
                if (response == false)
                    break;
                Console.Clear();
            }
        }
    }
}
