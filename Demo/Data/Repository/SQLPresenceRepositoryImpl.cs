using Demo.Data.RemoteData;
using Demo.Data.RemoteData.RemoteDataBase;
using Demo.domain.Models;
using Demo.Domain.ModesDAO;
using Microsoft.EntityFrameworkCore;


namespace Demo.Data.Repository
{
    public class SQLPresenceRepositoryImpl : IPresenceRepository
    {
        private readonly RemoteDatabaseContext _remoteDatabaseContext;

        public SQLPresenceRepositoryImpl(RemoteDatabaseContext remoteDatabaseContext)
        {
            _remoteDatabaseContext = remoteDatabaseContext;
        }

        public void SavePresence(List<PresenceLocalEntity> presences)
        {
            foreach (var presence in presences)
            {
                // Проверяем, существует ли запись с указанными датой, пользователем и номером занятия
                var existing = _remoteDatabaseContext.PresenceDaos.FirstOrDefault(p =>
                    p.Date == DateOnly.FromDateTime(presence.Date) &&
                    p.UserGuid == presence.UserGuid &&
                    p.LessonNumber == presence.LessonNumber);

                if (existing == null)
                {
                    // Добавляем запись, если её не существует
                    _remoteDatabaseContext.PresenceDaos.Add(new PresenceDAO
                    {
                        Date = DateOnly.FromDateTime(presence.Date),
                        IsAttedance = presence.IsAttedance,
                        LessonNumber = presence.LessonNumber,
                        UserGuid = presence.UserGuid
                    });
                }
                else
                {
                    // Обновляем запись, если она уже существует
                    existing.IsAttedance = presence.IsAttedance;
                }
            }

            // Сохраняем все изменения в базе данных
            _remoteDatabaseContext.SaveChanges();
        }

        public void AddPresence(PresenceLocalEntity presence)
        {
            if (presence == null) throw new ArgumentNullException(nameof(presence));

            var newPresence = new PresenceDAO
            {
                Date = DateOnly.FromDateTime(presence.Date),
                UserGuid = presence.UserGuid,
                LessonNumber = presence.LessonNumber,
                IsAttedance = presence.IsAttedance
            };
            _remoteDatabaseContext.PresenceDaos.Add(newPresence);
        }

        public List<PresenceLocalEntity> GetPresenceByGroup(int groupId)
        {
            return _remoteDatabaseContext.PresenceDaos.Include(user => user.UserDao)
                .Where(p => p.UserDao != null && p.UserDao.GroupID == groupId) // Проверяем на null перед использованием
                .Select(p => new PresenceLocalEntity
                {
                    Date = p.Date.ToDateTime(TimeOnly.MinValue),
                    UserGuid = p.UserGuid,
                    LessonNumber = p.LessonNumber,
                    IsAttedance = p.IsAttedance
                })
                .ToList();
        }

        public List<PresenceLocalEntity> GetPresenceByGroupAndDate(int groupId, DateTime date)
        {
            return _remoteDatabaseContext.PresenceDaos
                .Where(p => p.UserDao != null && p.UserDao.GroupID == groupId && p.Date == DateOnly.FromDateTime(date))
                .Select(p => new PresenceLocalEntity
                {
                    Date = p.Date.ToDateTime(TimeOnly.MinValue),
                    UserGuid = p.UserGuid,
                    LessonNumber = p.LessonNumber,
                    IsAttedance = p.IsAttedance
                })
                .ToList();
        }

        public void UserAsAbsent(Guid userGuid, int firstLessonNumber, int lastLessonNumber)
        {
            foreach (var lesson in Enumerable.Range(firstLessonNumber, lastLessonNumber - firstLessonNumber + 1))
            {
                var presence = _remoteDatabaseContext.PresenceDaos.FirstOrDefault(p =>
                    p.UserGuid == userGuid &&
                    p.LessonNumber == lesson);

                if (presence != null)
                {
                    presence.IsAttedance = false; // Помечаем как отсутствующего
                }
            }
        }

        public DateOnly? GetLastDateByGroupId(int groupId)
        {
            // Проверяем наличие записей о посещаемости в базе данных для данной группы.
            var lastDate = _remoteDatabaseContext.PresenceDaos
                .Where(p => p.UserDao.GroupID == groupId)
                .OrderByDescending(p => p.Date)
                .Select(p => p.Date)
                .FirstOrDefault();

            return lastDate == default ? (DateOnly?)null : lastDate;
        }

        public bool UpdateAtt(Guid UserGuid, int groupId, int firstLesson, int lastLesson, DateOnly date, bool isAttendance)
        {
            var presences = _remoteDatabaseContext.PresenceDaos
                .Where(p => p.UserGuid == UserGuid && p.UserDao.GroupID == groupId &&
                            p.LessonNumber >= firstLesson && p.LessonNumber <= lastLesson && p.Date == date)
                .ToList();

            if (presences.Any())
            {
                foreach (var presence in presences)
                {
                    presence.IsAttedance = isAttendance;
                }
                _remoteDatabaseContext.SaveChanges();
                return true; // Успех
            }
            return false; // Данные не найдены
        }
        public List<PresenceDAO> GetAttendanceByGroup(int groupId)
        {
            // Получаем пользователей указанной группы
            var userGuidsInGroup = _remoteDatabaseContext.Users
                .Where(u => u.GroupID == groupId)
                .Select(u => u.Guid)
                .ToList();

            // Фильтруем посещаемость по пользователям из этой группы
            return _remoteDatabaseContext.PresenceDaos
                .Where(p => userGuidsInGroup.Contains(p.UserGuid))
                .Select(p => new PresenceDAO
                {
                    UserGuid = p.UserGuid,
                    Id = p.Id,
                    Date = p.Date,
                    LessonNumber = p.LessonNumber,
                    IsAttedance = p.IsAttedance
                })
                .ToList();
        }

        List<PresenceDAO> IPresenceRepository.GetAttendanceByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        void IPresenceRepository.UpdateAtt(Guid UserGuid, int groupId, int firstLesson, int lastLesson, DateOnly date, bool isAttendance)
        {
            throw new NotImplementedException();
        }

        public void MarkUserAsAbsent(Guid userGuid, int firstLessonNumber, int lastLessonNumber)
        {
            throw new NotImplementedException();
        }
    }
}
