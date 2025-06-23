using System.Net;

namespace Terminarz
{
    internal class FriendsView
    {
        private readonly SemaphoreSlim _lock = new(1, 1);

        private readonly Dictionary<Guid, Friend> _cache = new();

        private readonly FlowLayoutPanel _flowLayoutPanel;

        private readonly TextBox _friendNameInput;
        private readonly TextBox _friendSurnameInput;
        private readonly TextBox _friendPhoneInput;
        private readonly TextBox _friendEmailInput;
        private readonly TextBox _friendSocialInput;
        private readonly TextBox _friendFilterInput;

        private readonly ListBox _friendPhoneList;
        private readonly ListBox _friendEmailList;
        private readonly ListBox _friendSocialsList;

        private readonly Button _friendPhoneAdd;
        private readonly Button _friendPhoneRemove;
        private readonly Button _friendEmailAdd;
        private readonly Button _friendEmailRemove;
        private readonly Button _friendSocialsAdd;
        private readonly Button _friendSocialsRemove;
        private readonly Button _friendSave;
        private readonly Button _friendRemove;

        private Friend _friendToModify = new Friend();
        private string? _filter = null;

        public FriendsView(FlowLayoutPanel flowLayoutPanel,
            TextBox friendNameInput, 
            TextBox friendSurnameInput,
            TextBox friendPhoneInput,
            TextBox friendEmailInput,
            TextBox friendSocialInput,
            TextBox friendFilterInput,
            ListBox friendPhoneList, 
            ListBox friendEmailList, 
            ListBox friendSocialsList,
            Button friendPhoneAdd,
            Button friendPhoneRemove,
            Button friendEmailAdd,
            Button friendEmailRemove, 
            Button friendSocialsAdd, 
            Button friendSocialsRemove, 
            Button friendSave,
            Button friendRemove)
        {
            _flowLayoutPanel = flowLayoutPanel;
            _friendNameInput = friendNameInput;
            _friendSurnameInput = friendSurnameInput;
            _friendPhoneInput = friendPhoneInput;
            _friendEmailInput = friendEmailInput;
            _friendSocialInput = friendSocialInput;
            _friendFilterInput = friendFilterInput;
            _friendPhoneList = friendPhoneList;
            _friendEmailList = friendEmailList;
            _friendSocialsList = friendSocialsList;
            _friendPhoneAdd = friendPhoneAdd;
            _friendPhoneRemove = friendPhoneRemove;
            _friendEmailAdd = friendEmailAdd;
            _friendEmailRemove = friendEmailRemove;
            _friendSocialsAdd = friendSocialsAdd;
            _friendSocialsRemove = friendSocialsRemove;
            _friendSave = friendSave;
            _friendRemove = friendRemove;

            _friendPhoneAdd.Click += (s, e) => { Utils.AddTextToListBox(_friendPhoneList, _friendPhoneInput.Text, Utils.IsValidPhoneNumber, "Numer telefonu jest nieprawidłowy"); };
            _friendEmailAdd.Click += (s, e) => { Utils.AddTextToListBox(_friendEmailList, _friendEmailInput.Text, Utils.IsValidEmail, "Email jest nieprawidłowy"); };
            _friendSocialsAdd.Click += (s, e) => { Utils.AddTextToListBox(_friendSocialsList, _friendSocialInput.Text, Utils.NotEmptyAndAllLetters, "Sociale nie moga byc puste"); };

            _friendPhoneRemove.Click += (s, e) => { Utils.RemoveSelectedTextFromListBox(_friendPhoneList); };
            _friendEmailRemove.Click += (s, e) => { Utils.RemoveSelectedTextFromListBox(_friendEmailList); };
            _friendSocialsRemove.Click += (s, e) => { Utils.RemoveSelectedTextFromListBox(_friendSocialsList); };

            _friendSave.Click += async (s, e) => await OnFriendSave();
            _friendRemove.Click += async (s, e) => await OnFriendDelete();

            _flowLayoutPanel.Click += (s, e) => ClearSelection();

            _friendFilterInput.TextChanged += (s, e) => OnFilter();
        }

        public async void Load()
        {
            await _lock.WaitAsync();
            try
            {
                List<Friend>? friends = await Utils.GetObjectsAsync<Friend>("friends");
                if(friends != null)
                    _flowLayoutPanel.Invoke(() =>
                    {
                        foreach (Friend friend in friends)
                            _cache[friend.Identifier] = friend;

                        Render();
                    });
            }
            finally
            {
                _lock.Release();
            }
        }

        private void ClearSelection()
        {
            _friendToModify = new Friend();
            ClearInput();
        }

        private async Task OnFriendPhotoClicked(object sender, EventArgs e, Friend friend)
        {
            if (e is not MouseEventArgs mouseEventArgs)
                return;

            if (mouseEventArgs.Button == MouseButtons.Left)
                await OnFriendPhotoUpdate(friend);
            else if(mouseEventArgs.Button == MouseButtons.Right)
                await OnFriendPhotoDelete(friend);
        }

