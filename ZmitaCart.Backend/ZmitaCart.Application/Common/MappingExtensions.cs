﻿using Microsoft.EntityFrameworkCore;

namespace ZmitaCart.Application.Common;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> ToPaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable,
        int? pageNumber, int? pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);
}