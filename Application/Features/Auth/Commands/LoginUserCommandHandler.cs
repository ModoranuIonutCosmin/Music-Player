using Application.Interfaces;
using Application.Services.Implementation;
using Domain.Exceptions;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashGenerator hashGenerator;
        private readonly JwtService _jwtService;

        public LoginUserCommandHandler(IUserRepository userRepository,
            IPasswordHashGenerator hashGenerator)
        {
            _userRepository = userRepository;
            this.hashGenerator = hashGenerator;
            _jwtService = new JwtService();
        }

        public async Task<LoginResponseDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            _ = await IsUserOk(request.UserName, request.Password);

            return _jwtService.GenerateJwt(request);
        }

        private async Task<bool> IsUserOk(string userName, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(userName);
            
            if (user == null)
                throw new UserNotFoundException($"{userName} doesn't exist in db");
            
            var userSalt = user.Salt;
            var passwordHash = hashGenerator.HashPassword(password, userSalt);

            if (user.PasswordHash != passwordHash)
                throw new AuthenticationFailedException($"{userName} wrong authentication data");

            return true;
        }
    }
}
