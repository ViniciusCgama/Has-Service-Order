using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public interface ICommentsRepository
    {
        Task<Customer> GetCommentAsync(int serviceOrderId);
        Task<Customer> AddCommentAsnyc(int ServiceOrderId, Comment comment);
    }
}
