using Business.Services.Models.Login;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ILogin_Service
    {
        Task<AuthenticateResponse> Login(AuthenticateRequest model);
    }
}
