using System.Runtime.InteropServices;

namespace Terminarz;

public partial class Form1 : Form
{
    private readonly IFriendsRepository _friendsRepository;
    private readonly IMeetingsRepository _meetingsRepository;
    private readonly INoteRepository _noteRepository;
    private readonly FriendsView _friendsView;
    private readonly MeetingsView _meetingsView;
    private readonly NotesView _notesView;
    private readonly MeetingReminderService _meetingReminderService;

    public Form1()
    {
        InitializeComponent();

        _friendsRepository = new PersistentInMemoryFriendsRepository();
        _meetingsRepository = new PersistentInMemoryMeetingsRepository();
        _noteRepository = new PersistentInMemoryNoteRepository();
        _friendsView = new FriendsView(_friendsRepository, _friendsGridView);
        _meetingsView = new MeetingsView(_meetingsRepository,
            _meetingsListView,
            _meetingsTitleInput,
            _meetingsDescriptionInput,
            _meetingsIsAllDayCheckBox,
            _meetingsStartDateTimePicker,
            _meetingsEndDateTimePicker,
            _meetingsReminderInput,
            _meetingsReminderListBox,
            _searchMeetingInput);
        _notesView = new NotesView(_noteRepository, _notesFlowLayout);

        _meetingReminderService = new MeetingReminderService(_meetingsRepository);

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
        _meetingReminderService.Stop();
    }

    private void _friendsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        _friendsView.ValidateCells(e);
    }

    private void _addFriendAddPhoneNumberButton_Click(object sender, EventArgs e)
    {
        _friendsView.OnAddPhoneNumber(_addFriendPhoneList, _addFriendPhoneNumberInput.Text);
    }

    private void _addFriendRemovePhoneNumberButton_Click(object sender, EventArgs e)
    {
        _friendsView.OnRemovePhoneNumber(_addFriendPhoneList);
    }

    private void _addFriendAddEmailButton_Click(object sender, EventArgs e)
    {
        _friendsView.OnAddEmail(_addFriendEmailList, _addFriendEmailInput.Text);
    }

    private void _addFriendRemoveEmailButton_Click(object sender, EventArgs e)
    {
        _friendsView.OnRemoveEmail(_addFriendEmailList);
    }

    private void _deleteFriendButton_Click(object sender, EventArgs e)
    {
        _friendsView.OnDeleteFriend();
    }

    private void _friendsSaveChangesButton_Click(object sender, EventArgs e)
    {
        _friendsView.OnSaveChanges();
    }

    private void _friendsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        _friendsView.OnCellClick(e);
    }

    private void _filterFriendsInput_TextChanged(object sender, EventArgs e)
    {
        _friendsView.OnFilterChanged(_filterFriendsInput.Text);
    }

    private void _addFriendFinalizeButton_Click(object sender, EventArgs e)
    {
        if (!_friendsView.AddFriend(_addFriendNameInput.Text,
            _addFriendSurnameInput.Text,
            _addFriendEmailList,
            _addFriendPhoneList))
            return;

        _addFriendNameInput.Text = "";
        _addFriendSurnameInput.Text = "";
        _addFriendEmailInput.Text = "";
        _addFriendPhoneNumberInput.Text = "";
        _addFriendEmailList.Items.Clear();
        _addFriendPhoneList.Items.Clear();
    }

    private void _meetingsSaveMeetingButton_Click(object sender, EventArgs e)
    {
        _meetingsView.OnMeetingSave();
    }

    private void _meetingsDeleteMeetingButton_Click(object sender, EventArgs e)
    {
        _meetingsView.OnMeetingDelete();
    }

    private void _meetingsReminderAddButton_Click(object sender, EventArgs e)
    {
        _meetingsView.OnMeetingReminderAdd();
    }

    private void _meetingsReminderRemoveButton_Click(object sender, EventArgs e)
    {
        _meetingsView.OnMeetingReminderRemove();
    }

    private void _meetingsIsAllDayCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        _meetingsView.OnMeetingIsAllDayChanged();
    }

    private void _searchMeetingInput_TextChanged(object sender, EventArgs e)
    {
        _meetingsView.OnFilterChanged();
    }

    private void _meetingsListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        _meetingsView.OnMeetingSelected();
    }

    private void _addNoteButton_Click(object sender, EventArgs e)
    {
        _notesView.OnAddNote();
    }

    private void _notesFilterInput_TextChanged(object sender, EventArgs e)
    {
        _notesView.OnFilterApplied(_notesFilterInput.Text, _notesFilterRegex.Checked);
    }
}