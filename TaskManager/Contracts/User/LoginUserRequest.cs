using System.ComponentModel.DataAnnotations;

namespace TaskManager.Contracts.User
{
    public record LoginUserRequest([Required] string email,
                                   [Required] string paswword);
    
}
