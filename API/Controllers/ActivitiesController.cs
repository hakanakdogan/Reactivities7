using Application.Activities.Commands.CreateActivity;
using Application.Activities.Commands.DeleteActivity;
using Application.Activities.Commands.EditActivity;
using Application.Activities.Queries.DetailActivity;
using Application.Activities.Queries.ListActivities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController: BaseApiController
    {
        

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult( await Mediator.Send(new ListActivitiesQuery.Query()));
        }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetActivity(Guid id)
        {
            
            return HandleResult(await Mediator.Send(new DetailActivityQuery.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)    
        {
            return HandleResult(await Mediator.Send(new CreateActivityCommand.Command { Activity = activity}));  
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new EditActivityCommand.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteActivityCommand.Command { Id = id }));
        }
    }
}
