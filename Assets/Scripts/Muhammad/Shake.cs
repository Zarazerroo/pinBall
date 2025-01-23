using UnityEngine;

public class Shake : MonoBehaviour
{
	public Animator curtinsHolderAnimator;



	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			Debug.Log("Shake");

			curtinsHolderAnimator.SetTrigger("Shake");

		}
	}
}
