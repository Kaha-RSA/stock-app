using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata;
using System;
using System.Runtime.CompilerServices;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using FinApp.Dtos.Comment;
using FinApp.Models;

namespace FinApp.Mappers
{
    public static class CommentMapper
    {
        // Extension method to map a CommentModel to a CommentDto
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            // Creating a new CommentDto and populating its properties using the values from CommentModel
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        {
            // Creating a new CommentDto and populating its properties using the values from CommentModel
            return new Comment
            {
          
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId,
            };
        }

    }
}
/*
namespace FinApp.api.Mappers: This extension method is defined within the Mappers namespace.

public static class CommentMapper : A static class named CommentMapper is defined, indicating that it contains static methods for mapping between different types.

public static CommentDto ToCommentDto(this Comment CommentModel): This is an extension method for the Comment class. The this keyword before the Comment parameter indicates that it is an extension method.

Inside the method:

It takes a CommentModel object as a parameter.
Creates a new CommentDto object and initializes its properties using the corresponding properties from the CommentModel.
This extension method simplifies the process of mapping a CommentModel object to a CommentDto object, providin*//*g a cleaner and more readable way to perform this transformation.*/