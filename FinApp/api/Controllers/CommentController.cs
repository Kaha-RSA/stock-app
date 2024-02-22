using FinApp.api.Mappers;
using Microsoft.AspNetCore.Mvc;
using FinApp.api.Interfaces;
using FinApp.api.Data;

namespace FinApp.api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly ApplicationDBContext _context;

        public CommentController(ICommentRepository commentRepo, ApplicationDBContext context) 
        {
            _commentRepo = commentRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }
            
    }
}
