using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class CalendarGUI : MonoBehaviour {


	public Button[] DayButtons;
	public string[] Months;
	public Text HeaderLabel;

	private int currentMonth;
	private int currentYear;
	private int currentDay;

	void Start()
	{
		currentMonth = DateTime.Now.Month;
		currentYear = DateTime.Now.Year;
		currentDay = DateTime.Now.Day;
	
		fillTables ();
		createCalendar ();
	}
		
	public void moveForward()
	{
		if (currentMonth == 12) {
			currentYear++;
			currentMonth = 1;
		} else
			currentMonth++;

		createCalendar ();
	}

	public void moveBackward()
	{
		if (currentMonth == 1) {
			currentYear--;
			currentMonth = 12;
		} else
			currentMonth--;

		createCalendar ();
	}

	void fillTables()
	{
		Months [0] = "Janeiro";
		Months [1] = "Fevereiro";
		Months [2] = "Março";
		Months [3] = "Abril";
		Months [4] = "Maio";
		Months [5] = "Junho";
		Months [6] = "Julho";
		Months [7] = "Agosto";
		Months [8] = "Setembro";
		Months [9] = "Outubro";
		Months [10] = "Novembro";
		Months [11] = "Dezembro";
	}

	void clearCalendar()
	{
		for (int i = 0; i < DayButtons.Length; i++) {
			DayButtons [i].interactable = false;
			DayButtons[i].GetComponentInChildren<Text>().text = " ";
		}
	}
	void createCalendar()
	{
		clearCalendar ();
	
		int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);

		// Gets the first day of the month -> day of week
		DateTime d = new DateTime (currentYear, currentMonth, 1);
		int dayOfWeek = (int)d.DayOfWeek; // retorna nº entre 0 e 6

		HeaderLabel.text = Months [currentMonth - 1] + " " + currentYear;
		int j = 1;
	
		for (int i = dayOfWeek; i < dayOfWeek + daysInMonth; i++) {
			DayButtons [i].interactable = true;
			DayButtons[i].GetComponentInChildren<Text>().text = j + "";
			j++;
		}
	}

	public void onClickDay(int index)
	{
		int day = Int32.Parse(DayButtons [index].GetComponentInChildren<Text> ().text);
		int month = currentMonth;

		Debug.Log (day + " " + currentMonth + " " + currentYear);

	}
}