using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;

public class DataStorage : MonoBehaviour
{
	static GameObject go = null;
	public bool elder;
	public List<Elder> elders;
	public List<Caregiver> caregivers;
	public User currentUser;

	void Start ()
	{
		if (go == null)
			go = gameObject;
		else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		if (!Load ())
			initInfo ();

		currentUser = null;
	}

	private void initInfo()
	{
		elder = true;
		elders = new List<Elder> ();
		caregivers = new List<Caregiver> ();
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/appInfo.dat", FileMode.OpenOrCreate);

		AppData gd = new AppData (elder, elders, caregivers);

		bf.Serialize (file, gd);
		file.Close ();

	}

	public bool Load()
	{
		if (File.Exists (Application.persistentDataPath + "/appInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/appInfo.dat", FileMode.Open);
		
			AppData ad = (AppData)bf.Deserialize (file);
			elder = ad.elder;
			elders = ad.elders;
			caregivers = ad.caregivers;

			file.Close ();
			return true;
		}

		return false;
	}
		
}

[Serializable]
public class AppData
{
	public bool elder;
	public List<Elder> elders;
	public List<Caregiver> caregivers;

	public AppData(bool e, List<Elder> es, List<Caregiver> cs)
	{
		elder = e;
		elders = es;
		caregivers = cs;
	}
}

[Serializable]
public class User
{
	//Login data
	public string username;
	public string password;

	//Generic personnal info
	public string firstName;
	public string lastName;
	public string phoneNumber;
	public string email;
	public string address;

	public User(string username, string password){
		this.username = username;
		this.password = password;
	}
}

[Serializable] 
public class Elder : User
{
	public string bloodType;
	public List<Doctor> doctors;

	public Elder(string username, string password): base(username, password){
	}
}

[Serializable] 
public class Caregiver : User
{

	public List<Elder> elders;

	public Caregiver(string username, string password): base(username, password){
	}
}

[Serializable]
public class Doctor
{
	public string firstName;
	public string lastName;
	public string phoneNumber;
	public string email;
	public string address;
	public string speciality;

	public Doctor()
	{
	}
}