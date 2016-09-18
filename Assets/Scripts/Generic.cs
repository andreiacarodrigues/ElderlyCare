using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Generic : MonoBehaviour {

	DataStorage ds;

	void Start()
	{
		ds = FindObjectOfType <DataStorage> ();
	}

	public void back()
	{
		if(ds.elder)
			SceneManager.LoadScene ("MenuElder");
		else
			SceneManager.LoadScene ("MenuCaregiver");
	}

}
