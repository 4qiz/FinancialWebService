using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToDtoFromComment(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
                Title = comment.Title,
            };
        }

        public static Comment ToCommentFromCreateDto(this CreateCommentDto comment, int stockId)
        {
            return new Comment
            {
                Content = comment.Content,
                Title = comment.Title,
                StockId = stockId,
            };
        }

        public static Comment ToCommentFromUpdateDto(this UpdateCommentDto comment)
        {
            return new Comment
            {
                Content = comment.Content,
                Title = comment.Title,
            };
        }
    }
}
