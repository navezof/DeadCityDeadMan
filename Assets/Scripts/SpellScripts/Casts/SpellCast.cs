using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SpellCast : MonoBehaviour
{
	protected List<Tile>	targets = new List<Tile>();

    /** If true can't be cast on an empty tile*/
	public bool	            bNeedTarget;
    /** If true can't be cast on an occuped tile*/
	public bool             bNeedEmptyTile;

    public int              range;
    public int              effectZone;
    public int              power;
    public GameObject       mainEffect;
    public GameObject       secondaryEffect;
    public Spell.EElement   element;

	public abstract void Cast(Character caster, GameObject target);

	protected List<Tile>	GetTargets(int centerX, int centerY)
	{
		int rangeY;

		rangeY = 0;
		for (int x = (int) centerX - effectZone; x <= centerX + effectZone; x++)
		{
			for (int y = (int) centerY - effectZone; y < centerY + rangeY + 1 ; y++)
				targets.Add(Grid.grid.GetTile(x, y));
			if (x < centerX)
				rangeY++;
			else
				rangeY--;
		}
		return (targets);
	}
}
