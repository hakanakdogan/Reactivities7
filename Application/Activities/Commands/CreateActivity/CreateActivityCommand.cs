using Application.Core;
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
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }

        }


        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _dataContext.Activities.Add(request.Activity);
                var result = await _dataContext.SaveChangesAsync(cancellationToken) >0;
                if(!result)
                {
                    return Result<Unit>.Failure("Failed to create activity");
                }
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
