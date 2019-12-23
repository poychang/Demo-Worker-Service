using System;

namespace DemoWorkerService.Services
{
    public class TimeService
    {
        public DateTime WhatTimeIsIt()
        {
            var now = DateTime.Now;

            Console.WriteLine(now);

            return now;
        }
    }
}
