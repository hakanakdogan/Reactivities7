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

namespace Application.Activities.Queries.DetailActivity
{
    public class DetailActivityQuery
    {
        public class Query : IRequest<Result<Activity>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Activities.FirstOrDefaultAsync(x => x.Id == request.Id);
                return Result<Activity>.Success(activity);
            }
        }
    }
}
