using DelegateLessons2.Repositories;

namespace DelegateLessons2.Extensions
{
    public static class DependencyExtension
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUsersService, UsersService>();
        }

        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
        }
    }
}
