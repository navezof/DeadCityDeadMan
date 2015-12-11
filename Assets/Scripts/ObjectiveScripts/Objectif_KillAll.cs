using UnityEngine;
using System.Collections;

public class Objectif_KillAll : AObjectif
{
	public override bool IsObjectiveDone(int team)
	{
		bool allDead = true;

		foreach (Character c in GameSystem.game.order)
		{
			if (c.gameObject.tag == "Character" && c.faction != team && !c.IsDead())
				allDead = false;
		}
		return (allDead);
	}
}
