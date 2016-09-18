using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterElder : MonoBehaviour {

	public InputField nomeIF;
	public InputField apelidoIF;
	public InputField contactoIF;
	public InputField moradaIF;
	public InputField emailIF;
	public Dropdown typeBloodIF;

	private string nome;
	private string apelido;
	private string contacto;
	private string morada;
	private string email;
	private string typeBlood = "A+";

	DataStorage dt;

	void Start()
	{
		dt = FindObjectOfType<DataStorage> ();
	}

	public void setName()
	{
		nome = nomeIF.text;
	}

	public void setSurname()
	{
		apelido = apelidoIF.text;
	}

	public void setContact()
	{
		contacto = contactoIF.text;
	}

	public void setAddress()
	{
		morada = moradaIF.text;
	}

	public void setEmail()
	{
		email = emailIF.text;
	}

	public void setTypeBlood()
	{
		typeBlood = typeBloodIF.captionText.text;
	}

	public void loadDoctorsScene()
	{

		dt.currentUser.firstName = nome;
		dt.currentUser.lastName = apelido;
		dt.currentUser.address = morada;
		dt.currentUser.email = email;
		dt.currentUser.phoneNumber = contacto;

		if (dt.currentUser is Elder) {
			((Elder) dt.currentUser).bloodType = typeBlood;
		}
		// aqui temos de saber qual é o user 

		// e guardar todas as informações
		dt.Save ();
		SceneManager.LoadScene ("RegistrationElderDoctors");
	}

	public void back()
	{
		SceneManager.LoadScene ("LoginScene");
	}
}
