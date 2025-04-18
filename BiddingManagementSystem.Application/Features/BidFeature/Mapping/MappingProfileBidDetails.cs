using AutoMapper;
using BiddingManagementSystem.Application.Features.BidFeature.DTOs;
using BiddingManagementSystem.Domain.Entities;

namespace BiddingManagementSystem.Application.Features.BidFeature.Mapping
{
    public class MappingProfileBidDetails : Profile
    {
        public MappingProfileBidDetails()
        {
            CreateMap<Bid, BidDetailDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.TechnicalProposal, opt => opt.MapFrom(src => src.TechnicalProposal))
           .ForMember(dest => dest.FinancialProposal, opt => opt.MapFrom(src => src.FinancialProposal))
           .ForMember(dest => dest.TotalBidAmount, opt => opt.MapFrom(src => src.TotalBidAmount))
           .ForMember(dest => dest.TenderTitle, opt => opt.MapFrom(src => src.Tender.Title))
           .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
           .ForMember(dest => dest.BidderName, opt => opt.MapFrom(src => src.Bidder.CompanyName))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
           .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(item => new BidItemDTO
           {
               Description = item.Description,
               Quantity = item.Quantity,
               UnitPrice = item.UnitPrice
           }).ToList()));
        }
    }
}
