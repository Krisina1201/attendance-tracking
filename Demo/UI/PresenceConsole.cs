using Demo.Data.Repository;
using Demo.domain.Models;
using Demo.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI
{
    public class PresenceConsoleUI
    {
        public readonly UseCaseGeneratePresence _presenceUseCase;
        public readonly IPresenceRepository _presenceRepository;

        public PresenceConsoleUI(UseCaseGeneratePresence presenceUseCase, IPresenceRepository presenceRepository)
        {
            _presenceUseCase = presenceUseCase;
            _presenceRepository = presenceRepository;
        }

        public void GeneratePresenceForDay(DateTime date, int groupId, int firstLesson, int lastLesson)
        {
            try
            {
                _presenceUseCase.GeneratePresenceDaily(firstLesson, lastLesson, groupId, date);
                Console.WriteLine("Посещаемость на день успешно сгенерирована.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации посещаемости: {ex.Message}");
            }
        }


        public void GeneratePresenceForWeek(DateTime date, int groupId, int firstLesson, int lastLesson)
        {
            try
            {
                _presenceUseCase.GenerateWeeklyPresence(firstLesson, lastLesson, groupId, date);
                Console.WriteLine("Посещаемость на неделю успешно сгенерирована.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации посещаемости: {ex.Message}");
            }
        }


        public void DisplayPresence(DateTime date, int groupId)
        {
            try
            {
                List<PresenceLocalEntity> presences = _presenceUseCase.GetPresenceByGroupAndDate(groupId, date);

                if (presences == null || presences.Count == 0)
                {
                    Console.WriteLine("Нет данных о посещаемости на выбранную дату.");
                    return;
                }

                Console.WriteLine($"Посещаемость на {date:dd.MM.yyyy}");

                int previousLessonNumber = -1;

                foreach (var presence in presences)
                {
                    if (previousLessonNumber != presence.LessonNumber)
                    {
                        Console.WriteLine($"Занятие: {presence.LessonNumber}");
                        previousLessonNumber = presence.LessonNumber;
                    }

                    string status = presence.IsAttedance ? "Присутствует" : "Отсутствует";
                    Console.WriteLine($"Пользователь (ID: {presence.UserGuid}) - Статус: {status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отображении посещаемости: {ex.Message}");
            }
        }


        public void UserAsAbsent(DateTime date, int groupId, Guid userGuid, int firstLesson, int lastLesson)
        {
            _presenceUseCase.UserAsAbsent(userGuid, groupId, firstLesson, lastLesson, date);
        }




        public void DisplayAllPresenceByGroup(int groupId)
        {
            try
            {
                var presences = _presenceUseCase.GetAllPresenceByGroup(groupId);

                if (presences == null || !presences.Any())
                {
                    Console.WriteLine($"Нет данных о посещаемости для группы с ID: {groupId}.");
                    return;
                }

                var groupedPresences = presences.GroupBy(p => p.Date);

                foreach (var group in groupedPresences)
                {
                    Console.WriteLine($"Дата: {group.Key:dd.MM.yyyy}");
                    int previousLessonNumber = -1;

                    foreach (var presence in group)
                    {
                        if (previousLessonNumber != presence.LessonNumber)
                        {
                            Console.WriteLine($"Занятие: {presence.LessonNumber}");
                            previousLessonNumber = presence.LessonNumber;
                        }
                        string status = presence.IsAttedance ? "✅ Присутствует" : "❌ Отсутствует";
                        Console.WriteLine($"Пользователь (ID: {presence.UserGuid}) - Статус: {status}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отображении посещаемости: {ex.Message}");
            }
        }

        //public void DisplayGeneralPresenceForGroup(int groupId)
        //{
        //    var summary = _presenceRepository.GetGeneralPresenceForGroup(groupId);

        //    Console.WriteLine($"Человек в группе: {summary.UserCount}, " +
        //                      $"Количество проведённых занятий: {summary.LessonCount}, " +
        //                      $"Общий процент посещаемости группы: {summary.TotalAttendancePercentage}%");

        //    foreach (var user in summary.UserAttendances)
        //    {
        //        if (user.AttendanceRate < 40)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //        }

        //        Console.WriteLine($"GUID Пользователя: {user.UserGuid}, " +
        //                          $"Посетил: {user.Attended}, " +
        //                          $"Пропустил: {user.Missed}, " +
        //                          $"Процент посещаемости: {user.AttendanceRate}%");
        //        Console.ResetColor();
        //    }
        //}
        //public void ExportAttendanceToExcel()
        //{
        //    try
        //    {
        //        _presenceUseCase.ExportAttendanceToExcel();
        //        Console.WriteLine("Данные посещаемости успешно экспортированы в Excel.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Ошибка при экспорте посещаемости: {ex.Message}");
        //    }
        //}


    }
}
