using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using FluentValidation;

namespace BiddingManagementSystem.Application.Validation
{
    public class TenderDTOValidator : AbstractValidator<TenderDTO>
    {
        public TenderDTOValidator()
        {
            // ReferenceNumber
            RuleFor(x => x.ReferenceNumber)
                .NotEmpty().WithMessage("Reference number is required.")
                .GreaterThan(0).WithMessage("Reference number must be positive.");

            // Title
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(60).WithMessage("Title cannot exceed 60 characters.");

            // Description
            RuleFor(x => x.Description)
                .MaximumLength(600).WithMessage("Description cannot exceed 600 characters.");

            // IssueDate
            RuleFor(x => x.IssueDate)
                .NotEmpty().WithMessage("Issue date is required.")
                .LessThan(x => x.ClosingDate).WithMessage("Issue date must be before closing date.");

            // ClosingDate
            RuleFor(x => x.ClosingDate)
                .NotEmpty().WithMessage("Closing date is required.")
                .GreaterThan(x => x.IssueDate).WithMessage("Closing date must be after issue date.");

            // Deadline
            RuleFor(x => x.Deadline)
                .NotEmpty().WithMessage("Deadline is required.")
                .GreaterThanOrEqualTo(x => x.IssueDate).WithMessage("Deadline must be after issue date.");

            // Type
            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid tender type.");

            RuleFor(x => x.Industry)
                .IsInEnum().WithMessage("Invalid industry type.");

            // Budget Range
            RuleFor(x => x.BudgetRange_Amount)
                .NotEmpty().WithMessage("Budget amount is required.")
                .Must(BeValidDecimal).WithMessage("Budget amount must be a valid number.");

            RuleFor(x => x.BudgetRange_Currency)
                .NotEmpty().WithMessage("Currency is required.")
                .Length(3).WithMessage("Currency code must be 3 characters (e.g., USD, EUR).");

            // Address
            RuleFor(x => x.Address_Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(40).WithMessage("Country cannot exceed 40 characters.");

            RuleFor(x => x.Address_City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(40).WithMessage("City cannot exceed 40 characters.");

            RuleFor(x => x.Address_Street)
                .MaximumLength(60).WithMessage("Street cannot exceed 60 characters.");

            RuleFor(x => x.Address_ZipCode)
                .MaximumLength(20).WithMessage("Zip code cannot exceed 20 characters.");

            // Payment Terms
            RuleFor(x => x.PaymentTerms_AdvancePercentage)
                .NotEmpty().WithMessage("Advance percentage is required.")
                .Must(BeValidDecimal).WithMessage("Advance percentage must be a valid number.");

            RuleFor(x => x.PaymentTerms_MilestonePercentage)
                .NotEmpty().WithMessage("Milestone percentage is required.")
                .Must(BeValidDecimal).WithMessage("Milestone percentage must be a valid number.");

            RuleFor(x => x.PaymentTerms_FinalApprovalPercentage)
                .NotEmpty().WithMessage("Final approval percentage is required.")
                .Must(BeValidDecimal).WithMessage("Final approval percentage must be a valid number.");

            // Validate that percentages sum to 100%
            RuleFor(x => new
            {
                x.PaymentTerms_AdvancePercentage,
                x.PaymentTerms_MilestonePercentage,
                x.PaymentTerms_FinalApprovalPercentage
            })
                .Must(x => BeValidPercentageSum(
                    x.PaymentTerms_AdvancePercentage,
                    x.PaymentTerms_MilestonePercentage,
                    x.PaymentTerms_FinalApprovalPercentage
                ))
                .WithMessage("Payment terms must sum to 100%.");

            RuleFor(x => x.PaymentTerms_PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.");

            RuleFor(x => x.PaymentTerms_PenaltyOfDelays)
                .MaximumLength(500).WithMessage("Penalty description cannot exceed 500 characters.");
        }

        private bool BeValidDecimal(string value) =>
            decimal.TryParse(value, out _);

        private bool BeValidPercentageSum(string advance, string milestone, string final)
        {
            if (!decimal.TryParse(advance, out var a) ||
                !decimal.TryParse(milestone, out var m) ||
                !decimal.TryParse(final, out var f))
                return false;

            return (a + m + f) == 100m;
        }
    }
}
