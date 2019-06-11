﻿namespace Pharmacy.Infrastructure.Exceptions
{
    public static class ErrorCodes
    {
        public static string EmailInUse => "email_in_use";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidCredentials => "invalid_credentials";
        public static string UserNotFound => "user_not_found";
        public static string ResourceNotFound => "resource_not_found";
        public static string InactiveUserLoginAttempt => "inactive_user_login_attempt";
    }
}