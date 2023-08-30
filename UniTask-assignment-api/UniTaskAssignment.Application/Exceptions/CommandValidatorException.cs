using System;
namespace UniTaskAssignment.Application.Exceptions
{
	public class CommandValidatorException: UniTaskAssignmentApplicationException
	{
		public CommandValidatorException()
		{
		}
		public CommandValidatorException(string message): base(message)
		{

		}
	}
}

