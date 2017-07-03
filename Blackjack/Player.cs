using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        public string Name { get;  set; }
        protected List<Card> Cards = new List<Card>();
        public int Sum { get; private set; }
        public int Wins { get; private set; }

        public List<Card> GiveAllCards()
        {
            return Cards;
        }

        public void ClearCards()
        {
            Cards.Clear();
        }

        public void GetCard(Card card)
        {
            Cards.Add(card);
            GetSum();
        }

        private void GetSum() //Counts sum of all cards
        {
            Sum = Cards.Select(c => c.Value).Sum();
        }

        public void Victory()
        {
            Wins++;
        }

    }
}
