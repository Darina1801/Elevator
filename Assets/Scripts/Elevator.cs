using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An elevator
/// </summary>
public class Elevator : MonoBehaviour
{
	[SerializeField]
	public List<GameObject> ElevatorButtons = new List<GameObject>();

	public Animator Animator;
	public Material[] ButtonOnOffMaterial = new Material[2];
	public List<GameObject> Floors = new List<GameObject>();
	public List<GameObject> FloorsButtons = new List<GameObject>();
	public List<AudioSource> AudioSources = new List<AudioSource>();
	public Timer ElevatorTimer;
	public bool DoorsAreClosed = false;

	public static int CurrentFloor;
	public static int TargetFloor;
	public static bool CallElevator;
	public static bool ChooseFloor;
	public static Renderer ElevatorRend;
	public static bool ElevatorIsMovingSound = false;
	public static bool ElevatorCame = false;

	private Transform elevatorTransform;
	private float speed = 30f;
	private float timerDuration = 5f;

	// Start is called before the first frame update
	void Start()
	{
		elevatorTransform = gameObject.transform;

		ElevatorTimer = gameObject.AddComponent<Timer>();
		ElevatorTimer.Duration = timerDuration;

		Animator = gameObject.GetComponentInChildren<Animator>();

		//elevatorRend = elevatorButtons[0].gameObject.GetComponent<Renderer>();
		//foreach (var elevatorButton in elevatorButtons)
		//{
			//elevatorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
		//}
	}

    // Update is called once per frame
    void Update()
    {
		if (CallElevator)
		{
			//Building.buildingRend.material = buttonOnOffMaterial[1];
			MoveElevator();
		}
		else if (!CallElevator)
		{
			//Building.buildingRend.material = buttonOnOffMaterial[0];
		}

		if (ChooseFloor)
		{
			//elevatorRend.material = buttonOnOffMaterial[1];
			MoveElevator();
		}
		else if (!ChooseFloor)
		{
			//elevatorRend.material = buttonOnOffMaterial[0];
		}

		AnimationAndSoundHandler();
    }

	private void MoveElevator()
	{
		if (DoorsAreClosed)
		{
			if (!ElevatorIsMovingSound)
			{
				AudioSources[3].Play();
				ElevatorIsMovingSound = true;
			}

			if (TargetFloor == CurrentFloor)
			{
				OnElevatorCame();
				//foreach (var elevatorButton in elevatorButtons)
				//{
					//elevatorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
				//}
				//foreach (var floorButton in floorsButtons)
				//{
					//floorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
				//}
				return;
			}

			Vector3 targetPosition = Floors[TargetFloor].transform.position;
			Vector3 currentPosition = Floors[CurrentFloor].transform.position;

			Vector3 elevatorMovementDirection = targetPosition - currentPosition;
			if (elevatorMovementDirection.y > 0)
			{
				elevatorMovementDirection = Vector3.up;
			}
			else elevatorMovementDirection = Vector3.down;

			elevatorTransform.Translate(elevatorMovementDirection * speed * Time.deltaTime);
			if (elevatorTransform.position.z - 20 <= Player.PlayerTransform.position.z)
			{
				Player.PlayerTransform.position = new Vector3(
						Player.PlayerTransform.position.x, elevatorTransform.position.y + Player.PlayerRadius, Player.PlayerTransform.position.z);
			}

			if (elevatorMovementDirection == Vector3.up)
			{
				if (elevatorTransform.position.y >= targetPosition.y)
				{
					OnElevatorCame();
					//foreach (var elevatorButton in elevatorButtons)
					//{
						//elevatorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
					//}
					//foreach (var floorButton in floorsButtons)
					//{
						//floorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
					//}
					return;
				}
			}
			else if (elevatorMovementDirection == Vector3.down)
			{
				if (elevatorTransform.position.y <= targetPosition.y)
				{
					OnElevatorCame();
					//foreach (var elevatorButton in elevatorButtons)
					//{
						//elevatorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
					//}
					//foreach (var floorButton in floorsButtons)
					//{
						//floorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
					//}
					return;
				}
			}
		}
	}

	private void OnElevatorCame()
	{
		CurrentFloor = TargetFloor;
		ElevatorIsMovingSound = false;
		AudioSources[3].Stop();
		ElevatorCame = true;
		CallElevator = false;
		ChooseFloor = false;
	}

	public void AnimationAndSoundHandler()
	{
		if (ElevatorCame)
		{
			AudioSources[2].Play();
			Animator.Play("DoorOpenAnimation");
			AudioSources[0].Play();
			ElevatorTimer.Run();
			ElevatorCame = false;
			DoorsAreClosed = false;
		}
		else if (!ElevatorTimer.Running)
		{
			if (Photosell.PlayerIsObstacle)
			{
				Animator.Play("DoorTryCloseAnimation");
				AudioSources[4].Play();
				ElevatorTimer.Restart();
			}
			else
			{
				if (!DoorsAreClosed)
				{
					Animator.Play("DoorCloseAnimation");
					AudioSources[1].Play();
					if (!IsAnimationPlaying("DoorCloseAnimation"))
					{
						DoorsAreClosed = true;
					}
				}
			}
		}
	}

	public bool IsAnimationPlaying(string animationName)
	{
		var animatorStateInfo = Animator.GetCurrentAnimatorStateInfo(0);
		if (animatorStateInfo.IsName(animationName))
		{
			return true;
		} 
		else return false;
	}
}
