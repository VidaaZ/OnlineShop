using Domain.Mapper.Signup;
using Domain.Service.Signup;
using Domain.ViewModel.Signup;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Signup
{
    [Route("api/signup")]
    public class SignUpController : ControllerBase
    {
        #region Properties

        private readonly ISignUpService _signUpService;
        private readonly ILogger<SignUpController> _logger;

        #endregion

        #region Constructor

        public SignUpController(ISignUpService signUpService, ILogger<SignUpController> logger)
        {
            _signUpService = signUpService;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignupAsync([FromBody] SignUpRequestViewModel signUpInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        _logger.LogError(error.ErrorMessage);
                    }
                    return BadRequest(ModelState);
                }

                var result = await _signUpService.SignUpAsync(signUpInfo.ToDto());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestViewModel loginRequest)
        {
            try
            {
                var isAuthenticated = await _signUpService.LoginAsync(loginRequest.UserName, loginRequest.Password);

                if (!isAuthenticated)
                    return Unauthorized("Invalid username or password");

                return Ok("Login successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
