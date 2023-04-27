﻿using MediatR;
using ZmitaCart.Application.Common;
using ZmitaCart.Application.Dtos.OfferDtos;

namespace ZmitaCart.Application.Queries.OfferQueries.GetFavouritesOffers;

public record GetFavouritesOffersQuery : IRequest<PaginatedList<OfferInfoDto>>
{
	public int? PageNumber { get; init; }
	public int? PageSize { get; init; }
}