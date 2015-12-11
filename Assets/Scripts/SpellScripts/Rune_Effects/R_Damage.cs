using UnityEngine;
using System.Collections;

public class R_Damage : RuneEffect_Base
{
	public override bool CastOn(Character caster, GameObject target)
	{
		int			damage;
		Character 	targetScript;

		print (name + "(" + caster.faction + ") : CastOn " + target.name);
		if (target.tag != "Character")
			return (false);
		if (((targetScript = target.GetComponent<Character>()) != null) && caster.faction != targetScript.faction)
		{	
			damage = caster.Attack() + spell.GetPower();

            Report(targetScript);

			targetScript.GetHealthSystem().TakeHit(damage);
			return (true);
		}
		return (false);
	}

    public override bool CastOff(Character caster, GameObject target)
    {
        return (false);
    }

    public override bool IsValidTarget(GameObject target)
    {
        if (!IsCharacter(target))
            return (false);
        if (IsOnSameTeam(target))
            return (false);
        return (true);
    }

    int Damage(Character target)
    {
        return (caster.Attack() + spell.GetPower());
    }

    void Report(Character target)
    {
        string main;
        string details;

        main = target.name + " took " + Damage(target) + " damage of type " + spell.GetElement();
        details = "Attack: " + caster.Attack() + " + Power: " + spell.GetPower() + 
		        " + GuardBoost: " + spell.GetGuardManager().FindGuardOfType(Guard.EType.DMG_BOOST);

        UI_Manager.UIManager.UI_Open("UI_Battle_DamageReport");
        UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(main);
        UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(details);
    }
}
