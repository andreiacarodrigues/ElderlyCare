using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterElderDoctor : MonoBehaviour {

	public GameObject doctorInfo;

	public InputField nomeIF;
	public InputField apelidoIF;
	public InputField contactoIF;
	public InputField moradaIF;
	public InputField emailIF;
	public InputField especialidadeIF;

	private string nome;
	private string apelido;
	private string contacto;
	private string morada;
	private string email;
	private string especialidade;


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
		apelido = apelidoIF.text;
	}

	public void setEmail()
	{
		email = emailIF.text;
	}

	public void setSpeciality()
	{
		email = emailIF.text;
	}

	public void loadMenuScene()
	{
		dt.Save ();
		SceneManager.LoadScene ("MenuElder");
	}

	public void back()
	{
		SceneManager.LoadScene ("LoginScene");
	}

	public void insertNewDoctor()
	{
		doctorInfo.SetActive(true);
	}

	public void submitDoctor()
	{
		Doctor d = new Doctor ();

		d.firstName = nome;
		d.lastName = apelido;
		d.address = morada;
		d.email = email;
		d.speciality = especialidade;

		if (dt.currentUser is Elder) {
			((Elder)dt.currentUser).doctors.Add (d);
		}
		doctorInfo.SetActive (false);
	}
}
