using System;
namespace UniTaskAssignment.Application.Exceptions
{
	public class UniTaskAssignmentApplicationException: Exception
	{
		public UniTaskAssignmentApplicationException()
		{
		}
		public UniTaskAssignmentApplicationException(string message): base(message)
		{

		}
	}
}

