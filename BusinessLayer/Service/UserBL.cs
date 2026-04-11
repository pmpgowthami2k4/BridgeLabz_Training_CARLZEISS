//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using BusinessLayer.Interfaces;
//using DataBaseLayer.Interfaces;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using ModelLayer.DTOs;
//using ModelLayer.Entities;

//namespace BusinessLayer.Service
//{
//    public class UserBL : IUserBL
//    {
//        private readonly IUserDL _userDL;
//        private readonly IConfiguration _configuration;
//        private readonly IEmailService _emailService;

//        public UserBL(IUserDL userDL, IConfiguration configuration, IEmailService emailService)
//        {
//            _userDL = userDL;
//            _configuration = configuration;
//            _emailService = emailService;
//        }

//        // LOGIN
//        public async Task<string> Login(UserLoginDto dto)
//        {
//            var user = await _userDL.GetUserByEmail(dto.Email);

//            if (user == null)
//                throw new Exception("Invalid email or password");

//            bool isValidPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

//            if (!isValidPassword)
//                throw new Exception("Invalid email or password");

//            // Generate JWT Token
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                    new Claim("UserId", user.UserId.ToString()),
//                    new Claim(ClaimTypes.Email, user.Email)
//                }),
//                Expires = DateTime.UtcNow.AddMinutes(
//                    Convert.ToInt32(_configuration["Jwt:DurationInMinutes"])),

//                Issuer = _configuration["Jwt:Issuer"],
//                Audience = _configuration["Jwt:Audience"],

//                SigningCredentials = new SigningCredentials(
//                    new SymmetricSecurityKey(key),
//                    SecurityAlgorithms.HmacSha256Signature)
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }

//        // REGISTER
//        public async Task<User> Register(UserRegisterDto dto)
//        {
//            var existingUser = await _userDL.GetUserByEmail(dto.Email);

//            if (existingUser != null)
//                throw new Exception("User already exists");

//            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

//            var user = new User
//            {
//                FirstName = dto.FirstName,
//                LastName = dto.LastName,
//                Email = dto.Email,
//                Password = hashedPassword,
//                CreatedAt = DateTime.UtcNow,
//                ChangedAt = DateTime.UtcNow,
//                IsActive = true
//            };

//            // First save user
//            var createdUser = await _userDL.CreateUser(user);

//            // Then send welcome email
//            //await _emailService.SendEmail(
//            // createdUser.Email,
//            //    "Welcome to Fundoo",
//            //    $"Hi {createdUser.FirstName}, welcome to Fundoo Notes 🎉"
//            //);

//            return createdUser;
//        }
//    }
//}
//=====================================================================================================
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Interfaces;
using BusinessLayer.RabbitMQ; // 👈 ADD THIS
using DataBaseLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserDL _userDL;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IRabbitMQProducer _rabbitMQProducer; // 👈 ADD

        public UserBL(
            IUserDL userDL,
            IConfiguration configuration,
            IEmailService emailService,
            IRabbitMQProducer rabbitMQProducer) // 👈 ADD
        {
            _userDL = userDL;
            _configuration = configuration;
            _emailService = emailService;
            _rabbitMQProducer = rabbitMQProducer; // 👈 ADD
        }

        // LOGIN
        public async Task<string> Login(UserLoginDto dto)
        {
            var user = await _userDL.GetUserByEmail(dto.Email);

            if (user == null)
                throw new Exception("Invalid email or password");

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            if (!isValidPassword)
                throw new Exception("Invalid email or password");

            // Generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(
                    Convert.ToInt32(_configuration["Jwt:DurationInMinutes"])),

                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // REGISTER
        public async Task<User> Register(UserRegisterDto dto)
        {
            var existingUser = await _userDL.GetUserByEmail(dto.Email);

            if (existingUser != null)
                throw new Exception("User already exists");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = hashedPassword,
                CreatedAt = DateTime.UtcNow,
                ChangedAt = DateTime.UtcNow,
                IsActive = true
            };

            // Save user in DB
            var createdUser = await _userDL.CreateUser(user);

            Console.WriteLine("RabbitMQ sending message..."); // 👈 DEBUG

            // SEND EMAIL VIA RABBITMQ (ASYNC)
            await _rabbitMQProducer.SendMessage(new EmailDTO
            {
                To = createdUser.Email,
                Subject = "Welcome to Fundoo",
                Body = $"Hi {createdUser.FirstName}, welcome to Fundoo Notes 🎉"
            });

            return createdUser;
        }
    }
}