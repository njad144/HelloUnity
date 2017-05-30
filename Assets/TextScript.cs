using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}

	//njad144 Lets CubeScript set the canvas text.
	public void setCanvasText(string message)
	{
		GetComponentInChildren<Text>().text = message;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
