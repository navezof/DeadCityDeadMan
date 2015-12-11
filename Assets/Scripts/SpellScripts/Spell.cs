using UnityEngine;
using System.Collections;

public abstract class Spell : Character
{
    /** Spell Params */
    protected Character                     caster;
    protected int                           power;
	protected int							range;
    protected EElement                      element;
    protected SpellEffect_Base              mainEffect;
    protected SpellEffect_Base              secondaryEffect;

    public void SetPower(int nPower) { power = nPower; }
    public int GetPower() { return (power); }

    public void SetCaster(Character newCaster) { caster = newCaster; }
    public Character GetCaster() { return (caster); }

    public EElement GetElement() { return (element); }
    public SpellEffect_Base GetMainEffect() { return (mainEffect); }
    public SpellEffect_Base GetSecondaryEffect() { return (secondaryEffect); }

    public enum EElement
    {
        ELEMENT_NEUTRAL,
        ELEMENT_FIRE
    }

	public abstract void Die();

    public void InitSpell(Character newCaster, int newPower, int newRange, EElement newElement, GameObject newMainEffect, GameObject newSecondaryEffect)
    {
        caster = newCaster;
        power = newPower;
        element = newElement;
		range = newRange;
        if (newMainEffect != null && newMainEffect.GetComponent<SpellEffect_Base>() != null)
        {
            mainEffect = newMainEffect.GetComponent<SpellEffect_Base>();
            mainEffect.SetSpell(this);
            mainEffect.SetCaster(caster);
        }
        if (newSecondaryEffect != null && newSecondaryEffect.GetComponent<SpellEffect_Base>() != null)
        {
            secondaryEffect = newSecondaryEffect.GetComponent<SpellEffect_Base>();
            secondaryEffect.SetSpell(this);
            secondaryEffect.SetCaster(caster);
        }
        guardManager = GetComponent<GuardManager>();
    }

	protected bool InRange(GameObject target)
	{
		Tile	targetTile;
		float distance;
		
		if (target.GetComponent<Character>() != null)
		{
			targetTile = target.GetComponent<Character>().GetTile().GetComponent<Tile>();;
		}
		else
		{
			targetTile = target.GetComponent<Tile>().GetComponent<Tile>();
		}
		distance = Mathf.Abs(targetTile.positionX - caster.GetX()) + Mathf.Abs(targetTile.positionY - caster.GetY());
		if (Mathf.RoundToInt(distance) > range)
			return (false);
		return (true);
	}
}
