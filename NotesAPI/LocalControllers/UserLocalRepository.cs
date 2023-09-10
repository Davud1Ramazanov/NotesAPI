using Microsoft.EntityFrameworkCore;
using NotesAPI.Configuration;
using NotesAPI.Models;
using WildNature_Back.Context;

namespace NotesAPI.LocalControllers
{
    public class UserLocalRepository : IUserController
    {
        private readonly NotesDbContext _dbContext;

        public UserLocalRepository(NotesDbContext notesDb)
        {
            _dbContext = notesDb;
        }

        public Task<List<User>> Create(User model)
        {
            var item = _dbContext.Users.FirstOrDefault(x => x.Name.Equals(model.Name));

            if (item == null)
            {
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();
            }
            return _dbContext.Users.ToListAsync();
        }

        public Task<List<User>> Remove(int id)
        {
            var item = _dbContext.Users.FirstOrDefault(x => x.Id.Equals(id));

            if (item != null)
            {
                _dbContext.Users.Remove(item);
                _dbContext.SaveChanges();
            }
            return _dbContext.Users.ToListAsync();
        }

        public Task<List<User>> Select()
        {
            return _dbContext.Users.ToListAsync();
        }

        public Task<List<User>> Update(int id, string name)
        {
            var item = _dbContext.Users.FirstOrDefault(x => x.Id.Equals(id) && x.Name.Equals(name));

            if (item != null)
            {
                item.Name = name;
                _dbContext.SaveChanges();
            }
            return _dbContext.Users.ToListAsync();
        }

        public async Task<List<User>> FindByName(string name)
        {
            var select = _dbContext.Users.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                select = select.Where(user => user.Name.ToLower().Equals(name));
            }
            return await select.ToListAsync();
        }



        public bool Authorization(string username, string password)
        {
            var item = _dbContext.Users.FirstOrDefault(x => x.Name.Equals(username) && x.Password.Equals(password));

            if (item != null)
            {
                return true;
            }
            return false;
        }
    }
}
