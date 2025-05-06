using Domain.Dto.Signup;
using Domain.Service.Signup;

namespace Business.Service.SignupService
{
    internal class SignUpService : ISignUpService
    {
        private readonly ISignupRepository _signUpRepository;

        public SignUpService(ISignupRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }

        public async Task<bool> SignUpAsync(SignUpRequestDto userInfo)
        {
            var existingUser = await _signUpRepository.UserExistsAsync(userInfo.UserName, userInfo.Email);
            if (existingUser != null)
                throw new Exception("User with the same username or email already exists");

            var hashedPassword = HashPassword(userInfo.Password);
            var user = _mapper.Map<entities.User>(userInfo);
            user.PasswordHash = hashedPassword;

            user.IsActive = true;
            user.RoleId = 1;    
            await _signUpRepository.AddUserAsync(user);

            return true;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _signUpRepository.GetUSerByUserNameAsync(username);

            if (user == null)
                return false;


            return VerifyPassword(password, user.PasswordHash);
        }


        private bool VerifyPassword(string password, string hashedPassword)
        {

            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
