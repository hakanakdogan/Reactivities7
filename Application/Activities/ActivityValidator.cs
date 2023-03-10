using Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.Venue).NotEmpty().WithMessage("Venue is required");
        }
    }
}
