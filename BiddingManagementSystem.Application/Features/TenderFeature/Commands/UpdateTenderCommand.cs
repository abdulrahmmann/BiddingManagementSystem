﻿using BiddingManagementSystem.Application.Features.TenderFeature.DTOs;
using MediatR;

namespace BiddingManagementSystem.Application.Features.TenderFeature.Commands
{
    public record UpdateTenderCommand(int Id, UpdateTenderDTO TenderDto) : IRequest<bool>;
}
