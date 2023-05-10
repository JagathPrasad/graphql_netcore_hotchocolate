using GraphQL.Helper;
using GraphQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraphQL.Service
{
    public class UserService : IUserService
    {
        ImmihubContext db;
        public UserService()
        {
            db = new ImmihubContext();
        }

        public async Task<List<Models.User>> GetUser()
        {
            try
            {
                return await db.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool> CreateUser(string name, string password)
        {
            try
            {
                Models.User user = new Models.User
                {
                    Name = name,
                    Password = password
                };
                db.AddAsync(user);
                return await db.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<bool> UpdateUser(Helper.User user)
        //{
        //    try
        //    {
        //        db.Attach(user);
        //        return await db.SaveChangesAsync() > 0 ? true : false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<string> CheckUser(LoginInput input)
        {
            /*
             mutation{
                 checkUser(input: {email:"",password:""})
                 }
             */

            //var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
            //var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //var jwtToken = new JwtSecurityToken(
            //    issuer: tokenSettings.Value.Issuer,
            //    audience: tokenSettings.Value.Audience,
            //    expires: DateTime.Now.AddMinutes(20),
            //    signingCredentials: credentials
            //);

            //string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            //return token;
            return GenerateJWTToken(input.Email,input.Password);
        }


        public string GenerateJWTToken(string userName, string password)
        {
            string jwt_token = string.Empty;
            try
            {
                string key = "my_secret_key_12345";
                var issuer = "http://mysite.com";
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
                var perclaim = new List<Claim>();
                perclaim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                perclaim.Add(new Claim("user_name", userName));
                perclaim.Add(new Claim("password", password));
                //perclaim.Add(new Claim("user_type", Convert.ToString(userType)));

                var token = new JwtSecurityToken(issuer, issuer, perclaim, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
                jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch (Exception ex)
            {

            }
            return jwt_token;
        }
    }

    public interface IUserService
    {
        Task<bool> CreateUser(string name, string password);
        //Task<bool> UpdateUser(Helper.User user);
        Task<string> CheckUser(LoginInput input);
        Task<List<Models.User>> GetUser();
    }
}
