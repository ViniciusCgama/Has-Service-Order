using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Services.Comments;

namespace OsDsII.api.Controllers
{

    [ApiController]
    [Route("ServiceOrders/{id}/comment")]
    public class CommentController : ControllerBase
    {
        private readonly DataContext _context; // atributo
        private readonly ICommentService _commentService;

        public CommentController(DataContext context, ICommentService commentService) //construtor
        {
            _context = context;
            _commentService = commentService;
        }

        public CommentController()
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetCommentsAsync(int serviceOrderId)
        {
            try { 
                await _commentService.GetCommentAsync(serviceOrderId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> AddComment(int serviceOrderId, Comment comment)
        {
            try
            {
                await _commentService.AddCommentAsync(serviceOrderId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public string GetCommentsAsync(string aaaaa)
        {
            throw new NotImplementedException();
        }
    }
}