        private async Task OnFriendPhotoUpdate(Friend friend)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Wybierz zdjęcie";
                ofd.Filter = "Pliki graficzne|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        friend.PhotoPath = ofd.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nie udało się załadować obrazu: " + ex.Message);
                    }
                }
            }

            await SaveFriend(friend);
        }

        private async Task OnFriendPhotoDelete(Friend friend)
        {
            friend.PhotoPath = null;
            await SaveFriend(friend);
        }

        private async Task OnFriendSave()
        {
            Friend friend = _friendToModify;

            string name = Utils.TrimInput(_friendNameInput.Text);
            Console.WriteLine(_friendNameInput.Text);
            if (!Utils.NotEmptyAndAllLetters(name))
            {
                MessageBox.Show("Imie nie moze byc puste oraz musi skladac sie z liter!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string surname = Utils.TrimInput(_friendSurnameInput.Text);
            if (!Utils.NotEmptyAndAllLetters(name))
            {
                MessageBox.Show("Nazwisko nie moze byc puste oraz musi skladac sie z liter!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> emails = _friendEmailList.Items.Cast<string>().ToList();
            List<string> phoneNumbers = _friendPhoneList.Items.Cast<string>().ToList();
            List<string> socials = _friendSocialsList.Items.Cast<string>().ToList();

            friend.Name = name;
            friend.Surname = surname;
            friend.Emails.Clear();
            friend.PhoneNumbers.Clear();
            friend.SocialMedia.Clear();

            friend.Emails.AddRange(emails);
            friend.PhoneNumbers.AddRange(phoneNumbers);
            friend.SocialMedia.AddRange(socials);

            if (!_cache.ContainsKey(friend.Identifier))
                _cache[friend.Identifier] = friend;

            await SaveFriend(friend);
        }
        private async Task OnFriendDelete()
        {
            Guid identifier = _friendToModify.Identifier;

            if (!_cache.Remove(identifier))
                return;

            Console.WriteLine($"delete friend {identifier}");

            await _lock.WaitAsync();

            try
            {
                await WebUtils.Delete($"friends/delete/{identifier}");
            }
            finally
            {
                _lock.Release();
            }

            _friendToModify = new Friend();
            ClearInput();
            Render();
        }

        private async Task SaveFriend(Friend friend)
        {
            await _lock.WaitAsync();
            try
            {
                await WebUtils.Post("friends/save", friend);
            }
            finally
            {
                _lock.Release();
            }

            _friendToModify = new Friend();
            ClearInput();
            Render();
        }

        private void OnFilter()
        {
            _filter = _friendFilterInput.Text;
            Render();
        }

        private void OnFriendClicked(Friend friend)
        {
            _friendToModify = friend;
            ClearInput();
            FillInput(friend);
        }

        private void Render()
        {
            _flowLayoutPanel.Controls.Clear();

            Friend[] friends;
            if (string.IsNullOrEmpty(_filter))
                friends = [.. _cache.Values];
            else
            {
                friends = [.. _cache.Values.Where(f =>
                    f.Name.Contains(_filter, StringComparison.OrdinalIgnoreCase) ||
                    f.Surname.Contains(_filter, StringComparison.OrdinalIgnoreCase) ||
                    (f.Emails.Any(n => n.Contains(_filter, StringComparison.OrdinalIgnoreCase))) ||
                    (f.PhoneNumbers.Any(t => t.Contains(_filter, StringComparison.OrdinalIgnoreCase))) ||
                    (f.SocialMedia.Any(t => t.Contains(_filter, StringComparison.OrdinalIgnoreCase)))
                )];
            }

            foreach (Friend friend in friends)
                CreateTile(friend);
        }

        private void CreateTile(Friend friend)
        {
            FriendTile friendTile = new FriendTile(friend);
            friendTile.Click += (s, e) => OnFriendClicked(friend);
            friendTile.PictureBox.Click += async (s, e) => await OnFriendPhotoClicked(s,e,friend);

            friendTile.Render();

            _flowLayoutPanel.Controls.Add(friendTile);
        }

        private void FillInput(Friend friend)
        {
            ClearInput();

            _friendNameInput.Text = friend.Name;
            _friendSurnameInput.Text = friend.Surname;
            foreach (var v in friend.Emails)
                _friendEmailList.Items.Add(v);

            foreach (var v in friend.PhoneNumbers)
                _friendPhoneList.Items.Add(v);

            foreach (var v in friend.SocialMedia)
                _friendSocialsList.Items.Add(v);
        }

        private void ClearInput()
        {
            _friendNameInput.Text = "";
            _friendSurnameInput.Text = "";
            _friendEmailInput.Text = "";
            _friendPhoneInput.Text = "";
            _friendSocialInput.Text = "";
            _friendEmailList.Items.Clear();
            _friendPhoneList.Items.Clear();
            _friendSocialsList.Items.Clear();
        }
    }
}
