using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

public static class RabbitMQFunction
{
    [FunctionName("RabbitMQTrigger")]
    public static void Run(
        [RabbitMQTrigger("bankingsystem-queue", ConnectionStringSetting = "RabbitMQConnectionString")] string message,
        ILogger logger)
    {
        logger.LogInformation($"Received message: {message}");

        System.IO.File.AppendAllText(@"J:\Test\log.txt", $"{DateTime.Now}: {message}\n");
    }

}
