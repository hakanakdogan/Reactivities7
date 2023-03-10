using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries.ListActivities
{
    public class ListActivitiesQuery
    {
        public class Query : IRequest<Result<List<Activity>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Activity>>.Success (await _dataContext.Activities.ToListAsync(cancellationToken));
            }
        }
    }
}
