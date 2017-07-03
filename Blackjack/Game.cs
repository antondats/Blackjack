using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Game
    {
        public Player _player;
        public Player _pc = new Player { Name = "Denis" };


        //public Game(Player people)
        //{
        //    _player = people;
        //    _pc = new Player { Name = "Denis" };
        //}


        public void Play()
        {
            Round round = new Round { player = _player, pc = _pc};
            round.PlayRound();
        }
    }
}
