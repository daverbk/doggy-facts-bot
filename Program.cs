using DoggyFactsBot.BotControllers;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure(app =>
        {
            app.Run(async context =>
            {
                await new BotLauncher().Launch(cancellationToken: context.RequestAborted);
            });
        });
    })
    .Build().Run();
