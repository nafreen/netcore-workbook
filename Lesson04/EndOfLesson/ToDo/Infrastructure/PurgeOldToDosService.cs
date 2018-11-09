﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToDoApp.Services;

namespace ToDoApp.Infrastructure
{
    public class PurgeOldToDosService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger _logger;
        private Timer _timer;

        public PurgeOldToDosService(IServiceScopeFactory serviceScopeFactory, ILogger<PurgeOldToDosService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Starting {0} in background...", nameof(PurgeOldToDosService));
            _timer = new Timer(DoWork, null, TimeSpan.FromSeconds(30), TimeSpan.FromMinutes(5));
            _logger.LogDebug("{0} started.", nameof(PurgeOldToDosService));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogDebug("Triggered {0}...", nameof(PurgeOldToDosService));

            using (var scope = _serviceScopeFactory.CreateScope())
            using (var repository = scope.ServiceProvider.GetService<IRepository>())
            {

                var shallowCopy = repository.ToDos.ToList();
                var now = DateTime.Now;
                foreach (var toDo in shallowCopy.Where(x => x.Created.HasValue))
                {
                    if (toDo.Created.Value.AddMonths(1) < now)
                        repository.DeleteToDo(toDo.Id);
                }
            }

            _logger.LogDebug("{0} completed.", nameof(PurgeOldToDosService));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Stopping backgrounded {0}...", nameof(PurgeOldToDosService));
            _timer?.Change(Timeout.Infinite, 0);
            _logger.LogDebug("{0} stopped.", nameof(PurgeOldToDosService));
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
