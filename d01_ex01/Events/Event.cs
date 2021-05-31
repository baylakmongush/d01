using System;
using System.Collections.Generic;
using Tasks;

namespace Events
{
	abstract public record Event(string statusName);

	public class EventProcessor
    {
		public struct Tasks
		{
			public string	title;
			public string	summary;
			public DateTime?	dueDate;
			public TasksType.Type? taskType;
			public TaskPriority.Priority? taskPriority;
			
		}
        private List<Tasks> _eventLogger = new List<Tasks>();

        public void ProcessEvent(Tasks e)
        {
            _eventLogger.Add(e);
        }

        public void PrintEventLogEntries()
        {
            // foreach (Tasks task in _eventLogger)
			// {
				
			// }
        }

        public List<Tasks> GetEvents()
        {
            return _eventLogger as List<Tasks>;
        }
    }
}