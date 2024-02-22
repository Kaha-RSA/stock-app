﻿using FinApp.api.Mappers;
using Microsoft.AspNetCore.Mvc;
using FinApp.api.Interfaces;
using FinApp.api.Data;
using Microsoft.AspNetCore.Components.Forms;

namespace FinApp.api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
       

        public CommentController(ICommentRepository commentRepo) 
        {
            _commentRepo = commentRepo;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }
            
    } 
}
