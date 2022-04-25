using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetZero.WebApplication.Services
{
    /// <summary>
    /// Сервис пользователей
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        /// <returns></returns>
        string GetCurrentUser();

        /// <summary>
        /// Проверяет, является ли userName текущим пользователем
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool IsCurrentUser(string userName);

        /// <summary>
        /// Получение идентификатора группы рассмотрения пользователя
        /// </summary>
        /// <returns></returns>
        int? GetUserConsiderationGroupId();

        /// <summary>
        /// Пользователь является участником группы принятия решений
        /// </summary>
        /// <returns></returns>
        bool IsDecisionUser();

        /// <summary>
        /// Сотрудник отдела информационной безопасности
        /// </summary>
        /// <returns></returns>
        bool IsInformationSecurityUser();

        /// <summary>
        /// Пользователь является участником группы рассмотрения
        /// </summary>
        /// <returns></returns>
        bool IsConsiderationUser();
    }
}
