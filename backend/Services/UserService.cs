﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Data;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;




namespace TaskManagementSystem.Services
{
    public class UserService : IUserInterface
    {
        private readonly AppDBContext _db;

        private readonly IConfiguration _configuration;
        public UserService(AppDBContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        public async Task<IEnumerable<TblUser>> GetAllUsersDetails()
        {
            return await _db.TblUsers.ToListAsync();
        }

        public async Task<TblUserJWT> LoginAsync(string userName, string userPassword)
        {
            try
            {
                string hashedPassword = HashSHA1Password(userPassword);

                var user = await _db.TblUsers
                    .FirstOrDefaultAsync(us => us.UserName.Equals(userName) && us.UserPassword.Equals(hashedPassword) && us.IsActive == true);

                if (user != null)
                {
                    // Generate JWT token for the authenticated user
                    string jwtToken = await GenerateJwtTokenAsync(user);

                    TblUserJWT jwt = new TblUserJWT
                    {
                        UserName = user.UserName,
                        UserToken = jwtToken
                    };

                    var loginHistory = new TblUserLoginHistory
                    {
                        UserName = user.UserName,
                        Attempt = true
                    };
                    _db.TblUserLoginHistories.Add(loginHistory);
                    await _db.SaveChangesAsync();

                    return jwt;
                }

                return null; // Or handle the case when user is not found
            }
            catch (Exception ex)
            {
                // Handle the exception, log the error, or perform any necessary actions
                // For example, you can throw a custom exception or return an error message
                throw new Exception("An error occurred during login.", ex);
            }
        }





        //public async Task<string> GenerateJwtTokenAsync(TblUser user)
        //{

        //    string secretKeyJWT = _configuration["Jwt:Key"];

        //    // Define the secret key used to sign the token
        //    string secretKey = secretKeyJWT; // Replace with your own secret key
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        //    // Create signing credentials using the key
        //    var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    // Define the claims for the token
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.UserName),
        //        // Add additional claims as needed
        //    };

        //    // Create the token descriptor
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.AddHours(1), // Set the token expiration time
        //        SigningCredentials = signingCredentials
        //    };

        //    // Create the token handler
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    // Generate the token
        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    // Convert the token to its string representation
        //    var jwtToken = tokenHandler.WriteToken(token);

        //    return jwtToken;
        //}


        public async Task<string> GenerateJwtTokenAsync(TblUser user)
        {
            string secretKeyJWT = _configuration["Jwt:Key"];

            // Define the secret key used to sign the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKeyJWT));

            // Create signing credentials using the key
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // Define the claims for the token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                // Add additional claims as needed
            };

            // Create the token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"], // Set the correct audience value
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10), // Set the token expiration time
                SigningCredentials = signingCredentials,

            };

            // Create the token handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // Generate the token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Convert the token to its string representation
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }



        private string HashSHA1Password(string password)
        {
            var SHA1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(password);
            var hash = SHA1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }


    }
}



