using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ProiectCFLP
{
    public class Game
    {
        public List<Card> Deck { get; set; }
        public List<Player> Players { get; set; }
        public Card CurrentCard { get; set; }
        public CardColor ColorAfterWild { get; set; }
        public int CurrentPlayerIndex { get; set; }

        private int step = 1; // +1 for clockwise, -1 for counterclockwise

        public Game(List<Player> players)
        {
            Players = players;
            Deck = GenerateDeck();
            ShuffleDeck();
            DealInitialCards();

            // Set the initial current card by taking the last card in the deck
            CurrentCard = Deck[^1]; // Retrieves the last card
            ColorAfterWild = CurrentCard.Color;

            Deck.RemoveAt(Deck.Count - 1); // Removes it from the deck

            CurrentPlayerIndex = 0;
        }
        private List<Card> GenerateDeck()
        {
            var deck = new List<Card>();

            // Generate colored cards (Red, Yellow, Green, Blue)
            foreach (CardColor color in Enum.GetValues(typeof(CardColor)))
            {
                if (color == CardColor.Wild) continue; // Skip Wild for now

                // Number cards: one '0', two copies of '1-9'
                deck.Add(new Card(color, 0)); // One '0'
                for (int number = 1; number <= 9; number++)
                {
                    deck.Add(new Card(color, number)); // First copy
                    deck.Add(new Card(color, number)); // Second copy
                }

                // Two copies of action cards: Skip, Reverse, DrawTwo
                deck.Add(new Card(color, CardType.Skip));
                deck.Add(new Card(color, CardType.Skip));
                deck.Add(new Card(color, CardType.Reverse));
                deck.Add(new Card(color, CardType.Reverse));
                deck.Add(new Card(color, CardType.DrawTwo));
                deck.Add(new Card(color, CardType.DrawTwo));
            }

            // Generate Wild cards
            for (int i = 0; i < 4; i++)
            {
                deck.Add(new Card(CardColor.Wild, CardType.Wild));
                deck.Add(new Card(CardColor.Wild, CardType.DrawFour));
            }

            return deck;
        }

        private void ShuffleDeck()
        {
            Random rng = new Random();
            int n = Deck.Count;

            // Fisher-Yates shuffle
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1); // Random index from 0 to i
                                         // Swap elements at i and j
                var temp = Deck[i];
                Deck[i] = Deck[j];
                Deck[j] = temp;
            }
        }

        public bool IsValidMove(Card card)
        {

            if (card.Color == CardColor.Wild)
            {
                return true; // Wild cards are always valid
            }

            if (CurrentCard.Color == CardColor.Wild)
            {
                if (card.Color == ColorAfterWild)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (card.Color == CurrentCard.Color)
            {
                return true; // Same color
            }

            if (card.Number == CurrentCard.Number)
            {
                return true; // Same number
            }

            return false; // Otherwise, the card is invalid
        }


        public void PlayCard(Player player, Card card)
        {
            if (IsValidMove(card))
            {
                CurrentCard = card;
                player.PlayCard(card);
                ApplyCardEffect(card);
            }
        }

        public void Next()
        {
            CurrentPlayerIndex = (CurrentPlayerIndex + step) % Players.Count;
            if (CurrentPlayerIndex < 0)
            {
                CurrentPlayerIndex += Players.Count;
            }
        }

        private void ApplyCardEffect(Card card)
        {
            if (card.Type == CardType.Skip)
            {
                Next();
            }
            else if (card.Type == CardType.Reverse)
            {
                step = -step;
                Next();
            }
            else if (card.Type == CardType.DrawTwo)
            {
                Next();

                var player = Players[CurrentPlayerIndex];

                if (Deck.Count > 0)
                {
                    // Draw a card for the current player
                    var new_card = Deck[^1];
                    Deck.RemoveAt(Deck.Count - 1);
                    player.DrawCard(new_card);

                    new_card = Deck[^1];
                    Deck.RemoveAt(Deck.Count - 1);
                    player.DrawCard(new_card);

                    Next();
                }
            }
            else if (card.Type == CardType.DrawFour)
            {
                Next();

                var player = Players[CurrentPlayerIndex];

                if (Deck.Count > 0)
                {
                    // Draw a card for the current player
                    var new_card = Deck[^1];
                    Deck.RemoveAt(Deck.Count - 1);
                    player.DrawCard(new_card);

                    new_card = Deck[^1];
                    Deck.RemoveAt(Deck.Count - 1);
                    player.DrawCard(new_card);

                    new_card = Deck[^1];
                    Deck.RemoveAt(Deck.Count - 1);
                    player.DrawCard(new_card);

                    new_card = Deck[^1];
                    Deck.RemoveAt(Deck.Count - 1);
                    player.DrawCard(new_card);

                    Next();

                    PromptForNextColor();
                }
            }
            else if (card.Type == CardType.Wild)     // TO BE Improoved
            {
                PromptForNextColor();
            }
        }
        public void PromptForNextColor()
        {
            // Create a pop-up form
            Form popup = new Form
            {
                Text = "Choose the Next Color",
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(300, 300),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                TopMost = true
            };

            // Create color selection buttons
            Button redButton = new Button { Text = "Red", BackColor = Color.Red, Location = new Point(30, 50), Size = new Size(100, 50) };
            Button yellowButton = new Button { Text = "Yellow", BackColor = Color.Yellow, Location = new Point(150, 50), Size = new Size(100, 50) };
            Button greenButton = new Button { Text = "Green", BackColor = Color.Green, Location = new Point(30, 120), Size = new Size(100, 50) };
            Button blueButton = new Button { Text = "Blue", BackColor = Color.Blue, Location = new Point(150, 120), Size = new Size(100, 50) };

            // Add event handlers
            redButton.Click += (s, e) => { ColorAfterWild = CardColor.Red; popup.Close(); };
            yellowButton.Click += (s, e) => { ColorAfterWild = CardColor.Yellow; popup.Close(); };
            greenButton.Click += (s, e) => { ColorAfterWild = CardColor.Green; popup.Close(); };
            blueButton.Click += (s, e) => { ColorAfterWild = CardColor.Blue; popup.Close(); };

            // Add buttons to the pop-up form
            popup.Controls.AddRange(new Control[] { redButton, yellowButton, greenButton, blueButton });

            // Show the form as a dialog
            popup.ShowDialog();
        }

        private void DealInitialCards()
        {
            // Each player receives 7 cards at the start of the game
            int cardsPerPlayer = 7;

            // Loop through each player and deal the required number of cards
            foreach (var player in Players)
            {
                for (int i = 0; i < cardsPerPlayer; i++)
                {
                    // Remove the top card from the deck and add it to the player's hand
                    player.DrawCard(Deck[^1]);
                    Deck.RemoveAt(Deck.Count - 1);
                }
            }
        }

    }

}
