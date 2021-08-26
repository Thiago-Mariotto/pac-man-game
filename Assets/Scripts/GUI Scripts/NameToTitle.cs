using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameToTitle : MonoBehaviour {

	public Text title;


	void OnMouseEnter()
	{
		switch(name)
		{
		case "Rocket":
			title.color = new Color(124f/255f, 255f/255f, 202f/255f);
			break;

		case "Internal Error":
			title.color = Color.red;
			break;

		case "Not Found":
			title.color = new Color(254f/255f, 152f/255f, 203f/255f);
			break;

		case "Unauthorized":
			title.color = Color.cyan;
			break;

		case "System Down":
			title.color = new Color(254f/255f, 203f/255f, 51f/255f);
			break;
		}
		
		title.text = name;
	}

	void OnMouseExit()
	{
		title.text = "";
		title.color = Color.white;
	}
}
