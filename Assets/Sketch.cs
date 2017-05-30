using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using
using System.Globalization;

public class Sketch : MonoBehaviour
{
	public GameObject myPrefab;
	private string _WebsiteURL = "http://infomgmt192njad144.azurewebsites.net/tables/Assignment3?zumo-api-version=2.0.0";

	void Start()
	{
		string jsonResponse = Request.GET(_WebsiteURL);

		//Just in case something went wrong with the request we check the reponse and exit if there is no response.
		if (string.IsNullOrEmpty(jsonResponse))
		{
			return;
		}

		Assignment3[] lists = JsonReader.Deserialize<Assignment3[]>(jsonResponse);

		//----------------------
		//YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
		//int totalCubes = 30;
		int totalCubes = lists.Length;
		int i = 0;
		float totalDistance = 2.9f;

		//We can now loop through the array of objects and access each object individually
		foreach (Assignment3 card in lists)
		{
			float perc = i / (float)totalCubes / 3;
			float sin = Mathf.Sin(perc * Mathf.PI / 2);
			float x = 1.8f + sin * totalDistance;
			float y = Random.Range(3.0f, 7.0f);//5.0f;
			float z = 3.0f; //njad144 changed so easier to click smaller boxes
			//njad144 Parse date we get from cards
			System.DateTime dateAdded = System.DateTime.ParseExact(card.dateAdded.Remove(card.dateAdded.IndexOf("at") - 1), "MMM dd, yyyy", CultureInfo.InvariantCulture);
			var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
			CubeScript cubeScript = newCube.GetComponent<CubeScript>();
			TextMesh cubeText = newCube.GetComponentInChildren<TextMesh>();
			cubeScript.SetData(card);
			cubeScript.SetSize(.45f * (1.0f - perc));
			cubeScript.rotateSpeed = .2f + perc * 4.0f; // perc;// Random.value;
			//njad144 Set the text of each cube to card details. On click expands information.
			cubeText.text = dateAdded.ToString("dd/MM/yyyy") + "\n" + card.cardTitle.Substring(0, 10) + "...";

			//Depending on which list the card is from, we set the colour of the text accordingly. 
			switch (card.listName)
			{
				case "Ass3ToDo":
					cubeText.color = Color.red;
					break;
				case "Ass3Doing":
					cubeText.color = Color.yellow;
					break;
				case "Ass3Done":
					cubeText.color = Color.green;
					break;
				default:
					cubeText.color = Color.white;
					break;
			}

			i++;
		}
	}

	// Update is called once per frame
	void Update()
	{
	}
}
