using System;

namespace Events
{
	public record TaskWontDoEvent() : Event("WontDo");
}