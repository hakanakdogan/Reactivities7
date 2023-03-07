using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommand
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities.FindAsync(request.Id);
                _dataContext.Activities.Remove(activity);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
