namespace Terminarz
{
    internal partial class FriendTile : UserControl
    {
        private Friend _friend;

        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                    if (control is not System.Windows.Forms.PictureBox)
                        control.Click += value;
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    if(control is not System.Windows.Forms.PictureBox)
                        control.Click -= value;
                }
            }
        }

        public PictureBox PictureBox => _friendPicture;

        public FriendTile(Friend friend)
        {
            _friend = friend;
            InitializeComponent();
        }

        public void Render()
        {
            _friendNameLabel.Text = _friend.Name;
            _friendSurnameLabel.Text = _friend.Surname;

            _emails.Items.Clear();
            _phones.Items.Clear();
            _socials.Items.Clear();

            foreach(var v in _friend.Emails)
                _emails.Items.Add(v);

            foreach (var v in _friend.PhoneNumbers)
                _phones.Items.Add(v);

            foreach (var v in _friend.SocialMedia)
                _socials.Items.Add(v);

            string? path = _friend.PhotoPath;

            if (path == null || !File.Exists(path))
                return;

            try
            {
                _friendPicture.Image = Image.FromFile(path);
            }
            catch { }
        }
    }
}
