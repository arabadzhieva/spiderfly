using UnityEngine;
using System.Collections;

public class CustomEventStylePattern : MonoBehaviour
{
	System.Collections.Generic.List<IResponder> myCallerList = new System.Collections.Generic.List<IResponder>();

	public virtual void SubscribeToEvent(IResponder call)
	{
		if(!myCallerList.Contains(call))
			myCallerList.Add(call);
	}

	public virtual void UnsubscribeFromEvent(IResponder call)
	{
		if(myCallerList.Contains(call))
			myCallerList.Remove(call);
	}

	protected virtual void Dispatch(string message)
	{
		for(int i = 0; i < myCallerList.Count; i++)
			myCallerList[i].OnCall(message);
	}

	protected virtual void Update()
	{
		if(Input.GetKeyDown(KeyCode.S))
			Dispatch("Dispatched with button press S");
	}
}

public interface IResponder
{
	void OnCall(string message);
}
