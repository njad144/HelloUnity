using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeScript : MonoBehaviour {
	public float rotateSpeed = 1.0f;
	public Vector3 spinSpeed = Vector3.zero;
	Vector3 spinAxis = new Vector3(0, 1, 0);
	/* njad144 */
	Quaternion initRotation;
	public Assignment3 cubesData;
	/* njad144 */

	// Use this for initialization
	//Runs once at startup
	void Start () {
		spinSpeed = new Vector3(Random.value, Random.value, Random.value);
		spinAxis = Vector3.up;
		spinAxis.x = (Random.value - Random.value) * .1f;
		/* njad144 */
		//Get initial rotation for text so we can constantly keep it at a readable level, and not follow cube rotation.
		initRotation = GetComponentInChildren<TextMesh>().transform.rotation;
		/* njad144 */
	}

	/* njad144 So that every cube can be associated with its own card data. Called from Sketch after instantiation. */
	public void SetData(Assignment3 data)
	{
		this.cubesData = data;
	}
	/* njad144 */

	public void SetSize(float size)
	{
		this.transform.localScale = new Vector3(size, size, size);
	}

	/* njad144 Clicking any cube will expand information in the panel. */
	public void OnMouseDown()
	{
		string message;

		if (string.IsNullOrEmpty(cubesData.cardDescription))
		{
			message = "Card Title: " + cubesData.cardTitle + "\nDate Added: " + cubesData.dateAdded + "\nCreated By: " + cubesData.creatorUsername + "\nDescription: " + "No description!";
		}
		else
		{
			message = "Card Title: " + cubesData.cardTitle + "\nDate Added: " + cubesData.dateAdded + "\nCreated By: " + cubesData.creatorUsername + "\nDescription: " + cubesData.cardDescription;
		}

		FindObjectOfType<TextScript>().setCanvasText(message);
	}
	/* njad144 */

	// Update is called once per frame
	//Animation loop
	void Update () {
		this.transform.Rotate(spinSpeed);
		this.transform.RotateAround(Vector3.zero, spinAxis, rotateSpeed);
		//njad144 using initial rotation for text so we can constantly keep it at a readable level, and not follow cube rotation.
		GetComponentInChildren<TextMesh>().transform.rotation = initRotation;
	}
}
