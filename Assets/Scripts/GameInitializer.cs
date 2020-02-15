using UnityEngine;

/// <summary>
/// A game initializer
/// </summary>
public class GameInitializer : MonoBehaviour
{
	[SerializeField]
	private GameObject prefabBuilding;
	[SerializeField]
	private GameObject prefabPlayer;
	[SerializeField]
	private GameObject prefabElevator;
	[SerializeField]
	public Material[] ButtonOnOffMaterial = new Material[2];

	private GameObject buildingGameObject;
	private GameObject playerGameObject;
	private GameObject elevatorGameObject;
	private Vector3 buildingLocation;
	private Vector3 playerInitLocation;
	private Vector3 elevatorInitLocation;

    // Start is called before the first frame update
    void Start()
    {
		RandomNumberGenerator.Initialize();
		
		buildingLocation = new Vector3(0, 0, 0);
		buildingGameObject = Instantiate(prefabBuilding, buildingLocation, Quaternion.identity);
		Building building = buildingGameObject.GetComponent<Building>();

		playerInitLocation = new Vector3(0, RandomNumberGenerator.Next(6) * 100, 0);
		playerGameObject = Instantiate(prefabPlayer, playerInitLocation, Quaternion.identity);
		Player player = playerGameObject.GetComponent<Player>();

		elevatorInitLocation = new Vector3(0, RandomNumberGenerator.Next(6) * 100, 125);
		elevatorGameObject = Instantiate(prefabElevator, elevatorInitLocation, Quaternion.identity);
		Elevator elevator = elevatorGameObject.GetComponent<Elevator>();
		
		building.ButtonOnOffMaterial = ButtonOnOffMaterial;
		player.FloorsButtons = building.FloorsButtons;
		player.ElevatorButtons = elevator.ElevatorButtons;
		elevator.Floors = building.Floors;
		elevator.FloorsButtons = building.FloorsButtons;
		elevator.ButtonOnOffMaterial = ButtonOnOffMaterial;
		Elevator.CurrentFloor = (int)elevatorInitLocation.y / 100;
	}
}
