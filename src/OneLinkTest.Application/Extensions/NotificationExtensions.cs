using FluentValidation.Results;
using OneLinkTest.Application.Services;

namespace OneLinkTest.Application.Extensions
{
    public static class NotificationExtensions
    {
        public static void AddValidationResult(this Notification notification, ValidationResult result)
        {
            foreach (var error in result.Errors)
            {
                notification.Add(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
