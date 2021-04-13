using System;
using System.ComponentModel.DataAnnotations;

namespace CChallange.Api.Models
{
    public class SubmitTaskModel
    {
        [Required]
        public Guid TaskId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(64)]
        public string SubmissionerName { get; set; }

        [Required]
        [MaxLength(1024)]
        public string SolutionCode { get; set; }
    }
}
