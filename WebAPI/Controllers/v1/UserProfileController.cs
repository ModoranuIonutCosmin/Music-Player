using Application.Features.Profile.GeneralInfo;
using Application.Features.Profile.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers.v1;

[ApiVersion("1.0")]
public class UserProfileController: BaseController
{
    public UserProfileController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> GetUserProfileBasicInfo()
    {
        return Ok(await mediator.Send(new QueryBasicUserInfoPrivateCommand()
        {
            RequestingUser = (Request.HttpContext.Items["User"] as Domain.Entities.ApplicationUser)
        }));
    }
    
    [HttpPut("subscriptions/upgrade")]
    [Authorize]
    public async Task<IActionResult> ModifyUserSubscription(UpgradeUserSubscriptionCommand addSubscriptionCommand)
    {
        return Ok(await mediator.Send(new UpgradeUserSubscriptionCommand()
        {
            RequestingUser = (Request.HttpContext.Items["User"] as Domain.Entities.ApplicationUser),
            SubscriptionType = addSubscriptionCommand.SubscriptionType
        }));
    }
}