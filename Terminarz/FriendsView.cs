using System.ComponentModel;

namespace Terminarz
{
    internal class FriendsView
    {
        private readonly IFriendsRepository _friendsRepository;
        private readonly DataGridView _friendsDataGridView;
        private readonly BindingSource _bindingSource;

        private string _filter;
        private Friend? _selectedFriend;

        public FriendsView(IFriendsRepository friendsRepository, DataGridView friendsDataGridView)
        {
            _friendsRepository = friendsRepository;
            _friendsDataGridView = friendsDataGridView;
            _bindingSource = new BindingSource();
        }

        public void Load()
        {
            _bindingSource.DataSource = _friendsRepository.GetBindingList();
            _friendsDataGridView.DataSource = _bindingSource;
        }

        public void OnCellClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.RowIndex >= _friendsDataGridView.Rows.Count)
                return;

            var row = _friendsDataGridView.Rows[e.RowIndex];
            var friend = row.DataBoundItem as Friend;

            if (friend == null)
                return;

            _selectedFriend = friend;
        }

        public void OnAddPhoneNumber(ListBox listBox, string phoneNumber)
        {
            Utils.AddTextToListBox(listBox, phoneNumber, Utils.IsValidPhoneNumber, "Nieprawidłowy numer telefonu");
        }

        public void OnRemovePhoneNumber(ListBox listBox)
        {
            Utils.RemoveSelectedTextFromListBox(listBox);
        }

        public void OnAddEmail(ListBox listBox, string email)
        {
            Utils.AddTextToListBox(listBox, email, Utils.IsValidEmail, "Nieprawidłowy email");
        }

        public void OnRemoveEmail(ListBox listBox)
        {
            Utils.RemoveSelectedTextFromListBox(listBox);
        }

        public void OnDeleteFriend()
        {
            if (_selectedFriend == null)
                return;

            _friendsRepository.Delete(_selectedFriend.Id);

            FilterFriends();
        }

        public void OnSaveChanges()
        {
            _friendsRepository.SaveAll();

            MessageBox.Show("Zapisano zmiany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public bool AddFriend(string name, string surname, ListBox emailList, ListBox phoneNumberList)
        {
            name = Utils.TrimInput(name);
            surname = Utils.TrimInput(surname);

            if (!Utils.NotEmptyAndAllLetters(name))
            {
                MessageBox.Show("Imię może zawierać tylko litery i nie może być puste.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Utils.NotEmptyAndAllLetters(surname))
            {
                MessageBox.Show("Nazwisko może zawierać tylko litery i nie może być puste.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string emails = Utils.JoinStringsFromListBox(emailList);
            string phoneNumbers = Utils.JoinStringsFromListBox(phoneNumberList);

            Friend friend = new Friend
            {
                Id = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Name = name,
                Surname = surname,
                Emails = emails,
                PhoneNumbers = phoneNumbers
            };

            if (_friendsRepository.FindAll(x => x.Equals(friend)).Count != 0)
            {
                MessageBox.Show("Istnieje już ktoś taki...", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _friendsRepository.Save(friend);

            MessageBox.Show("Dodano nowego znajomego!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }

        public void OnFilterChanged(string text)
        {
            _filter = Utils.TrimInput(text);
            FilterFriends();
        }

        public void FilterFriends()
        {
            if (string.IsNullOrEmpty(_filter))
                _bindingSource.DataSource = _friendsRepository.GetBindingList();
            else
            {
                var filtered = _friendsRepository
                    .FindAll(f =>
                     f.Name.Contains(_filter, StringComparison.OrdinalIgnoreCase) || 
                     f.Surname.Contains(_filter, StringComparison.OrdinalIgnoreCase) ||
                     f.Emails.Contains(_filter, StringComparison.OrdinalIgnoreCase) ||
                     f.PhoneNumbers.Contains(_filter, StringComparison.OrdinalIgnoreCase)
                     );

                _bindingSource.DataSource = new BindingList<Friend>(filtered);
            }

            _selectedFriend = null;
            _friendsDataGridView.ClearSelection();
        }

        public void ValidateCells(DataGridViewCellValidatingEventArgs e)
        {
            var headerText = _friendsDataGridView.Columns[e.ColumnIndex].HeaderText;
            string input = Utils.TrimInput(e.FormattedValue?.ToString() ?? "");

            if (headerText == "Name" || headerText == "Surname")
            {
                if (!Utils.NotEmptyAndAllLetters(input))
                {
                    e.Cancel = true;
                    MessageBox.Show("Tylko litery są zezwolone oraz zawartość imienia/nazwiska nie może być pusta.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (headerText == "Emails")
            {
                string? validationResult = GetCommaSepparatedInputValidation(input, Utils.IsValidEmail);

                if(validationResult != null)
                {
                    MessageBox.Show("Nieprawidłowy email: " + validationResult, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }

            if (headerText == "PhoneNumbers")
            {
                string? validationResult = GetCommaSepparatedInputValidation(input, Utils.IsValidPhoneNumber);

                if (validationResult != null)
                {
                    MessageBox.Show("Nieprawidłowy numer telefonu: " + validationResult, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private string? GetCommaSepparatedInputValidation(string input, Predicate<string> validator)
        {
            foreach (string val in input.Split(","))
            {
                if (string.IsNullOrEmpty(val))
                    continue;

                if (validator(Utils.TrimInput(val)))
                    continue;

                return val;
            }

            return null;
        }
    }
}
