using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : MonoBehaviour {
	public GameObject myPrefab;

	void Start () {
		int totalCubes = 8;
		int totalDistance = 5;

		for (int i = 0; i < totalCubes; i++)
		{
			float perc = i / (float)totalCubes;
			float x = perc * totalDistance;
			float y = 5.0f;
			float z = 0.0f;
			var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
			newCube.GetComponent<CubeScript>().SetSize(1.0f - perc);
			newCube.GetComponent<CubeScript>().rotateSpeed = perc;// Random.value;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
