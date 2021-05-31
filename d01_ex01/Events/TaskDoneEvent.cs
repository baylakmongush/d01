using System;

namespace Events
{
	public record TaskDoneEvent() : Event("Done");
}