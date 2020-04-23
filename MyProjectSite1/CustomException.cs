using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProjectSite1
{
    public class CustomException
    {
        public class RangeException : Exception
        {

        }

        public class UserNotFoundException: Exception
        {
            public UserNotFoundException(string message) : base(message)
            {

            }
        }

        public class UserRegistrationFailedException : Exception
        {
            public UserRegistrationFailedException(string message) : base(message)
            {

            }
        }

        public class InvalidAccountException : Exception
        {
            public InvalidAccountException(string message) : base(message)
            {

            }
        }
    }
}