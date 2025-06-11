using System.Text.RegularExpressions;

namespace Terminarz
{
    internal class MeetingsView
    {
        private static readonly Regex ReminderFormat = new Regex(@"^(\d+[dhm](\s+)?)+$", RegexOptions.IgnoreCase);

        private readonly IMeetingsRepository _meetingsRepository;
        private readonly ListView _meetingsListView;
        private readonly TextBox _meetingTitleTextBox;
        private readonly TextBox _meetingDescriptionTextBox;
        private readonly CheckBox _meetingIsAllDayCheckBox;
        private readonly DateTimePicker _meetingStartDateTimePicker;
        private readonly DateTimePicker _meetingEndDateTimePicker;
        private readonly TextBox _meetingRemindersInput;
        private readonly ListBox _meetingRemindersListBox;
        private readonly TextBox _meetingFilterInput;

        private Guid? _selectedMeeting;
        private string? _filter;

        public MeetingsView(IMeetingsRepository meetingsRepository,
            ListView meetingsListView,
            TextBox meetingTitleTextBox,
            TextBox meetingDescriptionTextBox,
            CheckBox meetingIsAllDayCheckBox,
            DateTimePicker meetingStartDateTimePicker,
            DateTimePicker meetingEndDateTimePicker,
            TextBox meetingRemindersInput,
            ListBox meetingRemindersListBox,
            TextBox meetingFilterInput)
        {
            _meetingsRepository = meetingsRepository;
            _meetingsListView = meetingsListView;
            _meetingTitleTextBox = meetingTitleTextBox;
            _meetingDescriptionTextBox = meetingDescriptionTextBox;
            _meetingIsAllDayCheckBox = meetingIsAllDayCheckBox;
            _meetingStartDateTimePicker = meetingStartDateTimePicker;
            _meetingEndDateTimePicker = meetingEndDateTimePicker;
            _meetingRemindersInput = meetingRemindersInput;
            _meetingRemindersListBox = meetingRemindersListBox;
            _meetingFilterInput = meetingFilterInput;
        }

        public void Load()
        {
            _meetingsListView.Columns.Add("Data");
            _meetingsListView.Columns.Add("Nazwa spotkania");
            _meetingsListView.Columns.Add("Opis spotkania");

            UpdateMeetingsView();
        }

        public void OnMeetingSave()
        {
            string title = Utils.TrimInput(_meetingTitleTextBox.Text);
            string description = Utils.TrimInput(_meetingDescriptionTextBox.Text);
            bool isAllDay = _meetingIsAllDayCheckBox.Checked;
            DateTime start = _meetingStartDateTimePicker.Value;
            DateTime? end = _meetingEndDateTimePicker.Value;
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

            if (IsColliding(start, end, isAllDay))
                return;

            Meeting meeting = new Meeting();
            if(_selectedMeeting != null)
            {
               var cachedMeeting = _meetingsRepository.FindOne(_selectedMeeting.Value);
               if (cachedMeeting != null)
                    meeting = cachedMeeting;
            }

            meeting.Title = title;
            meeting.Description = description;
            meeting.Start = start;
            meeting.End = end;
            meeting.Reminders = reminder;

            _meetingsRepository.Save(meeting);

            MessageBox.Show("Zapisano spotkanie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateMeetingsView();
            ClearInput();
        }

        public void OnMeetingSelected()
        {
            SelectMeeting();

            if (_selectedMeeting == null) 
                ClearInput();
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
            var meeting = _meetingsRepository.FindOne(meetingId);

            if (meeting == null)
                return;

            _selectedMeeting = meeting.Id;
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
            _meetingTitleTextBox.Text = "";
            _meetingDescriptionTextBox.Text = "";
            _meetingStartDateTimePicker.Value = DateTime.Now;
            _meetingEndDateTimePicker.Value = DateTime.Now.AddHours(1);
            _meetingIsAllDayCheckBox.Checked = false;
            _meetingRemindersListBox.Items.Clear();
        }

        public void OnMeetingDelete()
        {
            if (_selectedMeeting == null)
                return;

            _meetingsRepository.Delete(_selectedMeeting.Value);

            UpdateMeetingsView();

            MessageBox.Show("Usunięto spotkanie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                meetings = _meetingsRepository.GetMeetingsByDate();
            else
            {
                meetings = _meetingsRepository.GetMeetingsByDate(meeting =>
                meeting.Title.Contains(_filter, StringComparison.OrdinalIgnoreCase) ||
                     meeting.Description.Contains(_filter, StringComparison.OrdinalIgnoreCase));
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

                var item = new ListViewItem(["", meeting.ToString(), meeting.Description]);
                item.Tag = meeting.Id;

                _meetingsListView.Items.Add(item);
            }
        }

        private bool IsColliding(DateTime start, DateTime? end, bool isAllDay)
        {
            DateTime effectiveEnd = isAllDay ? start.Date.AddDays(1).AddTicks(-1) : (end ?? start);
            DateTime effectiveStart = isAllDay ? start.Date : start;

            var conflictingMeetings = _meetingsRepository.FindAll(m => {
                if (_selectedMeeting != null && m.Id == _selectedMeeting)
                    return false;

                DateTime existingStart = m.IsAllDay ? m.Start.Date : m.Start;
                DateTime existingEnd = m.IsAllDay ? m.Start.Date.AddDays(1).AddTicks(-1) : (m.End ?? m.Start);

                return effectiveStart < existingEnd && effectiveEnd > existingStart;
            });

            if (conflictingMeetings.Count > 0)
            {
                var conflictDetails = conflictingMeetings.Select(m =>
                    $"'{m.Title}' ({(m.IsAllDay ? "cały dzień" : $"{m.Start:HH:mm} - {(m.End?.ToString("HH:mm") + ")" ?? "bez końca)")}")}"
                );

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
