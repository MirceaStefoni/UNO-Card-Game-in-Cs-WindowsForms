namespace ProiectCFLP
{

    public partial class Form1 : Form
    {
        private Game game; // Game instance to control game logic
        private Bitmap spriteSheet;
        private const int CardWidth = 162; // Width of a single card in the sprite sheet
        private const int CardHeight = 256; // Height of a single card in the sprite sheet // 280 worked great

        private PictureBox currentCardPictureBox;


        // Modify constructor to accept a Game instance
        public Form1(Game game)
        {
            InitializeComponent();
            this.game = game;

            this.Icon = new Icon(@"assets\icon.ico");

            // Define the relative path
            string relativePath = @"assets\uno_cards.png";

            // Combine the relative path with the base directory
            string spriteSheetPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            // Load the sprite sheet
            if (File.Exists(spriteSheetPath))
            {
                spriteSheet = new Bitmap(spriteSheetPath);
            }
            else
            {
                // Handle the case where the file doesn't exist
                MessageBox.Show($"Sprite sheet not found at: {spriteSheetPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FileNotFoundException("Sprite sheet not found", spriteSheetPath);
            }


            DisplayCard(0, 0, new Point(65, 64));
            DisplayCard(0, 0, new Point(75, 76));
            DisplayCard(0, 0, new Point(85, 88));
            DisplayCard(0, 0, new Point(95, 100));
            DisplayCard(0, 0, new Point(95, 100)); // dummy value 

            UpdateGameUI();
        }

        private void DisplayCard(int col, int row, Point location)
        {
            // Crop the card from the sprite sheet
            Rectangle cardRect = new Rectangle(col * CardWidth + (col + 1) * 20, row * CardHeight + (row + 1) * 22, CardWidth, CardHeight);
            Bitmap card = spriteSheet.Clone(cardRect, spriteSheet.PixelFormat);

            // Create a PictureBox to display the card
            PictureBox pictureBox = new PictureBox
            {
                Image = card,
                Location = location,
                Size = new Size(CardWidth, CardHeight),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // Add the PictureBox to the form
            Controls.Add(pictureBox);

            currentCardPictureBox = pictureBox;
        }


        // Initialize the UI with current game state
        private void UpdateGameUI()
        {
            UpdateCurrentCard();
            UpdateCurrentPlayer();
            UpdatePlayerHand();
        }

        private void UpdateCurrentCard()
        {
            // Display the current card in the discard pile
            currentCardLabel.Text = $"Current Card: {game.CurrentCard}";


            // If a current card picture box already exists, remove it
            if (currentCardPictureBox != null)
            {
                Controls.Remove(currentCardPictureBox);
                currentCardPictureBox.Dispose();  // Dispose the old PictureBox to free up memory
            }

            int x = 670;
            int y = 70;

            switch (game.CurrentCard.Color)
            {
                case CardColor.Yellow:

                    if (game.CurrentCard.Type == CardType.Number)
                    {
                        if (game.CurrentCard.Number == 0)
                        {
                            DisplayCard(9, 1, new Point(x, y));
                        }
                        else
                        {
                            DisplayCard(game.CurrentCard.Number - 1, 1, new Point(x, y));
                        }
                    }
                    else
                    {
                        if (game.CurrentCard.Type == CardType.Skip)
                        {
                            DisplayCard(11, 1, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.Reverse)
                        {
                            DisplayCard(12, 1, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.DrawTwo)
                        {
                            DisplayCard(10, 1, new Point(x, y));
                            break;
                        }

                    }

                    break;

                case CardColor.Red:

                    if (game.CurrentCard.Type == CardType.Number)
                    {
                        if (game.CurrentCard.Number == 0)
                        {
                            DisplayCard(9, 3, new Point(x, y));
                        }
                        else
                        {
                            DisplayCard(game.CurrentCard.Number - 1, 3, new Point(x, y));
                        }
                    }
                    else
                    {
                        if (game.CurrentCard.Type == CardType.Skip)
                        {
                            DisplayCard(11, 3, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.Reverse)
                        {
                            DisplayCard(12, 3, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.DrawTwo)
                        {
                            DisplayCard(10, 3, new Point(x, y));
                            break;
                        }

                    }
                    break;

                case CardColor.Green:

                    if (game.CurrentCard.Type == CardType.Number)
                    {
                        if (game.CurrentCard.Number == 0)
                        {
                            DisplayCard(9, 4, new Point(x, y));
                        }
                        else
                        {
                            DisplayCard(game.CurrentCard.Number - 1, 4, new Point(x, y));
                        }
                    }
                    else
                    {
                        if (game.CurrentCard.Type == CardType.Skip)
                        {
                            DisplayCard(11, 4, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.Reverse)
                        {
                            DisplayCard(12, 4, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.DrawTwo)
                        {
                            DisplayCard(10, 4, new Point(x, y));
                            break;
                        }

                    }
                    break;

                case CardColor.Blue:

                    if (game.CurrentCard.Type == CardType.Number)
                    {
                        if (game.CurrentCard.Number == 0)
                        {
                            DisplayCard(9, 2, new Point(x, y));
                        }
                        else
                        {
                            DisplayCard(game.CurrentCard.Number - 1, 2, new Point(x, y));
                        }
                    }
                    else
                    {
                        if (game.CurrentCard.Type == CardType.Skip)
                        {
                            DisplayCard(11, 2, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.Reverse)
                        {
                            DisplayCard(12, 2, new Point(x, y));
                            break;
                        }
                        if (game.CurrentCard.Type == CardType.DrawTwo)
                        {
                            DisplayCard(10, 2, new Point(x, y));
                            break;
                        }

                    }
                    break;

                case CardColor.Wild:

                    if (game.CurrentCard.Type == CardType.DrawFour)
                    {
                        DisplayCard(2, 0, new Point(x, y));
                        break;
                    }

                    if (game.CurrentCard.Type == CardType.Wild)
                    {
                        DisplayCard(1, 0, new Point(x, y));
                        break;
                    }

                    break;
            }
        }

        private void UpdateCurrentPlayer()
        {
            // Display the name of the current player
            currentPlayerLabel.Text = $"Current Player: {game.Players[game.CurrentPlayerIndex].Name}";
        }

        private void UpdatePlayerHand()
        {
            playerHandListBox.Items.Clear();
            var player = game.Players[game.CurrentPlayerIndex];

            foreach (var card in player.Hand)
            {
                playerHandListBox.Items.Add(card.ToString()); // Assuming ToString() provides a nice representation of the card
            }
        }

        private void DrawCardButton_Click(object sender, EventArgs e)
        {
            var player = game.Players[game.CurrentPlayerIndex];

            if (game.Deck.Count > 0)
            {
                // Draw a card for the current player
                var card = game.Deck[^1];
                game.Deck.RemoveAt(game.Deck.Count - 1);
                player.DrawCard(card);

                // End turn and Update player and player hand
                game.Next();
                UpdateGameUI();
            }
            else
            {
                MessageBox.Show("The draw deck is empty!");
            }
        }

        private void PlayCardButton_Click(object sender, EventArgs e)
        {
            var player = game.Players[game.CurrentPlayerIndex];

            // Check if a card is selected in the player's hand
            if (playerHandListBox.SelectedIndex != -1 && playerHandListBox.SelectedIndex < player.Hand.Count)
            {
                // Get the selected card from the player's hand
                var cardToPlay = player.Hand[playerHandListBox.SelectedIndex];

                // Attempt to play the card
                if (game.IsValidMove(cardToPlay))
                {
                    game.PlayCard(player, cardToPlay);

                    // Update the UI
                    UpdateGameUI();

                    // Check for win condition
                    if (player.Hand.Count == 0)
                    {
                        MessageBox.Show($"{player.Name} has won the game!");

                        // Wait for 5 seconds before closing the application
                        Task.Delay(5000);

                        // Close the application
                        Application.Exit();
                        return;
                    }

                    // End turn and Update player and player hand
                    game.Next();
                    UpdateGameUI();
                }
                else
                {
                    MessageBox.Show("Invalid move! Card must match the color or number of the current card.");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid card to play.");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void currentCardLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Force the form to full-screen mode without any borders or taskbar
            this.WindowState = FormWindowState.Normal; 
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.FromHandle(this.Handle).Bounds; 
            this.TopMost = true; 

            // Define the relative path
            string relativePath = @"assets\background.jpg";

            // Combine the relative path with the base directory
            string backgroundImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            // Debug output for verification
            Console.WriteLine($"Loading background image from: {backgroundImagePath}");

            // Load the background image
            if (File.Exists(backgroundImagePath))
            {
                this.BackgroundImage = Image.FromFile(backgroundImagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch; // Adjust to fill the form
            }
            else
            {
                // Handle the case where the file doesn't exist
                MessageBox.Show($"Background image not found at: {backgroundImagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FileNotFoundException("Background image not found", backgroundImagePath);
            }
        }


        private void discardPilePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void drawPilePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void currentPlayerLabel_Click(object sender, EventArgs e)
        {

        }

        private void playerHandListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}