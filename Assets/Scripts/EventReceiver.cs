using UnityEngine;
using System.Collections;

public class EventReceiver : MonoBehaviour
{
	[SerializeField]
	protected ExampleEvent _eventClass;

	protected virtual void Awake()
	{
		_eventClass.MyEvent -= HandleMyEvent;
		_eventClass.MyEvent += HandleMyEvent;
	}

	protected virtual void OnDestroy()
	{
		_eventClass.MyEvent -= HandleMyEvent;
	}

	protected virtual void HandleMyEvent(object sender, Event_MyCustomEventArgs arg)
	{
		Debug.LogError(arg.MyMessage);

		if(arg.IsOneTimeEvent)
			_eventClass.MyEvent -= HandleMyEvent;
	}
}

	
