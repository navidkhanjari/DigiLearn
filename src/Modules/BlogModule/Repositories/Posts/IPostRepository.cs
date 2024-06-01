using BlogModule.Domain;
using Common.Domain.Repository;

namespace BlogModule.Repositories.Posts
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        void Delete(Post post);
    }
}
