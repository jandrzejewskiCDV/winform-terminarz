using System.Net;
using System.Text.RegularExpressions;

namespace Terminarz
{
    internal class MeetingsView
    {
        private static readonly Regex ReminderFormat = new Regex(@"^(\d+[dhm](\s+)?)+$", RegexOptions.IgnoreCase);

        private readonly SemaphoreSlim _lock = new(1, 1);
        private readonly Dictionary<Guid, Meeting> _cache = new();

        private readonly ListView _meetingsListView;
        private readonly TextBox _meetingTitleTextBox;
        private readonly TextBox _meetingDescriptionTextBox;
        private readonly CheckBox _meetingIsAllDayCheckBox;
        private readonly DateTimePicker _meetingStartDateTimePicker;
        private readonly DateTimePicker _meetingEndDateTimePicker;
        private readonly TextBox _meetingRemindersInput;
        private readonly ListBox _meetingRemindersListBox;
        private readonly TextBox _meetingFilterInput;
        private readonly Button _meetingSaveMeetingButton;
        private readonly Button _meetingDeleteMeetingButton;
        private readonly Button _meetingReminderAddButton;
        private readonly Button _meetingReminderRemoveButton;

        private Guid? _selectedMeeting;
        private string? _filter;

        public SemaphoreSlim Lock => _lock;
        public Dictionary<Guid, Meeting> Cache => _cache;

        public MeetingsView(
            ListView meetingsListView,
            TextBox meetingTitleTextBox,
            TextBox meetingDescriptionTextBox,
            CheckBox meetingIsAllDayCheckBox,
            DateTimePicker meetingStartDateTimePicker,
            DateTimePicker meetingEndDateTimePicker,
            TextBox meetingRemindersInput,
            ListBox meetingRemindersListBox,
            TextBox meetingFilterInput,
            Button meetingSaveMeetingButton,
            Button meetingDeleteMeetingButton,
            Button meetingReminderAddButton,
            Button meetingReminderRemoveButton)
        {
            _meetingsListView = meetingsListView;
            _meetingTitleTextBox = meetingTitleTextBox;
            _meetingDescriptionTextBox = meetingDescriptionTextBox;
            _meetingIsAllDayCheckBox = meetingIsAllDayCheckBox;
            _meetingStartDateTimePicker = meetingStartDateTimePicker;
            _meetingEndDateTimePicker = meetingEndDateTimePicker;
            _meetingRemindersInput = meetingRemindersInput;
            _meetingRemindersListBox = meetingRemindersListBox;
            _meetingFilterInput = meetingFilterInput;
            _meetingSaveMeetingButton = meetingSaveMeetingButton;
            _meetingDeleteMeetingButton = meetingDeleteMeetingButton;
            _meetingReminderAddButton = meetingReminderAddButton;
            _meetingReminderRemoveButton = meetingReminderRemoveButton;
        }

        public void Load()
        {
            _meetingsListView.Columns.Add("Data");
            _meetingsListView.Columns.Add("Nazwa spotkania");
            _meetingsListView.Columns.Add("Opis spotkania");

            _meetingsListView.SelectedIndexChanged += (s, e) => OnMeetingSelected();
            _meetingFilterInput.TextChanged += (s, e) => OnFilterChanged();
            _meetingIsAllDayCheckBox.CheckedChanged += (s, e) => OnMeetingIsAllDayChanged();
            _meetingReminderAddButton.Click += (s, e) => OnMeetingReminderAdd();
            _meetingReminderRemoveButton.Click += (s, e) => OnMeetingReminderRemove();
            _meetingSaveMeetingButton.Click += async (s, e) => await OnMeetingSave();
            _meetingDeleteMeetingButton.Click += async (s, e) => await OnMeetingDelete();

            ClearInput();
            LoadMeetings();
        }

