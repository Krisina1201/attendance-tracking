using Demo.domain.Models;
using Demo.Domain.ModesDAO;

namespace Demo.Data.Repository
{
    public interface IPresenceRepository
    {
        void AddPresence(PresenceLocalEntity presence);
        List<PresenceDAO> GetAttendanceByGroup(int groupId);
        //GroupPresenceSummary GetGeneralPresenceForGroup(int groupId);
        DateOnly? GetLastDateByGroupId(int groupId);
        List<PresenceLocalEntity> GetPresenceByGroup(int groupId);
        List<PresenceLocalEntity> GetPresenceByGroupAndDate(int groupId, DateTime date);
        void MarkUserAsAbsent(Guid userGuid, int firstLessonNumber, int lastLessonNumber);
        void SavePresence(List<PresenceLocalEntity> presences);
        void UpdateAtt(Guid UserGuid, int groupId, int firstLesson, int lastLesson, DateOnly date, bool isAttendance);
    }
}