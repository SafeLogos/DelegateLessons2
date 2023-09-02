using DelegateLessons2.Models;

namespace DelegateLessons2.Repositories
{

    public class UsersService : IUsersService
    {
        private readonly INotificationRepository _notificationRepository;

        public UsersService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Response<List<UserModel>> GetUsers() =>
            Response<List<UserModel>>.DoMethod(resp =>
            {
                //Проверка БД на подключение
                if (1 > 0)
                    resp.Throw("БД Лежит");

                resp.ThrowIf(1 > 0, "БД Лежит");



                List<UserModel> users = new List<UserModel>()
                {
                    new UserModel("Юра", 10),
                    new UserModel("Валя", 12),
                    new UserModel("Бешкарбек", 15)
                };

                List<NotificationModel> notification = _notificationRepository.GetAllNotifications().GetResultIfNotError();

                //_notificationRepository.SendNotificationToAll().GetResultIfNotError();

                resp.Data = users;
            });
    }

    public interface IUsersService 
    {
        Response<List<UserModel>> GetUsers();
    }
}
