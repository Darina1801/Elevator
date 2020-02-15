using UnityEngine;

/// <summary>
/// A photocell
/// </summary>
public class Photosell : MonoBehaviour
{
	public static bool PlayerIsObstacle;

	public void OnTriggerEnter(Collider colliderEnter)
	{
		PlayerIsObstacle = (colliderEnter.tag == "Player");
	}

	private void OnTriggerExit(Collider colliderExit)
	{
		PlayerIsObstacle = !(colliderExit.tag == "Player");
	}
}
