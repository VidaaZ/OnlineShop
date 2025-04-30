using Domain.Dto.Signup;
using Domain.ViewModel.Signup;

namespace Domain.Mapper.Signup
{
    public static class SignUpMapper
    {
        #region ToDto

        public static SignUpRequestDto ToDto(this SignUpRequestViewModel viewModel)
        {
            return new SignUpRequestDto
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                ConfirmPassword = viewModel.ConfirmPassword,
                Password = viewModel.Password,
                UserName = viewModel.UserName
            };
        }

        #endregion

        #region ToEntity

        #endregion
    }
}
