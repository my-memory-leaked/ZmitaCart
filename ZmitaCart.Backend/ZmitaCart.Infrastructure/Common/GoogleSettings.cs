﻿namespace ZmitaCart.Infrastructure.Common;

public class GoogleSettings
{
	public const string sectionName = "Authentication:Google";
	public string ClientId { get; init; } = null!;
	public string ClientSecret { get; init; } = null!;
}