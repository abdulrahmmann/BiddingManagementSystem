using AutoMapper;
using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Application.Features.TenderFeature.Mapping
{
    public class MappingProfileTender : Profile
    {
        public MappingProfileTender()
        {
            // Mapping from Tender, to TenderDTO
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
                .ForMember(dest => dest.BudgetRange, opt => opt.MapFrom(src => src.BudgetRange))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));


            // Mapping from TenderDTO to Tender
            CreateMap<TenderDTO, Tender>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.ReferenceNumber))
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Deadline))
                .ForMember(dest => dest.IssuedBy, opt => opt.MapFrom(src => src.IssuedBy))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.IssueDate))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))
                .ForMember(dest => dest.BudgetRange, opt => opt.MapFrom(src => src.BudgetRange))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
