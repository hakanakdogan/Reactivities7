using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand.Command>
    {
        public CreateActivityCommandValidator()
        {
            RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            
        }
    }
}
