using System.Drawing;
using System.Windows.Forms;

namespace ProiectCFLP
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Label currentCardLabel;
        private ListBox playerHandListBox;
        private Button drawCardButton;
        private Button playCardButton;
        private Label currentPlayerLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            currentCardLabel = new Label();
            playerHandListBox = new ListBox();
            drawCardButton = new Button();
            playCardButton = new Button();
            currentPlayerLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // currentCardLabel
            // 
            currentCardLabel.AutoSize = true;
            currentCardLabel.BackColor = Color.Transparent;
            currentCardLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            currentCardLabel.Location = new Point(756, 33);
            currentCardLabel.Name = "currentCardLabel";
            currentCardLabel.Size = new Size(201, 35);
            currentCardLabel.TabIndex = 2;
            currentCardLabel.Text = "Current Card";
            currentCardLabel.Click += currentCardLabel_Click;
            // 
            // playerHandListBox
            // 
            playerHandListBox.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            playerHandListBox.ItemHeight = 26;
            playerHandListBox.Location = new Point(472, 722);
            playerHandListBox.Name = "playerHandListBox";
            playerHandListBox.Size = new Size(797, 212);
            playerHandListBox.TabIndex = 2;
            playerHandListBox.SelectedIndexChanged += playerHandListBox_SelectedIndexChanged;
            // 
            // drawCardButton
            // 
            drawCardButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            drawCardButton.Location = new Point(683, 951);
            drawCardButton.Name = "drawCardButton";
            drawCardButton.Size = new Size(134, 47);
            drawCardButton.TabIndex = 3;
            drawCardButton.Text = "Draw Card";
            drawCardButton.Click += DrawCardButton_Click;
            // 
            // playCardButton
            // 
            playCardButton.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            playCardButton.Location = new Point(949, 951);
            playCardButton.Name = "playCardButton";
            playCardButton.Size = new Size(134, 47);
            playCardButton.TabIndex = 5;
            playCardButton.Text = "Play Card";
            playCardButton.Click += PlayCardButton_Click;
            // 
            // currentPlayerLabel
            // 
            currentPlayerLabel.AutoSize = true;
            currentPlayerLabel.BackColor = Color.Transparent;
            currentPlayerLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            currentPlayerLabel.Location = new Point(683, 664);
            currentPlayerLabel.Name = "currentPlayerLabel";
            currentPlayerLabel.Size = new Size(355, 35);
            currentPlayerLabel.TabIndex = 5;
            currentPlayerLabel.Text = "Current Player: Player 1";
            currentPlayerLabel.Click += currentPlayerLabel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(94, 33);
            label1.Name = "label1";
            label1.Size = new Size(223, 35);
            label1.TabIndex = 6;
            label1.Text = "Deck Of Cards\r\n";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label1);
            Controls.Add(currentCardLabel);
            Controls.Add(playerHandListBox);
            Controls.Add(drawCardButton);
            Controls.Add(playCardButton);
            Controls.Add(currentPlayerLabel);
            Name = "Form1";
            Text = "Uno Game";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
    }
}
