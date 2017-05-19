using UnityEngine;
using System.Collections;

public class PlayBtn : MonoBehaviour 

{
//	public void LoadScene(int level)
//	{
//		Application.LoadLevel(level);
//	}	

		[Header(" -- CONFIG -- ")]
		[Tooltip("Play.")]
		[SerializeField]
		protected GameObject _play;

		/// <summary>
		/// Unity call on mouse released.
		/// </summary>
		protected virtual void OnMouseUp()
		{
			_play.SetActive(!_play.activeSelf);
//			LoadScene();
		}

}