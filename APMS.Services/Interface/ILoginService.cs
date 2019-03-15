using System.Threading.Tasks;
using APMS.BusinessLogic.Dto;
using APMS.BusinessLogic.ViewModels.User;

namespace APMS.Services
{
    public interface ILoginService
    {
        /// <summary>
        ///     Login user
        /// </summary>
        /// <param name="viewModel"><see cref="LoginViewModel"></see></param>
        /// <returns><see cref="UserDto"/> or null if user not found.</returns>
        /// <exception cref="InvalidCredentialsException">If credentials are invalid</exception>
        Task<UserDto> LoginAsync(LoginViewModel viewModel);
    }
}