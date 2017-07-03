using Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        public Suits Suit { get; set; }
        public string Denomination { get; set; } 
        public int Value { get; set; }
    }
}
