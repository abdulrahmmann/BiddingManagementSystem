/* using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Application.Features.TenderFeature.Mapping
{
    public class CreateTenderMappingProfile : Profile
    {
        public CreateTenderMappingProfile()
        {
            // From Tender entity to CreateTenderDTO
            CreateMap<Tender, CreateTenderDTO>()
                // Simple properties
                .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.ReferenceNumber))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IssuedBy, opt => opt.MapFrom(src => src.IssuedBy))
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.ClosingDate, opt => opt.MapFrom(src => src.ClosingDate))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))

                // BudgetRange
                .ForMember(dest => dest.BudgetRange_Amount, opt => opt.MapFrom(src => src.BudgetRange.Amount))
                .ForMember(dest => dest.BudgetRange_Currency, opt => opt.MapFrom(src => src.BudgetRange.Currency))

                // Address
                .ForMember(dest => dest.Address_Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.Address_City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Address_Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Address_ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))

                // PaymentTerms
                .ForMember(dest => dest.PaymentTerms_AdvancePercentage, opt => opt.MapFrom(src => src.PaymentTerms.AdvancePercentage))
                .ForMember(dest => dest.PaymentTerms_MilestonePercentage, opt => opt.MapFrom(src => src.PaymentTerms.MilestonePercentage))
                .ForMember(dest => dest.PaymentTerms_FinalApprovalPercentage, opt => opt.MapFrom(src => src.PaymentTerms.FinalApprovalPercentage))
                .ForMember(dest => dest.PaymentTerms_PaymentMethod, opt => opt.MapFrom(src => src.PaymentTerms.PaymentMethod))
                .ForMember(dest => dest.PaymentTerms_PenaltyOfDelays, opt => opt.MapFrom(src => src.PaymentTerms.PenaltyOfDelays));


            // From CreateTenderDTO to Tender entity
            CreateMap<CreateTenderDTO, Tender>()
                // Simple properties
                .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.ReferenceNumber))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IssuedBy, opt => opt.MapFrom(src => src.IssuedBy))
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.ClosingDate, opt => opt.MapFrom(src => src.ClosingDate))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))

                // BudgetRange (use ForPath for nested mapping)
                .ForPath(dest => dest.BudgetRange.Amount, opt => opt.MapFrom(src => src.BudgetRange_Amount))
                .ForPath(dest => dest.BudgetRange.Currency, opt => opt.MapFrom(src => src.BudgetRange_Currency))

                // Address (use ForPath for nested mapping)
                .ForPath(dest => dest.Address.Country, opt => opt.MapFrom(src => src.Address_Country))
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.Address_City))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Address_Street))
                .ForPath(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.Address_ZipCode))

                // PaymentTerms (use ForPath for nested mapping)
                .ForPath(dest => dest.PaymentTerms.AdvancePercentage, opt => opt.MapFrom(src => src.PaymentTerms_AdvancePercentage))
                .ForPath(dest => dest.PaymentTerms.MilestonePercentage, opt => opt.MapFrom(src => src.PaymentTerms_MilestonePercentage))
                .ForPath(dest => dest.PaymentTerms.FinalApprovalPercentage, opt => opt.MapFrom(src => src.PaymentTerms_FinalApprovalPercentage))
                .ForPath(dest => dest.PaymentTerms.PaymentMethod, opt => opt.MapFrom(src => src.PaymentTerms_PaymentMethod))
                .ForPath(dest => dest.PaymentTerms.PenaltyOfDelays, opt => opt.MapFrom(src => src.PaymentTerms_PenaltyOfDelays));
        }
    }
}
*/