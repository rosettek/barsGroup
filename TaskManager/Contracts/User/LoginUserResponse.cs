using System.ComponentModel.DataAnnotations;

namespace TaskManager.Contracts.User
{
    public record LoginUserResponse([Required] string email,
                                    [Required] string paswword);
    
}
