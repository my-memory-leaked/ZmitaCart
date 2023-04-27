﻿using ZmitaCart.Application.Common;
using ZmitaCart.Application.Dtos.OfferDtos;

namespace ZmitaCart.Application.Interfaces;

public interface IOfferRepository
{
    Task<int> CreateAsync(CreateOfferDto offerDto);
    Task<int> UpdateAsync(UpdateOfferDto offerDto);
    Task DeleteAsync(int userId, int offerId);
    Task<PaginatedList<OfferInfoDto>> GetOffersByCategoryAsync(int categoryId, int? pageNumber = null, int? pageSize = null);
    Task<OfferDto> GetOfferAsync(int id);
    Task AddToFavoritesAsync(int userId, int offerId);
}