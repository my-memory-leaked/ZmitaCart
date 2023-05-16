﻿using MediatR;
using Microsoft.AspNetCore.SignalR;
using ZmitaCart.Application.Events;
using ZmitaCart.Application.Hubs;

namespace ZmitaCart.API.Hubs;

public class ChatHub : Hub, IChatHub
{
	private readonly IPublisher _mediator;

	public ChatHub(IPublisher mediator)
	{
		_mediator = mediator;
	}

	public async Task JoinAsync(int chat, CancellationToken cancellationToken)
	{
		try
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, chat.ToString(), cancellationToken);
			await ConnectAsync();
			await _mediator.Publish(new JoinedChat(chat), cancellationToken);
		}
		catch
		{
			await DisconnectAsync();
			throw;
		}
	}
	
	public async Task RestoreMessagesAsync(int userId, string user, int chat, string text, DateTimeOffset date, CancellationToken cancellationToken)
	{
		await Clients.Caller.SendAsync("ReceiveMessage", new
		{
			UserId = userId,
			UserName = user, 
			Date = date, 
			Content = text
		}, cancellationToken);
	}
	
	public async Task SendMessageAsync(string user, int chat, string text, DateTimeOffset date, CancellationToken cancellationToken)
	{
		await Clients.Group(chat.ToString()).SendAsync("ReceiveMessage", new
		{
			UserName = user, 
			Date = date, 
			Content = text
		}, cancellationToken);
	}
	
	private async Task ConnectAsync() => await Clients.Client(Context.ConnectionId).SendAsync("Connected");

	private async Task DisconnectAsync() => await Clients.Client(Context.ConnectionId).SendAsync("Disconnected");
	
}
