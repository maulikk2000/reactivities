using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class ActivitiesList
    {
        public class ActivitiesQuery : IRequest<List<Activity>> { }

        public class ActivitiesHandler : IRequestHandler<ActivitiesQuery, List<Activity>>
        {
            private readonly DataContext _context;

            public ActivitiesHandler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Activity>> Handle(ActivitiesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync();
            }
        }
    }
}
