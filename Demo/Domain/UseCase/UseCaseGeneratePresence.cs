using Demo.Data.Repository;
using Demo.domain.Models;


namespace Demo.Domain.UseCase
{
    public class UseCaseGeneratePresence
    {
        public readonly IUserRepository _userRepository;
        public readonly IPresenceRepository _presenceRepository;
        public readonly IGroupRepository _groupRepository;

        public UseCaseGeneratePresence(IUserRepository userRepository, IPresenceRepository presenceRepository, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _presenceRepository = presenceRepository;
            _groupRepository = groupRepository;
        }

        public List<PresenceLocalEntity> GetPresenceByGroupAndDate(int groupId, DateTime date)
        {
            return _presenceRepository.GetPresenceByGroupAndDate(groupId, date);
        }


        public void GeneratePresenceDaily(int firstLesson, int lastLesson, int groupId, DateTime currentDate)
        {
            var users = _userRepository.GetAllUsers.Where(u => u.GroupID == groupId).ToList();
            List<PresenceLocalEntity> presences = new List<PresenceLocalEntity>();
            for (int lessonNumber = firstLesson; lessonNumber <= lastLesson; lessonNumber++)
            {
                foreach (var user in users)
                {
                    presences.Add(new PresenceLocalEntity
                    {
                        UserGuid = user.Guid,
                        Date = currentDate,
                        LessonNumber = lessonNumber,
                        IsAttedance = true
                    });
                }
            }
            _presenceRepository.SavePresence(presences);
        }

        public void GenerateWeeklyPresence(int firstLesson, int lastLesson, int groupId, DateTime startTime)
        {
            for (int i = 0; i < 7; i++)
            {
                DateTime currentTime = startTime.AddDays(i);
                GeneratePresenceDaily(firstLesson, lastLesson, groupId, currentTime);
            }
        }



        public void UserAsAbsent(Guid userGuid, int groupId, int firstLesson, int lastLesson, DateTime date)
        {
            var presences = _presenceRepository.GetPresenceByGroupAndDate(groupId, date);
            foreach (var presence in presences.Where(p => p.UserGuid == userGuid && p.LessonNumber >= firstLesson && p.LessonNumber <= lastLesson))
            {
                presence.IsAttedance = false;



            }
            _presenceRepository.SavePresence(presences);
        }



        public List<PresenceLocalEntity> GetAllPresenceByGroup(int groupId)
        {
            return _presenceRepository.GetPresenceByGroup(groupId);
        }
    }
}
