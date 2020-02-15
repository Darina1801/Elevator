using UnityEngine;

/// <summary>
/// First-person controller for a player
/// </summary>
public class FPSController : MonoBehaviour
{
	public float Speed = 30.0f;

	private float translationAxisZ;
	private float translationAxisX;

    // Update is called once per frame
    void Update()
    {
		translationAxisZ = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
		translationAxisX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
		transform.Translate(translationAxisX, 0, translationAxisZ);
	}
}
