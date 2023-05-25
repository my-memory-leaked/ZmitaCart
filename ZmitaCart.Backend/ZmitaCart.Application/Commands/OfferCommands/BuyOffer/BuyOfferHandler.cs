﻿using FluentResults;
using MediatR;
using ZmitaCart.Application.Common.Errors;
using ZmitaCart.Application.Interfaces;
using ZmitaCart.Application.Services;

namespace ZmitaCart.Application.Commands.OfferCommands.BuyOffer;

public class BuyOfferHandler : IRequestHandler<BuyOfferCommand, Result>
{
	private readonly IOfferRepository _offerRepository;
	private readonly ICurrentUserService _currentUserService;

	public BuyOfferHandler(IOfferRepository offerRepository, ICurrentUserService currentUserService)
	{
		_offerRepository = offerRepository;
		_currentUserService = currentUserService;
	}

	public async Task<Result> Handle(BuyOfferCommand request, CancellationToken cancellationToken)
	{
		if (_currentUserService.UserId is null)
		{
			return Result.Fail(new UnauthorizedError("You are not authorized to buy an offer."));
		}
		
		var userId = int.Parse(_currentUserService.UserId);
		
		//TODO payment service
		
		
		return await _offerRepository.BuyAsync(userId, request.OfferId, request.Quantity);
	}
}