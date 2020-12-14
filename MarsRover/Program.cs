using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Interfaces;
using MarsRover.Application.SpaceCenters;
using MarsRover.Domain.Interfaces;
using MarsRover.Domain.LandingSurfaces;
using MarsRover.Domain.Squads;
using MarsRover.Infrastructure.InputReader;
using MarsRover.Infrastructure.NavigationAdvisors;
using MarsRover.Infrastructure.Reports;
using MarsRover.Infrastructure.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover
{
    class Program
    {
        static int Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IInputReader, AutomaticConsoleReader>()
                .AddSingleton<ILandingSurface, MarsPlateau>()
                .AddTransient<IReport, ConsoleReport>()
                .AddTransient<IValidator, CustomValidator>()
                .AddTransient<ISquad, Rover>()
                .AddTransient<ISpaceCenter, Houston>()
                .AddTransient<INavigationAdvisor, NavigationAdvisor>()
                .AddScoped<CommandManager>()
                .BuildServiceProvider();

            
            try
            {
                var inputReader = serviceProvider.GetService<IInputReader>();
                inputReader.ProcessInput();

                var spaceCenter = serviceProvider.GetService<ISpaceCenter>();
                spaceCenter.SetLandingSize(inputReader.SpaceCenterInput.UpperRightCoordinatesOfLandingSurface);
                foreach (var order in inputReader.SpaceCenterInput.SquadOrders)
                {
                    try
                    {
                        spaceCenter.SetSquad(serviceProvider.GetService<ISquad>());
                        spaceCenter.SetOrder(order);
                        spaceCenter.StartProcess();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occured while squad reseaching: {ex.Message}");
                        continue;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured while input processing: {ex.Message}");
                return -1;
            }

            return 0;
        }
    }
}
