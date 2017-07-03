using Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class CardsDeck
    {
        private const int CARDS_DENOMINATION = 13;
        private List<Card> cards;
        private static Random r;

        public CardsDeck()
        {
            cards = new List<Card>();
            r = new Random();
            CreateCardsDeck();
        }

        private void CreateCardsDeck()
        {
            int value;
            string denomination;
            for (int i = 1; i <= CARDS_DENOMINATION; i++)
            {

                denomination = i.ToString();
                value = i;

                if (i == 1)
                {
                    denomination = "Ace";
                    value = 11;
                }
                if (i == 11)
                {
                    denomination = "Jack";
                    value = 10;
                }
                if (i == 12)
                {
                    denomination = "Queen";
                    value = 10;
                }
                if (i == 13)
                {
                    denomination = "King";
                    value = 10;
                }

                for (int j = 0; j < (Enum.GetValues(typeof(Suits))).Length; j++)
                {
                    cards.Add(new Card { Suit = (Suits)j, Denomination = denomination, Value = value });
                }
            }
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void ShuffleCards()
        {
            int index;
            Card temp;
            for (int i = 0; i < cards.Count; i++)
            {
                index = r.Next(i, cards.Count);
                temp = cards[i];
                cards[i] = cards[index];
                cards[index] = temp;
            }
        }

        public Card GiveCard()
        {
            Card card = new Card();
            card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return card;
        }
    }
}
