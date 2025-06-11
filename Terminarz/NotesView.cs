using System.Text.RegularExpressions;

namespace Terminarz
{
    internal class NotesView
    {
        private readonly INoteRepository _noteRepository;
        private readonly FlowLayoutPanel _layoutPanel;

        public NotesView(INoteRepository noteRepository, FlowLayoutPanel layoutPanel)
        {
            _noteRepository = noteRepository;
            _layoutPanel = layoutPanel;
        }

        public void Load()
        {
            _layoutPanel.Controls.Clear();

            foreach (Note note in _noteRepository.FindAll())
                CreateNoteTile(note);
        }

        public void OnFilterApplied(string filter, bool isRegex)
        {
            UpdateView(isRegex ? SearchByRegex(filter) : SearchByText(filter));
        }

        public void OnAddNote()
        {
            Note note = new Note();
            note.Title = "Nowy tytuł";
            note.Description = "Nowy opis";

            _noteRepository.Save(note);

            CreateNoteTile(note);
        }

        private void OnRemoveNote(NoteTile tile)
        {
            _noteRepository.Delete(tile.Note.Id);
            _layoutPanel.Controls.Remove(tile);
        }

        private void OnNoteUpdated(NoteTile noteTile)
        {
            Note note = noteTile.Note;

            if (noteTile.Title == note.Title && noteTile.Description == note.Description)
                return;

            note.Title = noteTile.Title;
            note.Description = noteTile.Description;
            note.Updated = DateTime.Now;
            _noteRepository.Save(note);

            noteTile.UpdateModifiedAt();
        }

        private void CreateNoteTile(Note note)
        {
            NoteTile tile = new NoteTile(note);
            tile.Deleted += (s, args) => OnRemoveNote(tile);
            tile.Save += (s, args) => OnNoteUpdated(tile);
            _layoutPanel.Controls.Add(tile);
        }

        public List<Note> SearchByText(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return _noteRepository.FindAll();

            List<Note> results = _noteRepository.FindAll(n => 
             n.Title.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
             n.Description.Contains(filter, StringComparison.OrdinalIgnoreCase)
             );

            return results;
        }

        public List<Note> SearchByRegex(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return _noteRepository.FindAll();

            Regex regex;
            try
            {
                regex = new Regex(pattern, RegexOptions.IgnoreCase);
            }
            catch (ArgumentException)
            {
                return _noteRepository.FindAll();
            }

            List<Note> results = _noteRepository.FindAll(n =>
                regex.IsMatch(n.Title ?? "") || regex.IsMatch(n.Description ?? "")
            );

            return results;
        }

        private void UpdateView(List<Note> notesToShow)
        {
            HashSet<Guid> noteIds = notesToShow.Select(n => n.Id).ToHashSet();

            foreach (NoteTile tile in _layoutPanel.Controls.OfType<NoteTile>())
                tile.Visible = noteIds.Contains(tile.Note.Id);
        }

        private void ShowAllNotes()
        {
            foreach (NoteTile tile in _layoutPanel.Controls.OfType<NoteTile>())
                tile.Visible = true;
        }
    }
}
