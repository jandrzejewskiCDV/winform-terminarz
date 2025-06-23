namespace Terminarz
{
    partial class FriendTile
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            _friendPicture = new PictureBox();
            _friendNameLabel = new Label();
            _friendSurnameLabel = new Label();
            _phones = new ListBox();
            _emails = new ListBox();
            _socials = new ListBox();
            ((System.ComponentModel.ISupportInitialize)_friendPicture).BeginInit();
            SuspendLayout();
            // 
            // _friendPicture
            // 
            _friendPicture.BackColor = SystemColors.ActiveBorder;
            _friendPicture.Location = new Point(3, 3);
            _friendPicture.Name = "_friendPicture";
            _friendPicture.Size = new Size(128, 128);
            _friendPicture.SizeMode = PictureBoxSizeMode.Zoom;
            _friendPicture.TabIndex = 0;
            _friendPicture.TabStop = false;
            // 
            // _friendNameLabel
            // 
            _friendNameLabel.AutoSize = true;
            _friendNameLabel.Location = new Point(137, 3);
            _friendNameLabel.Name = "_friendNameLabel";
            _friendNameLabel.Size = new Size(30, 15);
            _friendNameLabel.TabIndex = 1;
            _friendNameLabel.Text = "imie";
            // 
            // _friendSurnameLabel
            // 
            _friendSurnameLabel.AutoSize = true;
            _friendSurnameLabel.Location = new Point(193, 3);
            _friendSurnameLabel.Name = "_friendSurnameLabel";
            _friendSurnameLabel.Size = new Size(55, 15);
            _friendSurnameLabel.TabIndex = 2;
            _friendSurnameLabel.Text = "nazwisko";
            // 
            // _phones
            // 
            _phones.FormattingEnabled = true;
            _phones.Location = new Point(137, 21);
            _phones.Name = "_phones";
            _phones.Size = new Size(120, 34);
            _phones.TabIndex = 3;
            // 
            // _emails
            // 
            _emails.FormattingEnabled = true;
            _emails.Location = new Point(137, 61);
            _emails.Name = "_emails";
            _emails.Size = new Size(120, 34);
            _emails.TabIndex = 4;
            // 
            // _socials
            // 
            _socials.FormattingEnabled = true;
            _socials.Location = new Point(137, 101);
            _socials.Name = "_socials";
            _socials.Size = new Size(120, 34);
            _socials.TabIndex = 5;
            // 
            // FriendTile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_socials);
            Controls.Add(_emails);
            Controls.Add(_phones);
            Controls.Add(_friendSurnameLabel);
            Controls.Add(_friendNameLabel);
            Controls.Add(_friendPicture);
            Name = "FriendTile";
            Size = new Size(350, 150);
            ((System.ComponentModel.ISupportInitialize)_friendPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox _friendPicture;
        private Label _friendNameLabel;
        private Label _friendSurnameLabel;
        private ListBox _phones;
        private ListBox _emails;
        private ListBox _socials;
    }
}
