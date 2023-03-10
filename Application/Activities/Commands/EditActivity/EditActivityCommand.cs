using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.EditActivity
{
    public class EditActivityCommand
    {
        public class Command : IRequest<Result<Unit>>
        {
            
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;

            public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities.FindAsync(request.Activity.Id);
                if (activity == null)
                {
                    return null;
                }
                //activity.Title  = request.Activity.Title ?? activity.Title;
                _mapper.Map(request.Activity, activity);
                var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
                if(!result)
                {
                    return Result<Unit>.Failure("Failed to edit the activity");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
