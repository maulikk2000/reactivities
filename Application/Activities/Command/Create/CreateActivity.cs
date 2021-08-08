using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Command.Create
{
    public class CreateActivityCommand : IRequest<Guid>
    {
        public Activity Activity { get; set; }
    }
}
