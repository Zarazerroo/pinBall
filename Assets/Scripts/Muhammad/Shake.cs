using UnityEngine;

public class Shake : MonoBehaviour
{

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			Debug.Log("Shake");
			// you can put the animation trigger here.
		}
	}
}
