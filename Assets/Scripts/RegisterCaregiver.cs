using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterCaregiver : MonoBehaviour {

	public InputField nomeIF;
	public InputField apelidoIF;
	public InputField contactoIF;
	public InputField moradaIF;
	public InputField emailIF;

	private string nome;
	private string apelido;
	private string contacto;
	private string morada;
	private string email;

	DataStorage dt;

	void Start()
	{
		dt = FindObjectOfType<DataStorage> ();
	}

	public void setName()
	{
		Debug.Log (nomeIF.text);
		nome = nomeIF.text;
	}

	public void setSurname()
	{
		Debug.Log (apelidoIF.text);
		apelido = apelidoIF.text;
	}

	public void setContact()
	{
		Debug.Log (contactoIF.text);
		contacto = contactoIF.text;
	}

	public void setAddress()
	{
		Debug.Log (moradaIF.text);
		morada = moradaIF.text;
	}

	public void setEmail()
	{
		Debug.Log (emailIF.text);
		email = emailIF.text;
	}

	public void loadMenuScene()
	{

		dt.currentUser.firstName = nome;
		dt.currentUser.lastName = apelido;
		dt.currentUser.address = morada;
		dt.currentUser.email = email;
		dt.currentUser.phoneNumber = contacto;
	
		dt.Save ();
		SceneManager.LoadScene ("MenuCaregiver");
	}

	public void back()
	{
		SceneManager.LoadScene ("LoginScene");
	}


}
