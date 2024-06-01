using System.ComponentModel.DataAnnotations;

namespace TaskManager.Contracts.User
{
    public record RegisterUserRequest([Required] string name,
                                      [Required] string email,
                                      [Required] string paswword);
}
