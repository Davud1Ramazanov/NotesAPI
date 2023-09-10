namespace NotesAPI.Configuration
{
    public interface IController<T> where T : class
    {
        public Task<List<T>> Create(T model);
        public Task<List<T>> Update(int id, string name);
        public Task<List<T>> Remove(int id);
        public Task<List<T>> FindByName (string name);
        public Task<List<T>> Select();
    }
}
