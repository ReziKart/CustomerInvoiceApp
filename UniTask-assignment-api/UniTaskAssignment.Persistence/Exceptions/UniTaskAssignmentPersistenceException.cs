using System;
namespace UniTaskAssignment.Persistence.Exceptions
{
    public class UniTaskAssignmentPersistenceException : Exception
    {
        public UniTaskAssignmentPersistenceException()
        {
        }

        public UniTaskAssignmentPersistenceException(string message) : base(message)
        {
        }

        public UniTaskAssignmentPersistenceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

