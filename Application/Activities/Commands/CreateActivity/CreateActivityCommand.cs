using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand
    {
        public class Command : IRequest<Unit>
        {
            public Activity Activity { get; set; }

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
                _dataContext.Activities.Add(request.Activity);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
