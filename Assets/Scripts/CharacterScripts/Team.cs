using UnityEngine;
using System.Collections;

public class Team : MonoBehaviour
{
	public int			faction;
	public bool			isPlayer;
	public GameObject[]	characters;
	public AObjectif[]	objectives;

	public bool	AreObjectivesDone()	
	{
		foreach (AObjectif obj in objectives)
		{
			if (obj.IsObjectiveDone(faction) == false)
				return (false);
		}
		return (true);
	}

	public Character	GetCharacter(string name)
	{
		foreach (GameObject c in characters)
		{
			if (c.name == name)
				return (c.GetComponent<Character>());
		}
		return (null);
	}
}
