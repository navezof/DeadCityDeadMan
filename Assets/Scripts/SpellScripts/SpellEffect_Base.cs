using UnityEngine;
using System.Collections;

public abstract class SpellEffect_Base : MonoBehaviour
{
    protected Character caster;
    protected Spell     spell;

    public void SetCaster(Character newCaster) { caster = newCaster; }
    public Character GetCaster() { return (caster); }

    public void SetSpell(Spell nSpell) { spell = nSpell; }
    public Spell GetSpell() { return (spell); }

    public abstract bool CastOn(Character caster, GameObject target);
    public abstract bool CastOff(Character caster, GameObject target);

    public abstract bool IsValidTarget(GameObject target);

    /**
     * 
     * Check the validity of the target
     * 
     */

    public bool IsOnSameTeam(GameObject target)
    {
        Character targetScript;

        if ((targetScript = target.GetComponent<Character>()) == null)
            return (false);
        if (targetScript.faction == GetCaster().faction)
        {
            UI_Battle_Notification.notification.AddNotification("You can't target a friend.", Color.red);
            return (false);
        }
        return (true);
    }

    public bool IsCharacter(GameObject target)
    {
        if (target.tag != "Character" || target.GetComponent<Character>() == null)
        {
            UI_Battle_Notification.notification.AddNotification(target.name + " is not a valid target.", Color.red);
            return (false);
        }
        return (true);
    }

    public bool IsTile(GameObject target)
    {
        if (target.tag != "Tile" || target.GetComponent<Tile>() == null)
            return (false);
        return (true);
    }

    public bool IsEmpty(GameObject target)
    {
        Tile tile;

        if ((tile = target.GetComponent<Tile>()) != null)
        {
            if (!tile.IsEmpty())
            {
                UI_Battle_Notification.notification.AddNotification("You need to target an empty tile.", Color.red);
                return (false);
            }
        }
        return (true);
    }

    public bool IsSameElement(GameObject target)
    {
        if (target.GetComponent<Spell>().GetElement() != spell.GetElement())
            return (false);
        return (true);
    }

    public bool IsConjuration(GameObject target)
    {
        if (target.GetComponent<Conjuration>() == null)
            return (false);
        return (true);
    }
}

