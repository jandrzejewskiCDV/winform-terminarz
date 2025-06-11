using System.Text.RegularExpressions;

namespace Terminarz
{
    internal class MeetingReminderService
    {
        private readonly IMeetingsRepository _meetingsRepository;
        private readonly System.Windows.Forms.Timer _timer;

        public MeetingReminderService(IMeetingsRepository meetingsRepository)
        {
            _meetingsRepository = meetingsRepository;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 60000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var now = DateTime.Now;
            var meetings = _meetingsRepository.FindAll();

            foreach (var meeting in meetings)
            {
                if (meeting.IsAllDay) 
                    continue;

                foreach (var reminder in meeting.Reminders)
                {
                    var reminderTime = CalculateReminderTime(meeting.Start, reminder);

                    if (reminderTime == null)
                        continue;

                    if (!Utils.AreDateTimesEqualUpToMinutes(now, reminderTime.Value))
                        continue;

                    ShowReminder(meeting, reminder);
                }
            }
        }

        private DateTime? CalculateReminderTime(DateTime meetingTime, string reminder)
        {
            var totalMinutes = 0;
            var matches = Regex.Matches(reminder, @"(\d+)([dhm])");

            foreach (Match match in matches)
            {
                var value = int.Parse(match.Groups[1].Value);
                var unit = match.Groups[2].Value;

                switch (unit)
                {
                    case "d":
                        totalMinutes += value * 24 * 60;
                        break;
                    case "h":
                        totalMinutes += value * 60;
                        break;
                    case "m":
                        totalMinutes += value;
                        break;
                }
            }

            return meetingTime.AddMinutes(-totalMinutes);
        }

        private void ShowReminder(Meeting meeting, string reminder)
        {
            var message = $"Przypomnienie o spotkaniu:\n\n" +
                         $"Tytuł: {meeting.Title}\n" +
                         $"Czas: {meeting.Start:dd.MM.yyyy HH:mm}\n" +
                         $"Opis: {meeting.Description}\n\n" +
                         $"Przypomnienie ustawione na: {reminder} przed spotkaniem";

            MessageBox.Show(
                message,
                "Przypomnienie o spotkaniu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void Stop()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
} 