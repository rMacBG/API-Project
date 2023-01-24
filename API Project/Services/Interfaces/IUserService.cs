using API_Models.Models;
using API_Models.Requests.Authentication_Requests;

namespace API_Project.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequest model);
        void Update(int id, UpdateRequest user);
        void Delete(int id);

    }
}
