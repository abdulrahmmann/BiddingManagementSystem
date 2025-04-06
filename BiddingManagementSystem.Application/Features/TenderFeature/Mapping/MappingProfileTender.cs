using AutoMapper;
using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using BiddingManagementSystem.Domain.Entities;
using BiddingManagementSystem.Domain.ValueObjects;

public class MappingProfileTender : Profile
{
    public MappingProfileTender()
    {
        // Map: TenderDTO -> Money (BudgetRange)
        CreateMap<TenderDTO, Money>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.BudgetRange_Amount))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.BudgetRange_Currency));

        // Map: TenderDTO -> Address
        CreateMap<TenderDTO, Address>()
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address_Country))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address_City))
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address_Street))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address_ZipCode));

        // Map: TenderDTO -> PaymentTerms
        CreateMap<TenderDTO, PaymentTerms>()
            .ForMember(dest => dest.AdvancePercentage, opt => opt.MapFrom(src => src.PaymentTerms_AdvancePercentage))
            .ForMember(dest => dest.MilestonePercentage, opt => opt.MapFrom(src => src.PaymentTerms_MilestonePercentage))
            .ForMember(dest => dest.FinalApprovalPercentage, opt => opt.MapFrom(src => src.PaymentTerms_FinalApprovalPercentage))
            .ForMember(dest => dest.PenaltyOfDelays, opt => opt.MapFrom(src => src.PaymentTerms_PenaltyOfDelays))
            .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentTerms_PaymentMethod));

        // Map: TenderDTO -> Tender
        CreateMap<TenderDTO, Tender>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.ReferenceNumber))
            .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
            .ForMember(dest => dest.IssuedBy, opt => opt.MapFrom(src => src.IssuedBy))
            .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
            .ForMember(dest => dest.ClosingDate, opt => opt.MapFrom(src => src.ClosingDate))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))
            .ForMember(dest => dest.BudgetRange, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.PaymentTerms, opt => opt.MapFrom(src => src));

        // Reverse mapping: Money -> TenderDTO
        CreateMap<Money, TenderDTO>()
            .ForMember(dest => dest.BudgetRange_Amount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(dest => dest.BudgetRange_Currency, opt => opt.MapFrom(src => src.Currency));

        // Reverse mapping: Address -> TenderDTO
        CreateMap<Address, TenderDTO>()
            .ForMember(dest => dest.Address_Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.Address_City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Address_Street, opt => opt.MapFrom(src => src.Street))
            .ForMember(dest => dest.Address_ZipCode, opt => opt.MapFrom(src => src.ZipCode));

        // Reverse mapping: PaymentTerms -> TenderDTO
        CreateMap<PaymentTerms, TenderDTO>()
            .ForMember(dest => dest.PaymentTerms_AdvancePercentage, opt => opt.MapFrom(src => src.AdvancePercentage))
            .ForMember(dest => dest.PaymentTerms_MilestonePercentage, opt => opt.MapFrom(src => src.MilestonePercentage))
            .ForMember(dest => dest.PaymentTerms_FinalApprovalPercentage, opt => opt.MapFrom(src => src.FinalApprovalPercentage))
            .ForMember(dest => dest.PaymentTerms_PenaltyOfDelays, opt => opt.MapFrom(src => src.PenaltyOfDelays))
            .ForMember(dest => dest.PaymentTerms_PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod));

        // Reverse mapping: Tender -> TenderDTO
        CreateMap<Tender, TenderDTO>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.ReferenceNumber))
            .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
            .ForMember(dest => dest.IssuedBy, opt => opt.MapFrom(src => src.IssuedBy))
            .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
            .ForMember(dest => dest.ClosingDate, opt => opt.MapFrom(src => src.ClosingDate))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))
            .ForMember(dest => dest.BudgetRange_Amount, opt => opt.MapFrom(src => src.BudgetRange.Amount))
            .ForMember(dest => dest.BudgetRange_Currency, opt => opt.MapFrom(src => src.BudgetRange.Currency))
            .ForMember(dest => dest.Address_Country, opt => opt.MapFrom(src => src.Address.Country))
            .ForMember(dest => dest.Address_City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.Address_Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.Address_ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
            .ForMember(dest => dest.PaymentTerms_AdvancePercentage, opt => opt.MapFrom(src => src.PaymentTerms.AdvancePercentage))
            .ForMember(dest => dest.PaymentTerms_MilestonePercentage, opt => opt.MapFrom(src => src.PaymentTerms.MilestonePercentage))
            .ForMember(dest => dest.PaymentTerms_FinalApprovalPercentage, opt => opt.MapFrom(src => src.PaymentTerms.FinalApprovalPercentage))
            .ForMember(dest => dest.PaymentTerms_PenaltyOfDelays, opt => opt.MapFrom(src => src.PaymentTerms.PenaltyOfDelays))
            .ForMember(dest => dest.PaymentTerms_PaymentMethod, opt => opt.MapFrom(src => src.PaymentTerms.PaymentMethod));
    }
}
