using API.Course.Controllers;

namespace API.Course.Configurations
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserViewModelOutput loginViewModelInput);
    }
}
