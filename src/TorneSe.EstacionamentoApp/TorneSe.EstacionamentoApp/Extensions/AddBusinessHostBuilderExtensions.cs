﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TorneSe.EstacionamentoApp.Extensions;

public static class AddBusinessHostBuilderExtensions
{
    public static IHostBuilder AddBusiness(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            
        });

        return hostBuilder;
    } 
}
