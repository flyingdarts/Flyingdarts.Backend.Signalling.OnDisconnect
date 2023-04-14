
using System;
using Amazon.DynamoDBv2;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;

public static class ServiceFactory
{
    public static ServiceProvider GetServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<AmazonDynamoDBClient>();
        services.AddValidatorsFromAssemblyContaining<OnDisconnectCommandValidator>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OnDisconnectCommand).Assembly));
        return services.BuildServiceProvider();
    }
}