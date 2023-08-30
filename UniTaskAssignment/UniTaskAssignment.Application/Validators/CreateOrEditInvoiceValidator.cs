using System;
using FluentValidation;
using UniTaskAssignment.Application.Commands;

namespace UniTaskAssignment.Application.Validators
{
    public class CreateOrEditInvoiceValidator : AbstractValidator<CreateOrEditInvoiceCommand>
    {
        public CreateOrEditInvoiceValidator()
        {
            RuleFor(command => command.Amount)
               .NotEmpty()
               .WithMessage("Amount is required!")
               .GreaterThan(0)
               .WithMessage("Amount should be more than 0!");

            RuleFor(command => command.Status).IsInEnum().WithMessage("Provide right status!");

            RuleFor(command => command.InvoiceDate)
               .NotEmpty()
               .WithMessage("invoice date is required")
               .Must((command, endDate) => endDate > command.DueDate)
               .WithMessage("Due date must be greater than invoice date");
            }
    }
}

