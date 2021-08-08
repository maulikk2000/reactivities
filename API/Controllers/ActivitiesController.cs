using Application.Activities;
using Application.Activities.Command.Create;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {       

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {

            var activites = await _mediator.Send(new ActivitiesList.ActivitiesQuery());

            return Ok(activites);
        }

        [HttpGet("{id}", Name = "GetActivity")]
        public async Task<IActionResult> GetActivityById(Guid id)
        {
            //var activity = await _dbContxt.Activities.FindAsync(id);
            //return Ok(activity);
            return Ok(await _mediator.Send(new DetailsQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            var id = await _mediator.Send(new CreateActivityCommand { Activity = activity });
            return CreatedAtAction(nameof(GetActivityById), new { id = id}, activity);
        }
    }
}
