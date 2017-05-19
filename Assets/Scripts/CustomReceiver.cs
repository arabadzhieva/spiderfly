using UnityEngine;
using System.Collections;

public class CustomReceiver : MonoBehaviour, IResponder
{
	[SerializeField]
	protected CustomEventStylePattern _sender;

	protected virtual void Awake()
	{
		_sender.SubscribeToEvent(this as IResponder);
	}

	public void OnCall(string message)
	{
		Debug.LogError(message);
	}
}
