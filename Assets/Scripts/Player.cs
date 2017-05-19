using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	[Header(" -- CONFIG -- ")]
	[Tooltip("Waypoints.")]
	[SerializeField]
	protected Waypoints _waypoints;

	[Space(15)]

	[Tooltip("Movement speed . [Default = 4f]")]
	[Range(0.1f, 10f)]
	[SerializeField]
	protected float _movementTime = 4f;

	protected bool _isMoving = false;
	/// <summary>
	///Unity call on Awake
	/// </summary>
	protected virtual void Awake()
	{
		transform.position = _waypoints.GetNext().position;
	}

	/// <summary>
	/// Unity call every frame.
	/// </summary>
	protected virtual void Update()
	{
		if (!_isMoving && Input.GetKeyDown (KeyCode.M))
			Move();
	}

	/// <summary>
	/// Moves the player.
	/// </summary>
	protected virtual void Move()
	{
		Vector3 nextPos = _waypoints.GetNext().position;
		StartCoroutine(DoMovement(transform.position,nextPos, _movementTime));
	}

	/// <summary>
	/// Dos the movement.
	/// </summary>
	/// <returns>The movement.</returns>
	/// <param name="starPos">Star position.</param>
	/// <param name="endPos">End position.</param>
	/// <param name="time">Time.</param>
	protected virtual IEnumerator DoMovement(Vector3 starPos, Vector3 endPos, float time)
	{
		_isMoving = true;
		float _elapsedTime = 0f;
		do {
			transform.position = Vector3.Lerp(starPos, endPos, _elapsedTime / time);
			_elapsedTime += Time.deltaTime;
			yield return null;
		} while (_elapsedTime < time);

		transform.position = endPos;
		_isMoving = false;
		}
	}


