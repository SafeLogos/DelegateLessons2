using DelegateLessons2.Models;

namespace DelegateLessons2.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public Response<bool> SendNotificationToAll() =>
            Response<bool>.DoMethod(resp =>
            {
                resp.Throw("Сервис упал!");
            });

        public Response<bool> SendNotificationToSEO() =>
            Response<bool>.DoMethod(resp =>
            {
                resp.Throw("Сервис упал222!");
            });

        public Response<List<NotificationModel>> GetAllNotifications() =>
            Response<List<NotificationModel>>.DoMethod(resp =>
            {
                resp.Throw("Ну сервис то лежит!");
                resp.Data = new List<NotificationModel>()
                {
                    new NotificationModel() { Receiver = "1", InsertDate = DateTime.Now },
                    new NotificationModel() { Receiver = "2", InsertDate = DateTime.Now },
                    new NotificationModel() { Receiver = "3", InsertDate = DateTime.Now },
                    new NotificationModel() { Receiver = "4", InsertDate = DateTime.Now }
                };
            });
    }

    public interface INotificationRepository 
    {
        Response<bool> SendNotificationToAll();
        Response<bool> SendNotificationToSEO();
        Response<List<NotificationModel>> GetAllNotifications();
    }

}
