using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    static class GameIO
    {
        static public bool PlayerStep(string msg, string _true, string _false)
        {
            Console.WriteLine(msg);
            string response;
            while (true)
            {
                response = Console.ReadLine();
                if (response == _true || response == _false)
                    break;
                Console.WriteLine("Incorrect data!");
            }
            if (response == _true)
                return true;
            else
                return false;
        }

        static public void MessageResult(Player winner, Player loser)
        {
            Console.WriteLine("Winner is {0}! The sum of the winner's cards({1}) is greater than the sum of the {2}'s cards({3})", winner.Name, winner.Sum, loser.Name, loser.Sum);
        }

        static public void MessageTooMuch(Player player)
        {
            Console.WriteLine("Loser is {0}. The sum of the player's cards({1}) is greater than 21", player.Name, player.Sum);
        }

        static public void MessageDraw(Player p1, Player p2)
        {
            Console.WriteLine("It's draw. The sum of the {0}'s cards({1}) is equal the sum of the {2}'s cards({3})", p1.Name, p1.Sum, p2.Name, p2.Sum);
        }

        static public void ShowCards(Player player)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Card c in player.GiveAllCards())
                sb.Append(" |" + c.Denomination + c.Suit + "| ");
            Console.WriteLine("{0}'s cards: {1}", player.Name, sb.ToString());
        }

        static public void StartMessage(Player p1, Player p2)
        {
            Console.WriteLine("****{0} {1} - {2} {3}****", p1.Name, p1.Wins, p2.Wins, p2.Name);
            Console.WriteLine("****Game started****");
        }

    }
}
