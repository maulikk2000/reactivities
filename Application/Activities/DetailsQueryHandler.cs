using Domain;
using MediatR;
using Persistence;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class DetailsQueryHandler : IRequestHandler<DetailsQuery, Activity>
    {
        private readonly DataContext _context;

        public DetailsQueryHandler(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<Activity> Handle(DetailsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FindAsync(request.Id);

        }
    }
}
