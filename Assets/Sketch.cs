using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    public GameObject myPrefab;
    public string _WebsiteURL = "http://infomgmt192njad144.azurewebsites.net/tables/Product?zumo-api-version=2.0.0";

    void Start () {
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);

		//----------------------
		//YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL
		//int totalCubes = 30;
		int totalCubes = products.Length;
		int i = 0;
		float totalDistance = 2.9f;

		//We can now loop through the array of objects and access each object individually
		foreach (Product product in products)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + product.ProductID);
			//----------------------
			//YOUR CODE TO INSTANTIATE NEW PREFABS GOES HERE
			float perc = i / (float)totalCubes;
			float sin = Mathf.Sin(perc * Mathf.PI / 2);
			float x = 1.8f + sin * totalDistance;
			float y = 5.0f;
			float z = 0.0f;
			var newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);

			newCube.GetComponent<CubeScript>().SetSize(.45f * (1.0f - perc));
			newCube.GetComponent<CubeScript>().rotateSpeed = .2f + perc * 4.0f; // perc;// Random.value;
			newCube.GetComponentInChildren<TextMesh>().text = product.ProductID;
			i++;

			//----------------------
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
