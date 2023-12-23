

namespace Writer.Api.Models
{
    public class WriterRepository : List<Models.Writer>, IWriterRepository
    {
        private readonly static List<Models.Writer> _writer = Populate();

        private static List<Models.Writer> Populate()
        {
            var result = new List<Models.Writer>()
        {
            new Models.Writer
            {
                Id = 1,
                Name = "First Writer"
            },
            new Models.Writer
            {
                Id = 2,
                Name = "Second Writer"
            },
            new Models.Writer
            {
                Id = 3,
                Name = "Third Writer"
            }
        };

            return result;
        }
        public Writer Get(int id)
        {
            return _writer.FirstOrDefault(x => x.Id == id);
        }

        public List<Writer> GetAll()
        {
            return _writer;
        }

        public Writer Insert(Writer writer)
        {
            writer.Id = _writer.Max(x => x.Id) + 1;
            _writer.Add(writer);

            return writer;
        }
    }
}
