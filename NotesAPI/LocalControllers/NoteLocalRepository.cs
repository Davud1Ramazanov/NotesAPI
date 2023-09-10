using Microsoft.EntityFrameworkCore;
using NotesAPI.Configuration;
using NotesAPI.Models;
using WildNature_Back.Context;

namespace NotesAPI.LocalControllers
{
    public class NoteLocalRepository : INoteController
    {
        private readonly NotesDbContext _dbContext;

        public NoteLocalRepository(NotesDbContext notesDb)
        {
            _dbContext = notesDb;
        }

        public Task<List<Note>> Create(Note model)
        {
            var item = _dbContext.Notes.FirstOrDefault(x => x.Header.Equals(model.Header) && x.Text.Equals(model.Text));

            if (item == null)
            {
                _dbContext.Notes.Add(model);
                _dbContext.SaveChanges();
            }
            return _dbContext.Notes.ToListAsync();
        }

        public Task<List<Note>> Remove(int id)
        {
            var item = _dbContext.Notes.FirstOrDefault(x => x.Id.Equals(id));

            if (item != null)
            {
                _dbContext.Notes.Remove(item);
                _dbContext.SaveChanges();
            }
            return _dbContext.Notes.ToListAsync();
        }

        public Task<List<Note>> Select()
        {
            return _dbContext.Notes.ToListAsync();
        }

        public Task<List<Note>> FindByName(string header)
        {
            var selectAllNote = _dbContext.Notes.ToList();
            if (!string.IsNullOrEmpty(header))
            {
                selectAllNote = selectAllNote.Where(x => x.Header.Equals(header)).ToList();
            }
            return _dbContext.Notes.ToListAsync();
        }

        public Task<List<Note>> Update(int id, string name)
        {
            var item = _dbContext.Notes.FirstOrDefault(x => x.Id.Equals(id) && x.Text.Equals(name));

            if(item != null)
            {
                item.Text = name;
                _dbContext.SaveChanges();
            }
            return _dbContext.Notes.ToListAsync();
        }

    }
}
