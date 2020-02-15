using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
	[SerializeField]
	public List<GameObject> Floors = new List<GameObject>();
	[SerializeField]
	public List<GameObject> FloorsButtons = new List<GameObject>();
	
	public Material[] ButtonOnOffMaterial = new Material[2];

	public static Renderer BuildingRend;

	// Start is called before the first frame update
	void Start()
    {
		BuildingRend = FloorsButtons[0].gameObject.GetComponent<Renderer>();
		//foreach (var floorButton in floorsButtons)
		//{
		//	floorButton.GetComponent<Renderer>().material = buttonOnOffMaterial[1];
		//}
		//return;
	}

}
