using System;
namespace UniTaskAssignment.Domain.Exceptions
{
    public class UniTaskAssignmentDomainException : Exception
    {
        public UniTaskAssignmentDomainException()
        {
        }



        public UniTaskAssignmentDomainException(string message) : base(message)
        {
        }

        public UniTaskAssignmentDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

