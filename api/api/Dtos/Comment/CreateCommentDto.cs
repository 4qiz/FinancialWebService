using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Minimal length of Title: 1")]
        [MaxLength(300, ErrorMessage = "Maximum length of Title: 300")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Minimal length of Content: 1")]
        [MaxLength(300, ErrorMessage = "Maximum length of Content: 300")]
        public string Content { get; set; } = string.Empty;
    }
}
