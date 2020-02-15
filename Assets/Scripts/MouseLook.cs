using UnityEngine;

/// <summary>
/// A mouse look for a player
/// </summary>
public class MouseLook : MonoBehaviour
{
	[SerializeField]
	private float sensitivity = 5.0f;
	[SerializeField]
	private float smoothing = 2.0f;

	private GameObject player;
	private Vector2 mouseLook;
	private Vector2 smoothMouseMoving;

	// Start is called before the first frame update
	void Start()
    {
		player = this.transform.parent.gameObject;
	}

    // Update is called once per frame
    void Update()
    {
		Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		
		// the interpolated float result between the two float values
		smoothMouseMoving.x = Mathf.Lerp(smoothMouseMoving.x, mouseDelta.x, 1f / smoothing);
		smoothMouseMoving.y = Mathf.Lerp(smoothMouseMoving.y, mouseDelta.y, 1f / smoothing);
		
		// incrementally add to the camera look
		mouseLook += smoothMouseMoving;

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
	}
}
