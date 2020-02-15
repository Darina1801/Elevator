using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A player
/// </summary>
public class Player : MonoBehaviour
{
	public List<GameObject> FloorsButtons = new List<GameObject>();
	public List<GameObject> ElevatorButtons = new List<GameObject>();

	public static Transform PlayerTransform;
	public static float PlayerRadius;
	public static Vector3 PlayerColliderBounds;
	public static RaycastHit Hit;

	private int leftMouseButton = 0; 
	private Ray mouseRay;
	private FPSController playerController;

	// Start is called before the first frame update
	void Start()
    {
		playerController = gameObject.AddComponent<FPSController>();
		PlayerTransform = gameObject.GetComponent<Transform>();
		PlayerRadius = gameObject.GetComponent<SphereCollider>().bounds.size.y / 2;
		PlayerColliderBounds = gameObject.GetComponent<SphereCollider>().bounds.size;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(leftMouseButton))
		{
			mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			OnCallElevator();
		}
	}

	/// <summary>
	/// Handles button clicks to call elevator or select the floor;
	/// </summary>
	public void OnCallElevator()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out Hit, 200))
		{
			if (Hit.transform.gameObject.tag == "FloorButton")
			{
				//Building.buildingRend = hit.transform.gameObject.GetComponent<Renderer>();
				Elevator.TargetFloor = FloorsButtons.IndexOf(Hit.transform.gameObject);
				Elevator.CallElevator = true;
			}
			else if (Hit.transform.gameObject.tag == "ElevatorButton")
			{
				//Elevator.elevatorRend = hit.transform.gameObject.GetComponent<Renderer>();
				Elevator.TargetFloor = ElevatorButtons.IndexOf(Hit.transform.gameObject);
				Elevator.ChooseFloor = true;
			}
		}
	}
}
