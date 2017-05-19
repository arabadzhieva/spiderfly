using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Bullet : MonoBehaviour
{
	private Rigidbody2D _rig;
	//private float _thrust = 10f;

	private void Awake()
	{
		_rig = GetComponent<Rigidbody2D>();

		BulletButton.OnButtonReleased -= HandleOnButtonReleased;
		BulletButton.OnButtonReleased += HandleOnButtonReleased;
	}

	private void OnDestroy()
	{
		BulletButton.OnButtonReleased -= HandleOnButtonReleased;
	}

	private void HandleOnButtonReleased(Event_BulletButtonEventArgs args)
	{
		Debug.LogError("Distance vector = " + args.distanceVector);
		Debug.LogError("Magnitute = " + args.magnitude);
		_rig.isKinematic = false;
		_rig.gravityScale = 0.05f;
		_rig.AddForce(args.distanceVector, ForceMode2D.Impulse);
	}
}
