using UnityEngine;
using System.Collections;
using System;

public class ExampleEvent : MonoBehaviour
{
	public EventHandler<Event_MyCustomEventArgs> MyEvent;

	protected virtual void Update()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			if(MyEvent != null)
				MyEvent(this, new Event_MyCustomEventArgs("Used by pressing button S", false));
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			if(MyEvent != null)
				MyEvent(this, new Event_MyCustomEventArgs("Used by pressing button A", true));
		}
	}
}

public class Event_MyCustomEventArgs : System.EventArgs
{
	public bool IsOneTimeEvent { get; protected set; }
	public string MyMessage { get; protected set; }

	public Event_MyCustomEventArgs(string message, bool oneTime)
	{
		MyMessage = message;
		IsOneTimeEvent = oneTime;
	}
}