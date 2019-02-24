using System;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DatabaseFirstDemoEntities();
            var @event = new Events
            {
                Title = "Second title",
                Description = "Second description",
                LastChange = DateTime.Now
            };

            context.Events.Add(@event);
            context.SaveChanges();
        }
    }
}
