﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace ZmitaCart.Application.Commands.OfferCommands.UpdateOfferCommand;

public record UpdateOfferCommand : IRequest<int>
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public decimal? Price { get; set; }
	public int? Quantity { get; set; }
	public bool? IsAvailable { get; set; }
	public string? Condition { get; set; }
	public ICollection<int>? PictureIdsToRemove { get; set; }
	public ICollection<IFormFile>? PicturesToAdd { get; set; }
}