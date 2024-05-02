using codePulse.API.Data;
using codePulse.API.Models.Domain;
using codePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace codePulse.API.Repositories.Implementation
{
    public class BlogPostRepository: IBlogPostRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await dbContext.BlogPosts.Include(x=>x.Categories).ToListAsync();
        }

        public async Task<BlogPost?> GetByIdAsync(Guid id)
        {
            return await dbContext.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == id);   
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await dbContext.BlogPosts.Include(x => x.Categories).FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            if (existingBlogPost == null) {
                return null;
            }
            //update BlogPosts
            dbContext.Entry(existingBlogPost).CurrentValues.SetValues(blogPost);

            //Update categories
            existingBlogPost.Categories = blogPost.Categories;
            await dbContext.SaveChangesAsync();
            return blogPost;
        }
    }
}
