using OsDsII.api.Models;
namespace OsDsII.api.Services.Comments
{
    public interface ICommentService
    {

        public Task GetCommentAsync(int id);
        public Task AddCommentAsync(int serviceOrderId);
    }
}
