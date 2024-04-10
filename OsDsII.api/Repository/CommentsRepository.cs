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

        public async Task<Comment> AddCommentAsnyc(int serviceOrderId, Comment comment)
        { 
            _dataContext.Comments.Add(comment);
            await _dataContext.SaveChangesAsync();
            return comment;
        }



    }
}
