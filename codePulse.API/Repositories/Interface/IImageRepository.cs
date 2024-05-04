using codePulse.API.Models.Domain;

namespace codePulse.API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<BlogImage> Upload(IFormFile file, BlogImage blogImage);
        Task<IEnumerable<BlogImage>> GetAll();
    }
}
