using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class ButtonClick : MonoBehaviour 
{
	[Header(" -- CONFIG -- ")]
	[Tooltip("Tick ref.")]
	[SerializeField]
	protected GameObject _tick;


	protected virtual void OnMouseDown()
	{
		
	}

	/// <summary>
	/// Unity call on mouse released.
	/// </summary>
	protected virtual void OnMouseUp()
	{
		_tick.SetActive(!_tick.activeSelf);

	}

}

//	public class EventManager : MonoBehaviour 
//	{
//		public delegate void ClickAction();
//		public static event ClickAction OnClicked;
//
//
//		void OnGUI()
//		{
//			if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
//			{
//				if(OnClicked != null)
//					OnClicked();
//			}
//		}
//	}
//
//}