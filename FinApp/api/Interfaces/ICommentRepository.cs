using FinApp.api.Models;

namespace FinApp.api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> CreateAsync(Comment commentModel);
    }
}
