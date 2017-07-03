using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Round
    {
        private const int LIMIT = 21;
        public Player player;
        public Player pc;
        private CardsDeck deck = new CardsDeck();
        private static Random random = new Random();

        private bool CheckResult(Player player)
        {
            if (player.Sum <= LIMIT)
                return true;
            else
                return false;
        }

        public bool PlayerStep()
        {
            while (true)
            {
                GameIO.ShowCards(player);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Your turn:");
                sb.AppendLine("Hint -> H");
                sb.AppendLine("Stand -> S");
         
                bool response = GameIO.PlayerStep(sb.ToString(), "H", "S");

                if (response == true)
                {
                    player.GetCard(deck.GiveCard());

                    if (CheckResult(player) == false)
                        return false;
                }

                if (response == false)
                {
                    if (CheckResult(player) == true)
                        return true;
                    else
                        return false;
                }
            }
        }

        //The percentage of answer "request a card" from the PC is calculated 
        //depending on the sum of cards.
        private bool GetResponseFromPC(int percentage)
        {
            return random.Next(0, 100) < percentage;
        }

        private bool SimulatePCResponse()
        {
            bool response = true;

            if (pc.Sum == 21)
            {
                response = false;
            }

            if (pc.Sum <= 15)
            {
                response = GetResponseFromPC(50);
            }

            if (pc.Sum > 15 && pc.Sum < 19)
            {
                response = GetResponseFromPC(30);
            }

            if (pc.Sum >= 19)
            {
                response = GetResponseFromPC(10);
            }

            return response;
        }

        private bool PCStepResult()
        {
            while (true)
            {
                bool response = SimulatePCResponse();

                if (response == true)
                {
                    pc.GetCard(deck.GiveCard());

                    if (CheckResult(pc) == false)
                        return false;
                }

                if (response == false)
                {
                    if (CheckResult(pc) == true)
                        return true;
                    else
                        return false;
                } 
            }
        }

        private void GiveCards()
        {
            for (int i = 0; i < 2; i++)
            {
                player.GetCard(deck.GiveCard());
                pc.GetCard(deck.GiveCard());
            }
        }

        private void FindWinner()
        {
            if (pc.Sum > player.Sum)
            {
                GameIO.MessageResult(pc, player);
                pc.Victory();
            }
            else if (player.Sum > pc.Sum)
            {
                GameIO.MessageResult(player, pc);
                player.Victory();
            }
            else
            {
                GameIO.MessageDraw(player, pc);
            }
        }

        private void CheckGameResult(bool playerResult, bool pcResult)
        {
            
            if (playerResult == false)
            {
                GameIO.ShowCards(player);
                GameIO.MessageTooMuch(player);
                pc.Victory();
            }

            if (pcResult == false && playerResult != false)
            {
                GameIO.ShowCards(pc);
                GameIO.MessageTooMuch(pc);
                player.Victory();
            }

            if (pcResult != false && playerResult != false)
            {
                GameIO.ShowCards(pc);
                FindWinner();
            }
        }

        public void PlayRound()
        {
            bool pcResult, playerResult;
            GameIO.StartMessage(player, pc);
            deck.ShuffleCards();
            GiveCards();
            playerResult = PlayerStep();
            pcResult = PCStepResult();
            CheckGameResult(playerResult, pcResult);
            FinishRound();
        }

        public void FinishRound()
        {
            pc.ClearCards();
            player.ClearCards();
        }
    }
}
