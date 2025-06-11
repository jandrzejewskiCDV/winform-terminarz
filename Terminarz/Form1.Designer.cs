namespace Terminarz;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl = new TabControl();
        friendsTab = new TabPage();
        label5 = new Label();
        _friendsSaveChangesButton = new Button();
        _filterFriendsInput = new TextBox();
        _deleteFriendButton = new Button();
        _addFriendFinalizeButton = new Button();
        _addFriendRemoveEmailButton = new Button();
        _addFriendAddEmailButton = new Button();
        _addFriendRemovePhoneNumberButton = new Button();
        _addFriendAddPhoneNumberButton = new Button();
        _addFriendEmailList = new ListBox();
        _addFriendEmailInput = new TextBox();
        label4 = new Label();
        _addFriendPhoneList = new ListBox();
        _addFriendPhoneNumberInput = new TextBox();
        label3 = new Label();
        _addFriendSurnameInput = new TextBox();
        label2 = new Label();
        _addFriendNameInput = new TextBox();
        label1 = new Label();
        _friendsGridView = new DataGridView();
        _meetingsPage = new TabPage();
        _meetingsReminderInput = new TextBox();
        _meetingsReminderRemoveButton = new Button();
        _meetingsReminderAddButton = new Button();
        label12 = new Label();
        _meetingsReminderListBox = new ListBox();
        label11 = new Label();
        _searchMeetingInput = new TextBox();
        _meetingsDeleteMeetingButton = new Button();
        _meetingsSaveMeetingButton = new Button();
        _meetingsEndDateTimePicker = new DateTimePicker();
        label10 = new Label();
        _meetingsStartDateTimePicker = new DateTimePicker();
        label9 = new Label();
        _meetingsIsAllDayCheckBox = new CheckBox();
        label8 = new Label();
        _meetingsDescriptionInput = new TextBox();
        label7 = new Label();
        _meetingsTitleInput = new TextBox();
        label6 = new Label();
        _meetingsListView = new ListView();
        _notesPage = new TabPage();
        _notesFilterRegex = new CheckBox();
        label13 = new Label();
        _notesFilterInput = new RichTextBox();
        _addNoteButton = new Button();
        _notesFlowLayout = new FlowLayoutPanel();
        tabControl.SuspendLayout();
        friendsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_friendsGridView).BeginInit();
        _meetingsPage.SuspendLayout();
        _notesPage.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Controls.Add(friendsTab);
        tabControl.Controls.Add(_meetingsPage);
        tabControl.Controls.Add(_notesPage);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Location = new Point(0, 0);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(1008, 681);
        tabControl.TabIndex = 0;
        // 
        // friendsTab
        // 
        friendsTab.Controls.Add(label5);
        friendsTab.Controls.Add(_friendsSaveChangesButton);
        friendsTab.Controls.Add(_filterFriendsInput);
        friendsTab.Controls.Add(_deleteFriendButton);
        friendsTab.Controls.Add(_addFriendFinalizeButton);
        friendsTab.Controls.Add(_addFriendRemoveEmailButton);
        friendsTab.Controls.Add(_addFriendAddEmailButton);
        friendsTab.Controls.Add(_addFriendRemovePhoneNumberButton);
        friendsTab.Controls.Add(_addFriendAddPhoneNumberButton);
        friendsTab.Controls.Add(_addFriendEmailList);
        friendsTab.Controls.Add(_addFriendEmailInput);
        friendsTab.Controls.Add(label4);
        friendsTab.Controls.Add(_addFriendPhoneList);
        friendsTab.Controls.Add(_addFriendPhoneNumberInput);
        friendsTab.Controls.Add(label3);
        friendsTab.Controls.Add(_addFriendSurnameInput);
        friendsTab.Controls.Add(label2);
        friendsTab.Controls.Add(_addFriendNameInput);
        friendsTab.Controls.Add(label1);
        friendsTab.Controls.Add(_friendsGridView);
        friendsTab.Location = new Point(4, 24);
        friendsTab.Name = "friendsTab";
        friendsTab.Padding = new Padding(3);
        friendsTab.Size = new Size(1000, 653);
        friendsTab.TabIndex = 0;
        friendsTab.Text = "Znajomi";
        friendsTab.UseVisualStyleBackColor = true;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(758, 561);
        label5.Name = "label5";
        label5.Size = new Size(56, 15);
        label5.TabIndex = 20;
        label5.Text = "Wyszukaj";
        // 
        // _friendsSaveChangesButton
        // 
        _friendsSaveChangesButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _friendsSaveChangesButton.Location = new Point(259, 608);
        _friendsSaveChangesButton.Name = "_friendsSaveChangesButton";
        _friendsSaveChangesButton.Size = new Size(169, 43);
        _friendsSaveChangesButton.TabIndex = 19;
        _friendsSaveChangesButton.Text = "Zapisz zmiany";
        _friendsSaveChangesButton.UseVisualStyleBackColor = true;
        _friendsSaveChangesButton.Click += _friendsSaveChangesButton_Click;
        // 
        // _filterFriendsInput
        // 
        _filterFriendsInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _filterFriendsInput.Location = new Point(758, 579);
        _filterFriendsInput.Name = "_filterFriendsInput";
        _filterFriendsInput.Size = new Size(229, 23);
        _filterFriendsInput.TabIndex = 18;
        _filterFriendsInput.TextChanged += _filterFriendsInput_TextChanged;
        // 
        // _deleteFriendButton
        // 
        _deleteFriendButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _deleteFriendButton.Location = new Point(259, 559);
        _deleteFriendButton.Name = "_deleteFriendButton";
        _deleteFriendButton.Size = new Size(169, 43);
        _deleteFriendButton.TabIndex = 16;
        _deleteFriendButton.Text = "Usuń wybranego znajomego";
        _deleteFriendButton.UseVisualStyleBackColor = true;
        _deleteFriendButton.Click += _deleteFriendButton_Click;
        // 
        // _addFriendFinalizeButton
        // 
        _addFriendFinalizeButton.Location = new Point(8, 510);
        _addFriendFinalizeButton.Name = "_addFriendFinalizeButton";
        _addFriendFinalizeButton.Size = new Size(228, 43);
        _addFriendFinalizeButton.TabIndex = 15;
        _addFriendFinalizeButton.Text = "Dodaj znajomego";
        _addFriendFinalizeButton.UseVisualStyleBackColor = true;
        _addFriendFinalizeButton.Click += _addFriendFinalizeButton_Click;
        // 
        // _addFriendRemoveEmailButton
        // 
        _addFriendRemoveEmailButton.Location = new Point(172, 447);
        _addFriendRemoveEmailButton.Name = "_addFriendRemoveEmailButton";
        _addFriendRemoveEmailButton.Size = new Size(64, 36);
        _addFriendRemoveEmailButton.TabIndex = 14;
        _addFriendRemoveEmailButton.Text = "Usuń";
        _addFriendRemoveEmailButton.UseVisualStyleBackColor = true;
        _addFriendRemoveEmailButton.Click += _addFriendRemoveEmailButton_Click;
        // 
        // _addFriendAddEmailButton
        // 
        _addFriendAddEmailButton.Location = new Point(8, 447);
        _addFriendAddEmailButton.Name = "_addFriendAddEmailButton";
        _addFriendAddEmailButton.Size = new Size(66, 36);
        _addFriendAddEmailButton.TabIndex = 13;
        _addFriendAddEmailButton.Text = "Dodaj";
        _addFriendAddEmailButton.UseVisualStyleBackColor = true;
        _addFriendAddEmailButton.Click += _addFriendAddEmailButton_Click;
        // 
        // _addFriendRemovePhoneNumberButton
        // 
        _addFriendRemovePhoneNumberButton.Location = new Point(172, 261);
        _addFriendRemovePhoneNumberButton.Name = "_addFriendRemovePhoneNumberButton";
        _addFriendRemovePhoneNumberButton.Size = new Size(64, 36);
        _addFriendRemovePhoneNumberButton.TabIndex = 12;
        _addFriendRemovePhoneNumberButton.Text = "Usuń";
        _addFriendRemovePhoneNumberButton.UseVisualStyleBackColor = true;
        _addFriendRemovePhoneNumberButton.Click += _addFriendRemovePhoneNumberButton_Click;
        // 
        // _addFriendAddPhoneNumberButton
        // 
        _addFriendAddPhoneNumberButton.Location = new Point(8, 261);
        _addFriendAddPhoneNumberButton.Name = "_addFriendAddPhoneNumberButton";
        _addFriendAddPhoneNumberButton.Size = new Size(66, 36);
        _addFriendAddPhoneNumberButton.TabIndex = 11;
        _addFriendAddPhoneNumberButton.Text = "Dodaj";
        _addFriendAddPhoneNumberButton.UseVisualStyleBackColor = true;
        _addFriendAddPhoneNumberButton.Click += _addFriendAddPhoneNumberButton_Click;
        // 
        // _addFriendEmailList
        // 
        _addFriendEmailList.FormattingEnabled = true;
        _addFriendEmailList.Location = new Point(8, 392);
        _addFriendEmailList.Name = "_addFriendEmailList";
        _addFriendEmailList.Size = new Size(228, 49);
        _addFriendEmailList.TabIndex = 10;
        // 
        // _addFriendEmailInput
        // 
        _addFriendEmailInput.Location = new Point(7, 352);
        _addFriendEmailInput.Name = "_addFriendEmailInput";
        _addFriendEmailInput.Size = new Size(229, 23);
        _addFriendEmailInput.TabIndex = 9;
        // 
        // label4
        // 
        label4.Location = new Point(7, 331);
        label4.Name = "label4";
        label4.Size = new Size(229, 18);
        label4.TabIndex = 8;
        label4.Text = "Podaj email ";
        // 
        // _addFriendPhoneList
        // 
        _addFriendPhoneList.FormattingEnabled = true;
        _addFriendPhoneList.Location = new Point(8, 206);
        _addFriendPhoneList.Name = "_addFriendPhoneList";
        _addFriendPhoneList.Size = new Size(228, 49);
        _addFriendPhoneList.TabIndex = 7;
        // 
        // _addFriendPhoneNumberInput
        // 
        _addFriendPhoneNumberInput.Location = new Point(7, 166);
        _addFriendPhoneNumberInput.Name = "_addFriendPhoneNumberInput";
        _addFriendPhoneNumberInput.Size = new Size(229, 23);
        _addFriendPhoneNumberInput.TabIndex = 6;
        // 
        // label3
        // 
        label3.Location = new Point(7, 145);
        label3.Name = "label3";
        label3.Size = new Size(229, 18);
        label3.TabIndex = 5;
        label3.Text = "Podaj numer telefonu:";
        // 
        // _addFriendSurnameInput
        // 
        _addFriendSurnameInput.Location = new Point(7, 104);
        _addFriendSurnameInput.Name = "_addFriendSurnameInput";
        _addFriendSurnameInput.Size = new Size(229, 23);
        _addFriendSurnameInput.TabIndex = 4;
        // 
        // label2
        // 
        label2.Location = new Point(7, 83);
        label2.Name = "label2";
        label2.Size = new Size(229, 18);
        label2.TabIndex = 3;
        label2.Text = "Nazwisko:";
        // 
        // _addFriendNameInput
        // 
        _addFriendNameInput.Location = new Point(7, 45);
        _addFriendNameInput.Name = "_addFriendNameInput";
        _addFriendNameInput.Size = new Size(229, 23);
        _addFriendNameInput.TabIndex = 2;
        // 
        // label1
        // 
        label1.Location = new Point(7, 24);
        label1.Name = "label1";
        label1.Size = new Size(229, 18);
        label1.TabIndex = 1;
        label1.Text = "Imię:";
        // 
        // _friendsGridView
        // 
        _friendsGridView.AllowUserToAddRows = false;
        _friendsGridView.AllowUserToDeleteRows = false;
        _friendsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _friendsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _friendsGridView.Location = new Point(259, 14);
        _friendsGridView.MultiSelect = false;
        _friendsGridView.Name = "_friendsGridView";
        _friendsGridView.Size = new Size(728, 539);
        _friendsGridView.TabIndex = 0;
        _friendsGridView.Text = "dataGridView1";
        _friendsGridView.CellClick += _friendsGridView_CellClick;
        _friendsGridView.CellValidating += _friendsGridView_CellValidating;
        // 
        // _meetingsPage
        // 
        _meetingsPage.Controls.Add(_meetingsReminderInput);
        _meetingsPage.Controls.Add(_meetingsReminderRemoveButton);
        _meetingsPage.Controls.Add(_meetingsReminderAddButton);
        _meetingsPage.Controls.Add(label12);
        _meetingsPage.Controls.Add(_meetingsReminderListBox);
        _meetingsPage.Controls.Add(label11);
        _meetingsPage.Controls.Add(_searchMeetingInput);
        _meetingsPage.Controls.Add(_meetingsDeleteMeetingButton);
        _meetingsPage.Controls.Add(_meetingsSaveMeetingButton);
        _meetingsPage.Controls.Add(_meetingsEndDateTimePicker);
        _meetingsPage.Controls.Add(label10);
        _meetingsPage.Controls.Add(_meetingsStartDateTimePicker);
        _meetingsPage.Controls.Add(label9);
        _meetingsPage.Controls.Add(_meetingsIsAllDayCheckBox);
        _meetingsPage.Controls.Add(label8);
        _meetingsPage.Controls.Add(_meetingsDescriptionInput);
        _meetingsPage.Controls.Add(label7);
        _meetingsPage.Controls.Add(_meetingsTitleInput);
        _meetingsPage.Controls.Add(label6);
        _meetingsPage.Controls.Add(_meetingsListView);
        _meetingsPage.Location = new Point(4, 24);
        _meetingsPage.Name = "_meetingsPage";
        _meetingsPage.Padding = new Padding(3);
        _meetingsPage.Size = new Size(1000, 653);
        _meetingsPage.TabIndex = 1;
        _meetingsPage.Text = "Spotkania";
        _meetingsPage.UseVisualStyleBackColor = true;
        // 
        // _meetingsReminderInput
        // 
        _meetingsReminderInput.Anchor = AnchorStyles.Top;
        _meetingsReminderInput.Location = new Point(742, 299);
        _meetingsReminderInput.Name = "_meetingsReminderInput";
        _meetingsReminderInput.PlaceholderText = "np. 1m/1h/1d/";
        _meetingsReminderInput.Size = new Size(250, 23);
        _meetingsReminderInput.TabIndex = 19;
        // 
        // _meetingsReminderRemoveButton
        // 
        _meetingsReminderRemoveButton.Location = new Point(884, 398);
        _meetingsReminderRemoveButton.Name = "_meetingsReminderRemoveButton";
        _meetingsReminderRemoveButton.Size = new Size(108, 32);
        _meetingsReminderRemoveButton.TabIndex = 18;
        _meetingsReminderRemoveButton.Text = "Usuń";
        _meetingsReminderRemoveButton.UseVisualStyleBackColor = true;
        _meetingsReminderRemoveButton.Click += _meetingsReminderRemoveButton_Click;
        // 
        // _meetingsReminderAddButton
        // 
        _meetingsReminderAddButton.Location = new Point(742, 398);
        _meetingsReminderAddButton.Name = "_meetingsReminderAddButton";
        _meetingsReminderAddButton.Size = new Size(108, 32);
        _meetingsReminderAddButton.TabIndex = 17;
        _meetingsReminderAddButton.Text = "Dodaj";
        _meetingsReminderAddButton.UseVisualStyleBackColor = true;
        _meetingsReminderAddButton.Click += _meetingsReminderAddButton_Click;
        // 
        // label12
        // 
        label12.Anchor = AnchorStyles.Top;
        label12.AutoSize = true;
        label12.Location = new Point(742, 281);
        label12.Name = "label12";
        label12.Size = new Size(138, 15);
        label12.TabIndex = 16;
        label12.Text = "Alarmy z wyprzedzeniem";
        // 
        // _meetingsReminderListBox
        // 
        _meetingsReminderListBox.FormattingEnabled = true;
        _meetingsReminderListBox.Location = new Point(742, 328);
        _meetingsReminderListBox.Name = "_meetingsReminderListBox";
        _meetingsReminderListBox.Size = new Size(250, 64);
        _meetingsReminderListBox.TabIndex = 15;
        // 
        // label11
        // 
        label11.Anchor = AnchorStyles.Top;
        label11.AutoSize = true;
        label11.Location = new Point(742, 586);
        label11.Name = "label11";
        label11.Size = new Size(110, 15);
        label11.TabIndex = 14;
        label11.Text = "Wyszukaj spotkania";
        // 
        // _searchMeetingInput
        // 
        _searchMeetingInput.Anchor = AnchorStyles.Top;
        _searchMeetingInput.Location = new Point(742, 604);
        _searchMeetingInput.Name = "_searchMeetingInput";
        _searchMeetingInput.Size = new Size(250, 23);
        _searchMeetingInput.TabIndex = 13;
        _searchMeetingInput.TextChanged += _searchMeetingInput_TextChanged;
        // 
        // _meetingsDeleteMeetingButton
        // 
        _meetingsDeleteMeetingButton.Location = new Point(884, 462);
        _meetingsDeleteMeetingButton.Name = "_meetingsDeleteMeetingButton";
        _meetingsDeleteMeetingButton.Size = new Size(108, 32);
        _meetingsDeleteMeetingButton.TabIndex = 12;
        _meetingsDeleteMeetingButton.Text = "Usuń spotkanie";
        _meetingsDeleteMeetingButton.UseVisualStyleBackColor = true;
        _meetingsDeleteMeetingButton.Click += _meetingsDeleteMeetingButton_Click;
        // 
        // _meetingsSaveMeetingButton
        // 
        _meetingsSaveMeetingButton.Location = new Point(742, 462);
        _meetingsSaveMeetingButton.Name = "_meetingsSaveMeetingButton";
        _meetingsSaveMeetingButton.Size = new Size(108, 32);
        _meetingsSaveMeetingButton.TabIndex = 11;
        _meetingsSaveMeetingButton.Text = "Zapisz spotkanie";
        _meetingsSaveMeetingButton.UseVisualStyleBackColor = true;
        _meetingsSaveMeetingButton.Click += _meetingsSaveMeetingButton_Click;
        // 
        // _meetingsEndDateTimePicker
        // 
        _meetingsEndDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
        _meetingsEndDateTimePicker.Format = DateTimePickerFormat.Custom;
        _meetingsEndDateTimePicker.Location = new Point(742, 248);
        _meetingsEndDateTimePicker.Name = "_meetingsEndDateTimePicker";
        _meetingsEndDateTimePicker.Size = new Size(250, 23);
        _meetingsEndDateTimePicker.TabIndex = 10;
        // 
        // label10
        // 
        label10.Anchor = AnchorStyles.Top;
        label10.AutoSize = true;
        label10.Location = new Point(742, 230);
        label10.Name = "label10";
        label10.Size = new Size(127, 15);
        label10.TabIndex = 9;
        label10.Text = "Zakończenie spotkania";
        // 
        // _meetingsStartDateTimePicker
        // 
        _meetingsStartDateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
        _meetingsStartDateTimePicker.Format = DateTimePickerFormat.Custom;
        _meetingsStartDateTimePicker.Location = new Point(742, 196);
        _meetingsStartDateTimePicker.Name = "_meetingsStartDateTimePicker";
        _meetingsStartDateTimePicker.Size = new Size(250, 23);
        _meetingsStartDateTimePicker.TabIndex = 8;
        // 
        // label9
        // 
        label9.Anchor = AnchorStyles.Top;
        label9.AutoSize = true;
        label9.Location = new Point(742, 178);
        label9.Name = "label9";
        label9.Size = new Size(108, 15);
        label9.TabIndex = 7;
        label9.Text = "Początek spotkania";
        // 
        // _meetingsIsAllDayCheckBox
        // 
        _meetingsIsAllDayCheckBox.AutoSize = true;
        _meetingsIsAllDayCheckBox.Location = new Point(871, 154);
        _meetingsIsAllDayCheckBox.Name = "_meetingsIsAllDayCheckBox";
        _meetingsIsAllDayCheckBox.Size = new Size(15, 14);
        _meetingsIsAllDayCheckBox.TabIndex = 6;
        _meetingsIsAllDayCheckBox.UseVisualStyleBackColor = true;
        _meetingsIsAllDayCheckBox.CheckedChanged += _meetingsIsAllDayCheckBox_CheckedChanged;
        // 
        // label8
        // 
        label8.Anchor = AnchorStyles.Top;
        label8.AutoSize = true;
        label8.Location = new Point(742, 153);
        label8.Name = "label8";
        label8.Size = new Size(123, 15);
        label8.TabIndex = 5;
        label8.Text = "Spotkanie całodniowe";
        // 
        // _meetingsDescriptionInput
        // 
        _meetingsDescriptionInput.Anchor = AnchorStyles.Top;
        _meetingsDescriptionInput.Location = new Point(742, 65);
        _meetingsDescriptionInput.Multiline = true;
        _meetingsDescriptionInput.Name = "_meetingsDescriptionInput";
        _meetingsDescriptionInput.Size = new Size(250, 85);
        _meetingsDescriptionInput.TabIndex = 4;
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.Top;
        label7.AutoSize = true;
        label7.Location = new Point(742, 47);
        label7.Name = "label7";
        label7.Size = new Size(85, 15);
        label7.TabIndex = 3;
        label7.Text = "Opis spotkania";
        // 
        // _meetingsTitleInput
        // 
        _meetingsTitleInput.Anchor = AnchorStyles.Top;
        _meetingsTitleInput.Location = new Point(742, 21);
        _meetingsTitleInput.Name = "_meetingsTitleInput";
        _meetingsTitleInput.Size = new Size(250, 23);
        _meetingsTitleInput.TabIndex = 2;
        // 
        // label6
        // 
        label6.Anchor = AnchorStyles.Top;
        label6.AutoSize = true;
        label6.Location = new Point(742, 3);
        label6.Name = "label6";
        label6.Size = new Size(87, 15);
        label6.TabIndex = 1;
        label6.Text = "Tytuł spotkania";
        // 
        // _meetingsListView
        // 
        _meetingsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        _meetingsListView.FullRowSelect = true;
        _meetingsListView.GridLines = true;
        _meetingsListView.Location = new Point(6, 6);
        _meetingsListView.Name = "_meetingsListView";
        _meetingsListView.Size = new Size(708, 639);
        _meetingsListView.TabIndex = 0;
        _meetingsListView.UseCompatibleStateImageBehavior = false;
        _meetingsListView.View = View.Details;
        _meetingsListView.SelectedIndexChanged += _meetingsListView_SelectedIndexChanged;
        // 
        // _notesPage
        // 
        _notesPage.Controls.Add(_notesFilterRegex);
        _notesPage.Controls.Add(label13);
        _notesPage.Controls.Add(_notesFilterInput);
        _notesPage.Controls.Add(_addNoteButton);
        _notesPage.Controls.Add(_notesFlowLayout);
        _notesPage.Location = new Point(4, 24);
        _notesPage.Name = "_notesPage";
        _notesPage.Padding = new Padding(3);
        _notesPage.Size = new Size(1000, 653);
        _notesPage.TabIndex = 2;
        _notesPage.Text = "Notatki";
        _notesPage.UseVisualStyleBackColor = true;
        // 
        // _notesFilterRegex
        // 
        _notesFilterRegex.AutoSize = true;
        _notesFilterRegex.Location = new Point(805, 55);
        _notesFilterRegex.Name = "_notesFilterRegex";
        _notesFilterRegex.Size = new Size(133, 19);
        _notesFilterRegex.TabIndex = 4;
        _notesFilterRegex.Text = "Wyrażenie regularne";
        _notesFilterRegex.UseVisualStyleBackColor = true;
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new Point(805, 6);
        label13.Name = "label13";
        label13.Size = new Size(56, 15);
        label13.TabIndex = 3;
        label13.Text = "Wyszukaj";
        // 
        // _notesFilterInput
        // 
        _notesFilterInput.Location = new Point(805, 24);
        _notesFilterInput.Multiline = false;
        _notesFilterInput.Name = "_notesFilterInput";
        _notesFilterInput.Size = new Size(187, 25);
        _notesFilterInput.TabIndex = 2;
        _notesFilterInput.Text = "";
        _notesFilterInput.TextChanged += _notesFilterInput_TextChanged;
        // 
        // _addNoteButton
        // 
        _addNoteButton.Location = new Point(803, 295);
        _addNoteButton.Name = "_addNoteButton";
        _addNoteButton.Size = new Size(189, 48);
        _addNoteButton.TabIndex = 1;
        _addNoteButton.Text = "Dodaj pustą notatkę";
        _addNoteButton.UseVisualStyleBackColor = true;
        _addNoteButton.Click += _addNoteButton_Click;
        // 
        // _notesFlowLayout
        // 
        _notesFlowLayout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        _notesFlowLayout.AutoScroll = true;
        _notesFlowLayout.BackColor = Color.Silver;
        _notesFlowLayout.Location = new Point(6, 6);
        _notesFlowLayout.Name = "_notesFlowLayout";
        _notesFlowLayout.Size = new Size(793, 641);
        _notesFlowLayout.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.AppWorkspace;
        ClientSize = new Size(1008, 681);
        Controls.Add(tabControl);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Terminarz";
        tabControl.ResumeLayout(false);
        friendsTab.ResumeLayout(false);
        friendsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_friendsGridView).EndInit();
        _meetingsPage.ResumeLayout(false);
        _meetingsPage.PerformLayout();
        _notesPage.ResumeLayout(false);
        _notesPage.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox _addFriendNameInput;
    private System.Windows.Forms.TextBox _addFriendSurnameInput;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage friendsTab;
    private System.Windows.Forms.TabPage meetingsTab;

    #endregion

    private ListBox _addFriendEmailList;
    private TextBox _addFriendEmailInput;
    private Label label4;
    private ListBox _addFriendPhoneList;
    private TextBox _addFriendPhoneNumberInput;
    private Label label3;
    private Button _addFriendRemovePhoneNumberButton;
    private Button _addFriendAddPhoneNumberButton;
    private Button _addFriendRemoveEmailButton;
    private Button _addFriendAddEmailButton;
    private Button _addFriendFinalizeButton;
    private DataGridView _friendsGridView;
    private Button _deleteFriendButton;
    private TextBox _filterFriendsInput;
    private Button _friendsSaveChangesButton;
    private Label label5;
    private TabPage _meetingsPage;
    private ListView _meetingsListView;
    private TextBox _meetingsTitleInput;
    private Label label6;
    private TextBox _meetingsDescriptionInput;
    private Label label7;
    private Label label8;
    private CheckBox _meetingsIsAllDayCheckBox;
    private Label label9;
    private DateTimePicker _meetingsEndDateTimePicker;
    private Label label10;
    private DateTimePicker _meetingsStartDateTimePicker;
    private Button _meetingsSaveMeetingButton;
    private Button _meetingsDeleteMeetingButton;
    private TextBox _searchMeetingInput;
    private Label label11;
    private Label label12;
    private ListBox _meetingsReminderListBox;
    private Button _meetingsReminderRemoveButton;
    private Button _meetingsReminderAddButton;
    private TextBox _meetingsReminderInput;
    private TabPage _notesPage;
    private FlowLayoutPanel _notesFlowLayout;
    private Button _addNoteButton;
    private RichTextBox _notesFilterInput;
    private Label label13;
    private CheckBox _notesFilterRegex;
}