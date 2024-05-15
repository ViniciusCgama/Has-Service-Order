using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public class CommentsRepository
    {
        private readonly DataContext _dataContext;

        public CommentsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Comment> GetCommentAsync(int servieOrderId)
        {
           return await  _dataContext.Comments.FirstOrDefaultAsync(c => c.ServiceOrderId == servieOrderId);
        }

        public async Task<Comment> AddCommentAsnyc(Comment commentExists)
        {
            await _dataContext.Comments.AddAsync(commentExists); // This line adds the comment to the context
            await _dataContext.SaveChangesAsync();
            return commentExists;
        }



    }
}
