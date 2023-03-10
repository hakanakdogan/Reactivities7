using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.EditActivity
{
    public class EditActivityCommandValidator : AbstractValidator<EditActivityCommand.Command>
    {
        public EditActivityCommandValidator()
        {
            RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
        }
    }
}
