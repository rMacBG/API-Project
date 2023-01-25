using API_Models.Context;
using API_Models.Models;
using API_Models.Requests.Authentication_Requests;
using API_Project.Helpers.CustomExceptions;
using API_Project.Services.Interfaces;
using Authorization_Library.Helpers;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;




namespace API_Project.Services
{
    public class UserService : IUserService
    {
        private readonly LibContext appContext;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        
        public UserService(LibContext appContext, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.appContext = appContext;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest model)
        {
            var user = appContext.Users.SingleOrDefault(x => x.Username == model.Username && x.PasswordHash == model.Password);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
               
                  throw new AppException("Username or password is incorrect");
            }

            var token = createJwtToken(user);
            var response = _mapper.Map<AuthenticationResponse>(user);
            response.Token = token;
            return response;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return appContext.Users;
        }

        public User GetById(Guid id)
        {
            var user = appContext.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public void Register(RegisterRequest model)
        {
            if (appContext.Users.Any(x => x.Username == model.Username)) 
            { 
                throw new AppException("Username '"+ model.Username + "' is already taken");
            }
            var result = _mapper.Map<User>(model);
            model.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);
            appContext.Users.Add(result);
            appContext.SaveChanges();

           
        }

        public void Update(Guid id, UpdateRequest user)
        {
            var result = GetById(id);

            if (user.Username != user.Username && appContext.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username '" + user.Username + "' is already taken");
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            }
            _mapper.Map<User>(user);
            appContext.Users.Update(result);
            appContext.SaveChanges();
        }
        private string createJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

        }
        
    }
}
