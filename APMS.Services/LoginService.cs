using APMS.BusinessLogic.Dto;
using APMS.BusinessLogic.Exceptions;
using APMS.BusinessLogic.ViewModels.User;
using APMS.Data.Entities;
using APMS.Repositories.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace APMS.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<LoginService> _logger;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public LoginService(IUserRepository userRepository, ILogger<LoginService> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<User>();
        }

        /// <summary>
        ///     Login user
        /// </summary>
        /// <param name="viewModel"><see cref="LoginViewModel"></see></param>
        /// <returns><see cref="UserDto"/> or null if user not found.</returns>
        /// <exception cref="InvalidCredentialsException">If credentials are invalid</exception>
        public async Task<UserDto> LoginAsync(LoginViewModel viewModel)
        {
            try
            {
                var result = await _userRepository.GetFiltered(x => x.EmailAddress.ToLower().Equals(viewModel.EmailAddress));

                // todo get filtered as single or default as well as ienumerable
                var user = result.SingleOrDefault();

                // todo compare hashed passwords
                var pwdResult = _passwordHasher.VerifyHashedPassword(user, user.Password, viewModel.Password);

                if(pwdResult == PasswordVerificationResult.Failed)
                {
                    _logger.LogWarning($"Invalid login attempt for email address {viewModel.EmailAddress}");   
                    throw new InvalidCredentialsException();
                }

                return _mapper.Map<UserDto>(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in LoginAsync", viewModel);
                return null;
            }
        }
    }
}
