using Events;
using System;
namespace Tasks
{
	public class TaskState
	{
		private CreatedEvent _createdEvent = new CreatedEvent();
		private TaskDoneEvent _taskDoneEvent = new TaskDoneEvent();
		private TaskWontDoEvent _taskWontDo = new TaskWontDoEvent();
		public string New()
		{
			return (_createdEvent.statusName);
		}

		public string Done()
		{
			return (_taskDoneEvent.statusName);
		}

		public string WontDo()
		{
			return (_taskWontDo.statusName);
		}
	}
}