        private async Task OnMeetingSave()
        {
            string title = Utils.TrimInput(_meetingTitleTextBox.Text);
            string description = Utils.TrimInput(_meetingDescriptionTextBox.Text);
            bool isAllDay = _meetingIsAllDayCheckBox.Checked;
            DateTime start = _meetingStartDateTimePicker.Value.TruncateToMinute();
            DateTime? end = _meetingEndDateTimePicker.Value.TruncateToMinute();
            List<string> reminder = _meetingRemindersListBox.Items.Cast<string>().ToList();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Tytuł nie może być pusty!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Opis nie może być pusty!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isAllDay)
            {
                end = null;
                reminder.Clear();
            }

            if(end != null)
            {
                if (Utils.AreDateTimesEqualUpToMinutes(start, end.Value))
                {
                    MessageBox.Show("Początek spotkania nie może być równy końcowi spotkania!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (end <= start)
                {
                    MessageBox.Show("Koniec spotkania nie może być wcześniejszy niż początek spotkania!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if(end != null && start.Date != end.Value.Date)
            {
                MessageBox.Show("Spotkania muszą zostać zakończone w ten sam dzień!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsColliding(start, end, isAllDay))
                return;

            await _lock.WaitAsync();

            try
            {
                Meeting meeting = new Meeting();
                if (_selectedMeeting != null)
                {
                    var cachedMeeting = _cache.GetValueOrDefault(_selectedMeeting.Value);
                    if (cachedMeeting != null)
                        meeting = cachedMeeting;
                }

                meeting.Title = title;
                meeting.Description = description;
                meeting.Start = start;
                meeting.End = end;
                meeting.Reminders = reminder;

                await WebUtils.Post("meetings/save", meeting);

                _meetingsListView.Invoke(() =>
                {
                    if (!_cache.ContainsKey(meeting.Identifier))
                        _cache[meeting.Identifier] = meeting;

                    MessageBox.Show("Zapisano spotkanie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInput();

                    UpdateMeetingsView();
                });
            }
            finally
            {
                _lock.Release();
            }
        }

        public void OnMeetingSelected()
        {
            SelectMeeting();

            if (_selectedMeeting == null) 
                ClearInput();
        }

        private async void LoadMeetings()
        {
            await _lock.WaitAsync();
            try
            {
                List<Meeting>? meetings = await Utils.GetObjectsAsync<Meeting>("meetings");
                if(meetings != null)
                    _meetingsListView.Invoke(() =>
                    {
                        foreach (Meeting meeting in meetings)
                            _cache[meeting.Identifier] = meeting;

                        UpdateMeetingsView();
                    });
            }
            finally
            {
                _lock.Release();
            }
        }

        private void SelectMeeting()
        {
            _selectedMeeting = null;

            if (_meetingsListView.SelectedItems.Count == 0)
                return;

            var item = _meetingsListView.SelectedItems[0];

            if (item == null || item.Tag == null)
                return;

            var meetingId = (Guid) item.Tag;
            var meeting = _cache.GetValueOrDefault(meetingId);

            if (meeting == null)
                return;

            _selectedMeeting = meeting.Identifier;
            _meetingTitleTextBox.Text = meeting.Title;
            _meetingDescriptionTextBox.Text = meeting.Description;
            _meetingStartDateTimePicker.Value = meeting.Start;
            _meetingIsAllDayCheckBox.Checked = meeting.IsAllDay;
            if (meeting.End != null)
                _meetingEndDateTimePicker.Value = meeting.End.Value;

            _meetingRemindersListBox.Items.Clear();
            foreach (string reminder in meeting.Reminders)
                _meetingRemindersListBox.Items.Add(reminder);
        }

        private void ClearInput()
        {
            _selectedMeeting = null;
            _meetingTitleTextBox.Text = "";
            _meetingDescriptionTextBox.Text = "";
            _meetingStartDateTimePicker.Value = DateTime.Now;
            _meetingEndDateTimePicker.Value = DateTime.Now.AddHours(1);
            _meetingIsAllDayCheckBox.Checked = false;
            _meetingRemindersListBox.Items.Clear();
        }

        public async Task OnMeetingDelete()
        {
            if (_selectedMeeting == null)
                return;

            await _lock.WaitAsync();
            try
            {
                _cache.Remove(_selectedMeeting.Value);

                await WebUtils.Delete("meetings/delete/" + _selectedMeeting.Value);

                _meetingsListView.Invoke(() =>
                {
                    UpdateMeetingsView();

                    MessageBox.Show("Usunięto spotkanie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
            finally
            {
                _lock.Release();
            }
        }

        public void OnMeetingReminderAdd()
        {
            int maxReminders = 3;

            if (_meetingRemindersListBox.Items.Count >= maxReminders)
            {
                MessageBox.Show("Maksymalna liczba przypomnień: " + maxReminders, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Utils.AddTextToListBox(_meetingRemindersListBox, _meetingRemindersInput.Text, ValidateReminder, "Dozwolony format: 1d/1h/1m (np. 1h 15m)");
        }

        public void OnMeetingReminderRemove()
        {
            Utils.RemoveSelectedTextFromListBox(_meetingRemindersListBox);
        }

        public void OnMeetingIsAllDayChanged()
        {
            _meetingEndDateTimePicker.Enabled = !_meetingEndDateTimePicker.Enabled;
        }

        public void OnFilterChanged()
        {
            _filter = _meetingFilterInput.Text;
            UpdateMeetingsView();
        }

        private void UpdateMeetingsView()
        {
            _meetingsListView.BeginUpdate();
            AddMeetingsToView(GetMeetings());
            _meetingsListView.EndUpdate();
        }

        private List<Meeting> GetMeetings()
        {
            List<Meeting> meetings;
            if (string.IsNullOrEmpty(_filter))
                meetings = [.. _cache.Values];
            else
            {
                meetings = [.. _cache.Values.Where(meeting =>
                meeting.Title.Contains(_filter, StringComparison.OrdinalIgnoreCase) ||
                     meeting.Description.Contains(_filter, StringComparison.OrdinalIgnoreCase))];
            }

            return meetings;
        }

        private void AddMeetingsToView(List<Meeting> meetings)
        {
            ClearMeetingsInView();

            if (meetings.Count == 0)
                return;

            DateTime time = DateTime.MinValue;
            foreach (Meeting meeting in meetings)
            {
                var lastDate = time.Date;
                var currentDate = meeting.Start.Date;

                if (lastDate != currentDate)
                {
                    time = currentDate;
                    _meetingsListView.Items.Add(time.ToShortDateString());
                }

                var item = new ListViewItem(["", meeting.ToString(), meeting.Description])
                {
                    Tag = meeting.Identifier
                };

                _meetingsListView.Items.Add(item);
            }
        }

        private bool IsColliding(DateTime start, DateTime? end, bool isAllDay)
        {
            DateTime effectiveEnd = isAllDay ? start.Date.AddDays(1).AddTicks(-1) : (end ?? start);
            DateTime effectiveStart = isAllDay ? start.Date : start;

            var conflictingMeetings = _cache.Values.Where(m => {
                if (_selectedMeeting != null && m.Identifier.Equals(_selectedMeeting.Value))
                    return false;

                DateTime existingStart = m.IsAllDay ? m.Start.Date : m.Start;
                DateTime existingEnd = m.IsAllDay ? m.Start.Date.AddDays(1).AddTicks(-1) : (m.End ?? m.Start);

                return effectiveStart < existingEnd && effectiveEnd > existingStart;
            }).ToList();

            if (conflictingMeetings.Count > 0)
            {
                var conflictDetails = conflictingMeetings.Select(m => {
                    string message = (m.IsAllDay ? "cały dzień" : $"{m.Start:HH:mm} - {m.End:HH:mm}");
                    return $"'{m.Title}' ({message})";
                });

                string message = $"Wykryto kolizję z następującymi spotkaniami:\n{string.Join("\n", conflictDetails)}";
                MessageBox.Show(message, "Kolizja spotkań", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        private void ClearMeetingsInView()
        {
            _meetingsListView.Items.Clear();
        }

        private bool ValidateReminder(string reminder)
        {
            return reminder != null && ReminderFormat.IsMatch(reminder.Trim());
        }
    }
}
