using Domain.Dto.Signup;

namespace Domain.Service.Signup
{
    public interface ISignUpService
    {
        Task<bool> SignUpAsync(SignUpRequestDto userInfo);
        Task<bool> LoginAsync(string username, string password);
    }
}