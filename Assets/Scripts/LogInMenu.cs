using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogInMenu : MonoBehaviour {

	public DataStorage ds;

	public InputField usernameIF;
	public InputField passwordIF;

	public Text warning;

	public string username;
	public string password;

	void Start () {
		ds = FindObjectOfType<DataStorage> ();
		warning.text = "";
	}

	void Update () {
	
	}

	public void setUsername()
	{
		username = usernameIF.text;
	}

	public void setPassword()
	{
		password = passwordIF.text;
	}

	public void submitInfo()
	{
		bool found = false;
		int index = 0;

		if (ds.elder)
		{
			for (int i = 0; i < ds.elders.Count; i++)
			{
				Debug.Log ("Inserido: " + username);
				Debug.Log ("Testando " + ds.elders [i].username);

				if (ds.elders [i].username == username)
				{
					found = true;
					index = i;
				}
			}
		}
		else
		{
			for (int i = 0; i < ds.caregivers.Count; i++)
			{
				Debug.Log ("Inserido: " + username);
				Debug.Log ("Testando " + ds.caregivers [i].username);

				if (ds.caregivers [i].username == username)
				{
					found = true;
					index = i;
				}
			}
		}

		if (!found)
		{
			warning.text = "O nome de utilizador inserido não existe.";
			return;
		}
	
		if (ds.elder)
		{
			if (ds.elders [index].password != password)
			{
				warning.text = "A senha existente não corresponde á correta.";
				return;
			}
		}
		else
		{
			if (ds.caregivers [index].password != password)
			{
				warning.text = "A senha existente não corresponde á correta.";
				return;
			}
		}
			
		if (ds.elder)
		{
			ds.currentUser = ds.elders [index];
		}
		else
		{
			ds.currentUser = ds.caregivers[index];
		}
			
		ds.Save ();

		if(ds.elder)
			SceneManager.LoadScene ("MenuElder");
		else
			SceneManager.LoadScene ("MenuCaregiver");
	}

	public void back()
	{
		SceneManager.LoadScene ("LoginScene");
	}

}
