using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class BulletButton : MonoBehaviour
{
	public static event BulletButtonEvent<Event_BulletButtonEventArgs> OnButtonReleased;
	protected Vector3 pressPoint = Vector3.zero;
	protected Vector3 distance = Vector3.zero;

	protected virtual void OnMouseDown()
	{
		pressPoint = GetPoint();
	}

	protected virtual void OnMouseUp()
	{
		distance = transform.position - GetPoint();
		distance = new Vector3(distance.x, distance.y, transform.position.z);

		if(OnButtonReleased != null)
			OnButtonReleased(new Event_BulletButtonEventArgs(distance));
	}

	#if UNITY_EDITOR
	private void Update()
	{
		Debug.DrawLine(transform.position, distance);
	}
	#endif

	protected virtual Vector3 GetPoint()
	{
		Vector3 point = Vector3.zero;

		#if UNITY_EDITOR
		point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		#else
		if(Input.touchCount > 0)	
		point = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		else
		Debug.LogError("Unable to detect touch!");
		#endif

		return point;
	}
}

public delegate void BulletButtonEvent<T>(T param) where T : Event_BulletButtonEventArgs;
public class Event_BulletButtonEventArgs
{
	public Vector3 distanceVector { get; protected set; }
	public float magnitude { get { return distanceVector.magnitude;} }

	public Event_BulletButtonEventArgs(Vector3 dist)
	{
		distanceVector = dist;

	}
}
