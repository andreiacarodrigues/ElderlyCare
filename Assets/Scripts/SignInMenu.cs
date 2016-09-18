using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignInMenu : MonoBehaviour {

	public DataStorage ds;

	public InputField usernameIF;
	public InputField passwordIF;
	public InputField confirmPasswordIF;

	public Text usernameWarning;
	public Text passwordWarning;

	public string username;
	public string password;
	int index;

	void Start () {
		ds = FindObjectOfType<DataStorage> ();
		usernameWarning.text = "";
		passwordWarning.text = "";
		index = 0;

	}

	void Update () {
	
	}

	public void setUsername()
	{
		username = usernameIF.text;

		if (ds.elder)
		{
			for (int i = 0; i < ds.elders.Count; i++) 
			{
				if(username == ds.elders[i].username)
				{
					usernameWarning.text = "Este nome de utilizador já está a ser utilizado. Por favor selecione um novo.";
					index = i;
					return;
				}
			}
		}
		else
		{
			for (int i = 0; i < ds.caregivers.Count; i++) 
			{
				if(username == ds.caregivers[i].username)
				{
					usernameWarning.text = "Este nome de utilizador já está a ser utilizado. Por favor selecione um novo.";
					index = i;
					return;
				}
			}
		}


		usernameWarning.text = "";
	}

	public void setPassword()
	{
		password = passwordIF.text;
	}

	public void setSecondPassword()
	{
		if (confirmPasswordIF.text != password)
			passwordWarning.text = "As duas senhas não correspondem. Por favor corrija-as.";
		else
			passwordWarning.text = "";
	}

	public void submitInfo()
	{
		if (ds.elder)
		{
			Elder e = new Elder (username, password);
			ds.elders.Add (e);
			ds.currentUser = e;
		}
		else
		{
			Caregiver c = new Caregiver (username, password);
			ds.caregivers.Add (c);
			ds.currentUser = c;
		}
			
		ds.Save ();

		if(ds.elder)
			SceneManager.LoadScene ("RegistrationElder");
		else
			SceneManager.LoadScene ("RegistrationCaregiver");
	}

	public void back()
	{
		SceneManager.LoadScene ("LoginScene");
	}

}
