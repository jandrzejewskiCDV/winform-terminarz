using System.Text.RegularExpressions;

namespace Terminarz
{
    internal class NotesView
    {
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private readonly Dictionary<Guid, Note> _cache = new();

        private readonly FlowLayoutPanel _layoutPanel;
        private readonly Button _addNoteButton;
        private readonly RichTextBox _filterNotesInput;
        private readonly CheckBox _regexFilter;

        private string? _filter;

        public NotesView(FlowLayoutPanel layoutPanel,
            Button addNoteButton, RichTextBox filterNotesInput,
            CheckBox regexFilter)
        {
            _layoutPanel = layoutPanel;
            _addNoteButton = addNoteButton;
            _filterNotesInput = filterNotesInput;
            _regexFilter = regexFilter;
        }

        public void Load()
        {
            _layoutPanel.Controls.Clear();

            _addNoteButton.Click += async (s, e) => await OnAddNote();
            _filterNotesInput.TextChanged += (s, e) => OnFilterApplied();

            _ = LoadNotes();
        }

        private void OnFilterApplied()
        {
            _filter = _filterNotesInput.Text;
            UpdateView();
        }

        private async Task LoadNotes()
        {
            await _lock.WaitAsync();
            try
            {
                List<Note>? notes = await Utils.GetObjectsAsync<Note>("notes");

                if (notes != null)
                    _layoutPanel.Invoke(() =>
                    {
                        foreach (Note note in notes)
                        {
                            _cache[note.Identifier] = note;
                            CreateNoteTile(note);
                        }
                    });
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task OnAddNote()
        {
            Note note = new()
            {
                Title = "Nowy tytuł",
                Description = "Nowy opis"
            };

            await _lock.WaitAsync();
            try
            {
                await WebUtils.Post("notes", note);
                _layoutPanel.Invoke(() =>
                {
                    if (!_cache.ContainsKey(note.Identifier))
                        _cache[note.Identifier] = note;

                    CreateNoteTile(note);
                    UpdateView();
                });
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task OnRemoveNote(NoteTile tile)
        {
            Note note = tile.Note;

            await _lock.WaitAsync();
            try
            {
                await WebUtils.Delete("notes/delete/" + note.Identifier);
                _layoutPanel.Invoke(() =>
                {
                    _layoutPanel.Controls.Remove(tile);
                    UpdateView();
                });
            }
            finally
            {
                _lock.Release();
            }
        }

        private async Task OnNoteUpdated(NoteTile noteTile)
        {
            Note note = noteTile.Note;

            if (noteTile.Title == note.Title && noteTile.Description == note.Description)
                return;

            note.Title = noteTile.Title;
            note.Description = noteTile.Description;
            note.Updated = DateTime.Now;

            await _lock.WaitAsync();
            try
            {
                await WebUtils.Post("notes", note);
                _layoutPanel.Invoke(noteTile.UpdateModifiedAt);
            }
            finally
            {
                _lock.Release();
            }
        }

        private void CreateNoteTile(Note note)
        {
            NoteTile tile = new NoteTile(note);
            tile.Deleted += async (s, args) => await OnRemoveNote(tile);
            tile.Save += async (s, args) => await OnNoteUpdated(tile);
            _layoutPanel.Controls.Add(tile);
        }

        public List<Note> SearchByText()
        {
            if (string.IsNullOrWhiteSpace(_filter))
                return [.. _cache.Values];

            return [.. _cache.Values.Where(n =>
             n.Title.Contains(_filter, StringComparison.OrdinalIgnoreCase) ||
             n.Description.Contains(_filter, StringComparison.OrdinalIgnoreCase)
             )];
        }

        public List<Note> SearchByRegex()
        {
            if (string.IsNullOrWhiteSpace(_filter))
                return [.. _cache.Values];

            Regex regex;
            try
            {
                regex = new Regex(_filter, RegexOptions.IgnoreCase);
            }
            catch (ArgumentException)
            {
                return [.. _cache.Values];
            }

            return [.. _cache.Values.Where(n =>
                regex.IsMatch(n.Title ?? "") || regex.IsMatch(n.Description ?? "")
            )];
        }

        private void UpdateView()
        {
            UpdateView(_regexFilter.Checked ? SearchByRegex() : SearchByText());
        }

        private void UpdateView(List<Note> notesToShow)
        {
            HashSet<Guid> noteIds = [.. notesToShow.Select(n => n.Identifier)];

            foreach (NoteTile tile in _layoutPanel.Controls.OfType<NoteTile>())
                tile.Visible = noteIds.Contains(tile.Note.Identifier);
        }
    }
}
