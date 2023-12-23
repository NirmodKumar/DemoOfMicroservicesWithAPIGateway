namespace Article.Api.Models
{
    public interface IArticleRepository
    {
        public List<Models.Article> GetAll();
        public Models.Article? Get(int id);

        public int Delete(int id);
    }
}
