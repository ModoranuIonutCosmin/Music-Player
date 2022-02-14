using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Datamodels;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Domain.Models;

namespace Application.Features.Auth.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterResponseDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSyntaxValidator _emailSyntaxValidator;
        private readonly ISubscriptionsService _subscriptionsService;
        private readonly IMapper _mapper;
        private readonly IPasswordHashGenerator hashGenerator;

        public RegisterUserCommandHandler(IUserRepository userRepository,
            IEmailSyntaxValidator emailSyntaxValidator,
            ISubscriptionsService subscriptionsService,
            IMapper mapper,
            IPasswordHashGenerator hashGenerator)
        {
            _userRepository = userRepository;
            _emailSyntaxValidator = emailSyntaxValidator;
            _subscriptionsService = subscriptionsService;
            _mapper = mapper;
            this.hashGenerator = hashGenerator;
        }

        public async Task<RegisterResponseDTO> Handle(RegisterUserCommand requestModel, CancellationToken cancellationToken)
        {
            if (requestModel is null)
            {
                throw new ArgumentNullException(nameof(requestModel));
            }

            if (requestModel.FirstName is null || requestModel.LastName is null)
            {
                throw new ArgumentException("firstName and lastName body properties must not be null");
            }

            if (!_emailSyntaxValidator.IsEmailValid(requestModel.Email))
                throw new FormatException("Invalid email syntax");

            bool userNameTaken = (await _userRepository.GetByUsernameAsync(requestModel.UserName)) != null;
            bool emailTaken = (await _userRepository.GetByEmail(requestModel.Email)) != null;

            if (userNameTaken)
                throw new UserAlreadyExistsException($"UserName {requestModel.UserName} is taken.");

            if (emailTaken)
                throw new UserEmailTakenException($"Email {requestModel.Email} is bound to another account!");

            var newUser = _mapper.Map<RegisterUserCommand, Domain.Entities.ApplicationUser>(requestModel);
            var newSalt = hashGenerator.GenerateSalt();
            
            newUser.Salt = Convert.ToHexString(newSalt);
            newUser.PasswordHash = hashGenerator.HashPassword(requestModel.Password, newUser.Salt);
            newUser.Subscription = new Subscription();

            await _userRepository.AddAsync(newUser);

            _subscriptionsService.GrantSubscriptionPlan(newUser.Id, SubscriptionType.FREE);
            
            return _mapper.Map<RegisterUserCommand, RegisterResponseDTO>(requestModel);
        }
    }
}
