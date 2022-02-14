using Domain.Models;
using MediatR;
using ApplicationUser = Domain.Entities.ApplicationUser;

namespace Application.Features.Profile.GeneralInfo;

public class QueryBasicUserInfoPrivateCommand: IRequest<UserProfileModel>
{
    public ApplicationUser RequestingUser { get; set; }
}