using API_Models.Models;

namespace API_Project.Services.Interfaces
{
    public interface IJwtUtilizer
    {
        
            public string GenerateToken(User user);
            public int? ValidateToken(string token);
        
    }
}
