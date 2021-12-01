using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    // Message vermek için tekrar tekrar new 'lememek için static verdik.
  public static class Messages
    {
        public static string Added = "Added";
        public static string Updated = "Updated";
        public static string Deleted = "Deleted";
        public static string Listed = "Listed";
        public static string NotAdded = "Not Added";
        public static string NotUpdated = "Not Updated";
        public static string NotDeleted = "Not Deleted";
        public static string NotListed = "Not Listed";
        public static string NameInvalid = "Invalid Name";
        public static string InvalidEntry = "Invalid Entry";
        public static string MaintenanceTime = "Maintenance Time";
        public static string NotAvailable = "Not Available";
        public static string FindeksPointNotEnough = "Findeks Point Not Enough";



        // ValidationAspectMessages
        public static string WrongValidationType = "Wrong Validation Type";
        public static string CanNotBeBlank = "Can not be blank.";
        public static string InvalidEmailAddress = "Email Address in Invalid Format.";



        //SecuredAspectMessages
        public static string AuthorizationDenied = "You are not authorized."; public static string UserNotFound = "User not found.";
        public static string PasswordError = "Password is wrong.";
        public static string SuccessfulLogin = "Login to the system is successful.";
        public static string UserAlreadyExists = "This user already exists.";
        public static string UserRegistered = "User successfully registered.";
        public static string AccessTokenCreated = "Access token successfully created. ";
        public static string PasswordChanged = "Password Changed. ";
    }
}
