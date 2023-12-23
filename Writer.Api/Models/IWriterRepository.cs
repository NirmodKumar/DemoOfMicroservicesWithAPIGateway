namespace Writer.Api.Models
{
    public interface IWriterRepository
    {
        public List<Writer> GetAll();
        public Writer Get(int id);
        public Writer Insert(Writer writer);
    }
}
