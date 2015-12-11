using UnityEngine;
using System.Collections;

public class Objectif_KillTarget : AObjectif
{
	public Character	target;

	public override bool IsObjectiveDone(int team)
	{
		foreach (Character c in GameSystem.game.order)
		{
			if (c.faction != team)
			{
				if (c == target && c.IsDead())
					return (true);
			}
		}
		return (false);
	}
}
