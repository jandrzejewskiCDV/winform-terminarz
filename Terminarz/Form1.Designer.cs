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
        label14 = new Label();
        _friendFilterInput = new TextBox();
        _friendDelete = new Button();
        _friendSave = new Button();
        _friendSocialsRemove = new Button();
        _friendSocialsAdd = new Button();
        _friendSocialsInput = new TextBox();
        label5 = new Label();
        _friendSocials = new ListBox();
        _friendEmailsRemove = new Button();
        _friendEmailsAdd = new Button();
        _friendEmailInput = new TextBox();
        label4 = new Label();
        _friendEmails = new ListBox();
        _friendPhoneListRemove = new Button();
        _friendPhoneListAdd = new Button();
        _friendPhoneInput = new TextBox();
        label3 = new Label();
        _friendPhoneList = new ListBox();
        _friendSurname = new TextBox();
        label2 = new Label();
        _friendName = new TextBox();
        label1 = new Label();
        _friendLayoutPanel = new FlowLayoutPanel();
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
        friendsTab.Controls.Add(label14);
        friendsTab.Controls.Add(_friendFilterInput);
        friendsTab.Controls.Add(_friendDelete);
        friendsTab.Controls.Add(_friendSave);
        friendsTab.Controls.Add(_friendSocialsRemove);
        friendsTab.Controls.Add(_friendSocialsAdd);
        friendsTab.Controls.Add(_friendSocialsInput);
        friendsTab.Controls.Add(label5);
        friendsTab.Controls.Add(_friendSocials);
        friendsTab.Controls.Add(_friendEmailsRemove);
        friendsTab.Controls.Add(_friendEmailsAdd);
        friendsTab.Controls.Add(_friendEmailInput);
        friendsTab.Controls.Add(label4);
        friendsTab.Controls.Add(_friendEmails);
        friendsTab.Controls.Add(_friendPhoneListRemove);
        friendsTab.Controls.Add(_friendPhoneListAdd);
        friendsTab.Controls.Add(_friendPhoneInput);
        friendsTab.Controls.Add(label3);
        friendsTab.Controls.Add(_friendPhoneList);
        friendsTab.Controls.Add(_friendSurname);
        friendsTab.Controls.Add(label2);
        friendsTab.Controls.Add(_friendName);
        friendsTab.Controls.Add(label1);
        friendsTab.Controls.Add(_friendLayoutPanel);
        friendsTab.Location = new Point(4, 24);
        friendsTab.Name = "friendsTab";
        friendsTab.Padding = new Padding(3);
        friendsTab.Size = new Size(1000, 653);
        friendsTab.TabIndex = 0;
        friendsTab.Text = "Znajomi";
        friendsTab.UseVisualStyleBackColor = true;
        // 
        // label14
        // 
        label14.Anchor = AnchorStyles.Bottom;
        label14.AutoSize = true;
        label14.Location = new Point(8, 584);
        label14.Name = "label14";
        label14.Size = new Size(56, 15);
        label14.TabIndex = 23;
        label14.Text = "Wyszukaj";
        // 
        // _friendFilterInput
        // 
        _friendFilterInput.Anchor = AnchorStyles.Bottom;
        _friendFilterInput.Location = new Point(8, 558);
        _friendFilterInput.Name = "_friendFilterInput";
        _friendFilterInput.Size = new Size(205, 23);
        _friendFilterInput.TabIndex = 22;
        // 
        // _friendDelete
        // 
        _friendDelete.Location = new Point(917, 622);
        _friendDelete.Name = "_friendDelete";
        _friendDelete.Size = new Size(75, 23);
        _friendDelete.TabIndex = 21;
        _friendDelete.Text = "Usuń";
        _friendDelete.UseVisualStyleBackColor = true;
        // 
        // _friendSave
        // 
        _friendSave.Location = new Point(741, 622);
        _friendSave.Name = "_friendSave";
        _friendSave.Size = new Size(75, 23);
        _friendSave.TabIndex = 20;
        _friendSave.Text = "Zapisz";
        _friendSave.UseVisualStyleBackColor = true;
        // 
        // _friendSocialsRemove
        // 
        _friendSocialsRemove.Location = new Point(917, 474);
        _friendSocialsRemove.Name = "_friendSocialsRemove";
        _friendSocialsRemove.Size = new Size(75, 23);
        _friendSocialsRemove.TabIndex = 19;
        _friendSocialsRemove.Text = "Usuń";
        _friendSocialsRemove.UseVisualStyleBackColor = true;
        // 
        // _friendSocialsAdd
        // 
        _friendSocialsAdd.Location = new Point(742, 474);
        _friendSocialsAdd.Name = "_friendSocialsAdd";
        _friendSocialsAdd.Size = new Size(75, 23);
        _friendSocialsAdd.TabIndex = 18;
        _friendSocialsAdd.Text = "Dodaj";
        _friendSocialsAdd.UseVisualStyleBackColor = true;
        // 
        // _friendSocialsInput
        // 
        _friendSocialsInput.Location = new Point(742, 390);
        _friendSocialsInput.Name = "_friendSocialsInput";
        _friendSocialsInput.PlaceholderText = "link do facebook";
        _friendSocialsInput.Size = new Size(250, 23);
        _friendSocialsInput.TabIndex = 17;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(742, 372);
        label5.Name = "label5";
        label5.Size = new Size(74, 15);
        label5.TabIndex = 16;
        label5.Text = "Social Media";
        // 
        // _friendSocials
        // 
        _friendSocials.FormattingEnabled = true;
        _friendSocials.Location = new Point(742, 419);
        _friendSocials.Name = "_friendSocials";
        _friendSocials.Size = new Size(250, 49);
        _friendSocials.TabIndex = 15;
        // 
        // _friendEmailsRemove
        // 
        _friendEmailsRemove.Location = new Point(917, 325);
        _friendEmailsRemove.Name = "_friendEmailsRemove";
        _friendEmailsRemove.Size = new Size(75, 23);
        _friendEmailsRemove.TabIndex = 14;
        _friendEmailsRemove.Text = "Usuń";
        _friendEmailsRemove.UseVisualStyleBackColor = true;
        // 
        // _friendEmailsAdd
        // 
        _friendEmailsAdd.Location = new Point(742, 325);
        _friendEmailsAdd.Name = "_friendEmailsAdd";
        _friendEmailsAdd.Size = new Size(75, 23);
        _friendEmailsAdd.TabIndex = 13;
        _friendEmailsAdd.Text = "Dodaj";
        _friendEmailsAdd.UseVisualStyleBackColor = true;
        // 
        // _friendEmailInput
        // 
        _friendEmailInput.Location = new Point(742, 241);
        _friendEmailInput.Name = "_friendEmailInput";
        _friendEmailInput.PlaceholderText = "xyz@edu.cdv.pl";
        _friendEmailInput.Size = new Size(250, 23);
        _friendEmailInput.TabIndex = 12;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(742, 223);
        label4.Name = "label4";
        label4.Size = new Size(42, 15);
        label4.TabIndex = 11;
        label4.Text = "Emaile";
        // 
        // _friendEmails
        // 
        _friendEmails.FormattingEnabled = true;
        _friendEmails.Location = new Point(742, 270);
        _friendEmails.Name = "_friendEmails";
        _friendEmails.Size = new Size(250, 49);
        _friendEmails.TabIndex = 10;
        // 
        // _friendPhoneListRemove
        // 
        _friendPhoneListRemove.Location = new Point(917, 172);
        _friendPhoneListRemove.Name = "_friendPhoneListRemove";
        _friendPhoneListRemove.Size = new Size(75, 23);
        _friendPhoneListRemove.TabIndex = 9;
        _friendPhoneListRemove.Text = "Usuń";
        _friendPhoneListRemove.UseVisualStyleBackColor = true;
        // 
        // _friendPhoneListAdd
        // 
        _friendPhoneListAdd.Location = new Point(742, 172);
        _friendPhoneListAdd.Name = "_friendPhoneListAdd";
        _friendPhoneListAdd.Size = new Size(75, 23);
        _friendPhoneListAdd.TabIndex = 8;
        _friendPhoneListAdd.Text = "Dodaj";
        _friendPhoneListAdd.UseVisualStyleBackColor = true;
        // 
        // _friendPhoneInput
        // 
        _friendPhoneInput.Location = new Point(742, 88);
        _friendPhoneInput.Name = "_friendPhoneInput";
        _friendPhoneInput.PlaceholderText = "+48 123 345 567";
        _friendPhoneInput.Size = new Size(250, 23);
        _friendPhoneInput.TabIndex = 7;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(742, 70);
        label3.Name = "label3";
        label3.Size = new Size(106, 15);
        label3.TabIndex = 6;
        label3.Text = "Numery telefonów";
        // 
        // _friendPhoneList
        // 
        _friendPhoneList.FormattingEnabled = true;
        _friendPhoneList.Location = new Point(742, 117);
        _friendPhoneList.Name = "_friendPhoneList";
        _friendPhoneList.Size = new Size(250, 49);
        _friendPhoneList.TabIndex = 5;
        // 
        // _friendSurname
        // 
        _friendSurname.Location = new Point(892, 24);
        _friendSurname.Name = "_friendSurname";
        _friendSurname.Size = new Size(100, 23);
        _friendSurname.TabIndex = 4;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(892, 6);
        label2.Name = "label2";
        label2.Size = new Size(57, 15);
        label2.TabIndex = 3;
        label2.Text = "Nazwisko";
        // 
        // _friendName
        // 
        _friendName.Location = new Point(742, 24);
        _friendName.Name = "_friendName";
        _friendName.Size = new Size(100, 23);
        _friendName.TabIndex = 2;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(742, 6);
        label1.Name = "label1";
        label1.Size = new Size(30, 15);
        label1.TabIndex = 1;
        label1.Text = "Imię";
        // 
        // _friendLayoutPanel
        // 
        _friendLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        _friendLayoutPanel.BackColor = Color.Wheat;
        _friendLayoutPanel.Location = new Point(8, 6);
        _friendLayoutPanel.Name = "_friendLayoutPanel";
        _friendLayoutPanel.Size = new Size(728, 546);
        _friendLayoutPanel.TabIndex = 0;
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
        // 
        // _meetingsReminderAddButton
        // 
        _meetingsReminderAddButton.Location = new Point(742, 398);
        _meetingsReminderAddButton.Name = "_meetingsReminderAddButton";
        _meetingsReminderAddButton.Size = new Size(108, 32);
        _meetingsReminderAddButton.TabIndex = 17;
        _meetingsReminderAddButton.Text = "Dodaj";
        _meetingsReminderAddButton.UseVisualStyleBackColor = true;
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
        // 
        // _meetingsDeleteMeetingButton
        // 
        _meetingsDeleteMeetingButton.Location = new Point(884, 462);
        _meetingsDeleteMeetingButton.Name = "_meetingsDeleteMeetingButton";
        _meetingsDeleteMeetingButton.Size = new Size(108, 32);
        _meetingsDeleteMeetingButton.TabIndex = 12;
        _meetingsDeleteMeetingButton.Text = "Usuń spotkanie";
        _meetingsDeleteMeetingButton.UseVisualStyleBackColor = true;
        // 
        // _meetingsSaveMeetingButton
        // 
        _meetingsSaveMeetingButton.Location = new Point(742, 462);
        _meetingsSaveMeetingButton.Name = "_meetingsSaveMeetingButton";
        _meetingsSaveMeetingButton.Size = new Size(108, 32);
        _meetingsSaveMeetingButton.TabIndex = 11;
        _meetingsSaveMeetingButton.Text = "Zapisz spotkanie";
        _meetingsSaveMeetingButton.UseVisualStyleBackColor = true;
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
        // 
        // _addNoteButton
        // 
        _addNoteButton.Location = new Point(803, 295);
        _addNoteButton.Name = "_addNoteButton";
        _addNoteButton.Size = new Size(189, 48);
        _addNoteButton.TabIndex = 1;
        _addNoteButton.Text = "Dodaj pustą notatkę";
        _addNoteButton.UseVisualStyleBackColor = true;
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
        _meetingsPage.ResumeLayout(false);
        _meetingsPage.PerformLayout();
        _notesPage.ResumeLayout(false);
        _notesPage.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage friendsTab;
    private System.Windows.Forms.TabPage meetingsTab;

    #endregion
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
    private FlowLayoutPanel _friendLayoutPanel;
    private Label label1;
    private TextBox _friendName;
    private TextBox _friendSurname;
    private Label label2;
    private TextBox _friendPhoneInput;
    private Label label3;
    private ListBox _friendPhoneList;
    private Button _friendPhoneListRemove;
    private Button _friendPhoneListAdd;
    private Button _friendEmailsRemove;
    private Button _friendEmailsAdd;
    private TextBox _friendEmailInput;
    private Label label4;
    private ListBox _friendEmails;
    private Button _friendSocialsRemove;
    private Button _friendSocialsAdd;
    private TextBox _friendSocialsInput;
    private Label label5;
    private ListBox _friendSocials;
    private Button _friendDelete;
    private Button _friendSave;
    private Label label14;
    private TextBox _friendFilterInput;
}