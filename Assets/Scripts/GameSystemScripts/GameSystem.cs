using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameSystem : MonoBehaviour
{
	public static GameSystem	game;

	public List<Character> order = new List<Character>();

	public Character	character;
	public Character	clicked;

	public int			actionPoints;

	public bool			bSpawning;
	public bool			bInFight;
	public bool			bVictory;

	public Team[]		teams;
	//public AObjectif[]	objectives_zero;
	//public AObjectif[]	objectives_one;

	// Use this for initialization
	void Awake()
	{
		game = this;
		DontDestroyOnLoad(this.gameObject);
	}

	void Start ()
	{
		bSpawning = true;
		bInFight = false;

		foreach (Team t in teams)
		{
			foreach (GameObject c in t.characters)
			{
				order.Add(c.GetComponent<Character>());
				c.GetComponent<Character>().Init();
			}
		}
		UI_Manager.UIManager.UI_Open("UI_Battle_Spawn");
		UI_Manager.UIManager.UI_Open("UI_Battle_SpawnInfo");
	}
	
	public void StartGame()
	{
		UI_Manager.UIManager.UI_Close("UI_Battle_Spawn");
		UI_Manager.UIManager.UI_Close("UI_Battle_Start");
		UI_Battle_Notification.notification.Clear();
		bSpawning = false;
		bVictory = false;
		bInFight = true;

		SortUnitByInitiative();
		if (!order[0].gameObject.activeSelf)
			NextCharacter();
		else
			character = order[0];
		if (bInFight)
			character.Activate(2);
	}

	void EndGame(bool victory)
	{
		MouseController.mouse.enabled = false;
		bVictory = victory;
		bInFight = false;
		UI_Manager.UIManager.UI_Open("UI_Victory");
	}

	public void CheckObjective()
	{
		if (!bInFight)
			return ;
		foreach (Team t in teams)
		{
			if (t.AreObjectivesDone())
			{
				if (t.isPlayer)
					EndGame(true);
				else
					EndGame(false);
			}
		}
	}
	
	public void NextCharacter()
	{
		Character tmp;

		tmp = order[0];
		order.RemoveAt(0);
		order.Add(tmp);
		if (!order[0].gameObject.activeSelf)
			NextCharacter();
		character = order[0];
		character.Activate(2);
	}

	void SortUnitByInitiative()
	{
		Character	tmp;
	
		int i,j;

		if (order.Count <= 0)
			return ;
		i = 0;
		while (i < order.Count)
		{
			j = i;
			while (j < order.Count)
			{
				if (order[j].Initiative() > order[i].Initiative())
				{
					tmp = order[i];
					order[i] = order[j];
					order[j] = tmp;

					i = 0;
					j = i;
				}
				j++;
			}
			i++;
		}
	}


	void OnGUI()
	{
		//DEBUG_OnGUI();
	}

//	void DEBUG_OnGUI()
//	{
//		for (int i = 0; i <= order.Count - 1; i++)
//			GUI.Label(new Rect(400, 30 * i, 500, 30), i == 0 ? ">" + order[i].name + " - " + order[i].Initiative() : order[i].name + " - " + order[i].Initiative());
//	}
}
