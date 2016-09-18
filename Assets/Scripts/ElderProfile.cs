using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElderProfile : MonoBehaviour {

	public Text nomeTxt;
	public Text contactoTxt;
	public Text moradaTxt;
	public Text emailTxt;
	public Text typeBloodTxt;

	DataStorage ds;

	void Start()
	{
		ds = FindObjectOfType<DataStorage> ();
		nomeTxt.text = "Nome: " + ds.currentUser.firstName + " " + ds.currentUser.lastName + "";
		contactoTxt.text = "Contacto: " +ds.currentUser.phoneNumber + "";
		moradaTxt.text = "Morada: "+ ds.currentUser.address + "";
		emailTxt.text = "Email: "+ ds.currentUser.email + "";
		if (ds.currentUser is Elder) {
			typeBloodTxt.text = "Tipo de Sangue: "+((Elder)ds.currentUser).bloodType + "";
		}
	}

	public void back()
	{
		if(ds.elder)
			SceneManager.LoadScene ("MenuElder");
		else
			SceneManager.LoadScene ("MenuCaregiver");
	}
}
