namespace Terminarz
{
    internal partial class NoteTile : UserControl
    {
        public event EventHandler Deleted;
        public event EventHandler Save;

        private Note _note;
        private TextBox _titleBox;
        private TextBox _descriptionBox;
        private TextBox _createdAt;
        private TextBox _modifiedAt;
        private Button _deleteButton;

        public Note Note => _note;

        public string Title => _titleBox.Text;
        public string Description => _descriptionBox.Text;

        public NoteTile(Note note)
        {
            _note = note;

            Width = 250;
            Height = 200;
            BackColor = Color.LightGoldenrodYellow;
            Margin = new Padding(10);
            BorderStyle = BorderStyle.FixedSingle;

            _titleBox = new TextBox()
            {
                Text = note.Title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 30,
                BorderStyle = BorderStyle.FixedSingle
            };

            _descriptionBox = new TextBox()
            {
                Text = note.Description,
                Multiline = true,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = ScrollBars.Vertical
            };

            _createdAt = new TextBox()
            {
                Text = $"Utworzono: {note.Created:dd.MM.yyyy HH:mm}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 30,
                BorderStyle = BorderStyle.FixedSingle
            };

            _modifiedAt = new TextBox()
            {
                Text = GetModifiedAt(),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 30,
                BorderStyle = BorderStyle.FixedSingle
            };

            _deleteButton = new Button()
            {
                Text = "Usuń",
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.LightCoral
            };

            _deleteButton.Click += (s, e) => Deleted?.Invoke(this, EventArgs.Empty);

            _titleBox.Leave += (s, e) => Save?.Invoke(this, EventArgs.Empty);
            _descriptionBox.Leave += (s, e) => Save?.Invoke(this, EventArgs.Empty);

            _titleBox.KeyDown += HandleKeyboardEnter;
            _descriptionBox.KeyDown += HandleKeyboardEnter;

            Controls.Add(_descriptionBox);
            Controls.Add(_deleteButton);
            Controls.Add(_titleBox);
            Controls.Add(_createdAt);
            Controls.Add(_modifiedAt);
        }

        public void UpdateModifiedAt()
        {
            _modifiedAt.Text = GetModifiedAt();
        }

        private void HandleKeyboardEnter(object? o, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            Save?.Invoke(this, EventArgs.Empty);
        }

        private string GetModifiedAt()
        {
            return _note.Updated == null ? "Brak modyfikacji" : $"Zmodyfikowano {_note.Updated:dd.MM.yyyy HH:mm}";
        }
    }
}
