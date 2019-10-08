using Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DBRepository.Interfaces;

namespace DBRepository.Repositories
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        public BlogRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

        public async Task<Page<Post>> GetPosts(int index, int pageSize, string tag = null)
        {
            var result = new Page<Post>() { CurrentPage = index, PageSize = pageSize };

            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Posts.AsQueryable();
                if (!string.IsNullOrWhiteSpace(tag))
                {
                    query = query.Where(p => p.Tags.Any(t => t.TagName == tag));
                }

                result.TotalPages = await query.CountAsync();
                result.Records = await query.Include(p => p.Tags).Include(p => p.Comments).OrderByDescending(p => p.CreatedDate).Skip(index * pageSize).Take(pageSize).ToListAsync();
            }

            return result;
        }
    }
}
