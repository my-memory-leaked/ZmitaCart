﻿using FluentResults;

namespace ZmitaCart.Application.Common.Errors;

public class UnauthorizedError : IError
{
	public UnauthorizedError(string message)
	{
		Message = message;
	}

	public string Message { get; }
	public Dictionary<string, object>? Metadata { get; set; }
	public List<IError>? Reasons { get; set; }
}