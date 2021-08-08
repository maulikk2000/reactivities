using MediatR;
using Persistence;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.Command.Create
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Guid>
    {
        private readonly DataContext _context;

        public CreateActivityCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            _context.Activities.Add(request.Activity);

            await _context.SaveChangesAsync();

            return request.Activity.Id;
        }
    }
}
