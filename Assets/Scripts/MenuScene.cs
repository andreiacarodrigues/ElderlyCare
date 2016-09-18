using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

	public void goToProfile()
	{
		SceneManager.LoadScene ("Profile");
	}

	public void addElder()
	{
		SceneManager.LoadScene ("CaregiverAddElder");
	}

	public void goToCalendar()
	{
		SceneManager.LoadScene ("Calendar");
	}

	public void goToContacts()
	{
		SceneManager.LoadScene ("Contacts");
	}

}
