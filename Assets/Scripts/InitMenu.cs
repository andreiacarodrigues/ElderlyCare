using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitMenu : MonoBehaviour {

	public Button elder;
	public Button caregiver;

	public DataStorage dt;

	void Start()
	{
		dt = FindObjectOfType<DataStorage> ();
	}

	void Update()
	{
		if (dt.elder) 
		{
			elder.interactable = false;
			caregiver.interactable = true;
		}
		else
		{
			elder.interactable = true;
			caregiver.interactable = false;
		}
	}

	public void ChangedOnSituation()
	{
		dt.elder = !dt.elder;
	}

	public void LoadLoginScene()
	{
		SceneManager.LoadScene ("LogIn");
	}

	public void LoadSigninScene()
	{
		SceneManager.LoadScene ("SignIn");
	}
}
