using System.Runtime.InteropServices;

namespace Terminarz;

public partial class Form1 : Form
{
    private readonly FriendsView _friendsView;
    private readonly MeetingsView _meetingsView;
    private readonly NotesView _notesView;
    private readonly MeetingReminderService _meetingReminderService;

    public Form1()
    {
        InitializeComponent();

        _friendsView = new FriendsView(_friendLayoutPanel, 
            _friendName,
            _friendSurname,
            _friendPhoneInput, 
            _friendEmailInput,
            _friendSocialsInput,
            _friendFilterInput,
            _friendPhoneList,
            _friendEmails, 
            _friendSocials,
            _friendPhoneListAdd,
            _friendPhoneListRemove, 
            _friendEmailsAdd, 
            _friendEmailsRemove,
            _friendSocialsAdd,
            _friendSocialsRemove,
            _friendSave,
            _friendDelete);
        _meetingsView = new MeetingsView(
            _meetingsListView,
            _meetingsTitleInput,
            _meetingsDescriptionInput,
            _meetingsIsAllDayCheckBox,
            _meetingsStartDateTimePicker,
            _meetingsEndDateTimePicker,
            _meetingsReminderInput,
            _meetingsReminderListBox,
            _searchMeetingInput,
            _meetingsSaveMeetingButton,
            _meetingsDeleteMeetingButton,
            _meetingsReminderAddButton,
            _meetingsReminderRemoveButton);
        _notesView = new NotesView(_notesFlowLayout, 
            _addNoteButton, 
            _notesFilterInput, 
            _notesFilterRegex);

        _meetingReminderService = new MeetingReminderService(_meetingsView);

        Load += new EventHandler(Form1_Load);
        FormClosing += Form1_FormClosing;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();

    private void Form1_Load(Object sender, EventArgs e)
    {
        AllocConsole();

        _friendsView.Load();
        _meetingsView.Load();
        _notesView.Load();
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        _meetingReminderService?.Stop();
    }
}