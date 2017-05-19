using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	[Header(" -- CONFIG -- ")]
	[Tooltip("Waypoints.")]
	[SerializeField]
	protected Transform[] _waypoints;

	protected int _iterator = -1;
	/// <summary>
	/// Return the next way point.
	/// </summary>
	/// <returns>The next waypoint transform.</returns>
	public virtual Transform GetNext()
	{
		_iterator++;
		if(_iterator == _waypoints.Length)
			_iterator = 0;

		return _waypoints [_iterator];
	}
}
