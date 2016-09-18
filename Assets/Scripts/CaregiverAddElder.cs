using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CaregiverAddElder : MonoBehaviour {

	DataStorage ds;

	private string username;

	public InputField usernameIF;
	public Text usernameWarning;

	void Start () {
		ds = FindObjectOfType<DataStorage> ();
	}

	void Update () {
	
	}

	public void setUserame()
	{
		username = usernameIF.text;
	}


	public void addElder()
	{
		int index = 0;
		bool found = false;

		for (int i = 0; i < ds.elders.Count; i++) 
		{
			if (username == ds.elders[i].username) 
			{
				found = true;
				index = i;
			}
		}

		if (!found) {
			usernameWarning.text = "Este nome de utilizador não existe";
			return;
		}

		if (ds.currentUser is Caregiver) 
		{
			((Caregiver)ds.currentUser).elders.Add (ds.elders[index]);
		}
	}
}
