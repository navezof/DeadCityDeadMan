using UnityEngine;
using System.Collections;

public class C_Damage : ConjurationEffect_Base
{
	public override bool CastOn(Character caster, GameObject target)
	{
		int			damage;
		Character 	targetScript;

		if (target.tag != "Character")
			return (false);
		print (name + " New C_Damage : CastOn " + target.name);
		if (((targetScript = target.GetComponent<Character>()) != null) && caster.faction != targetScript.faction)
		{
			damage = Damage(targetScript);

            Report(targetScript);

			targetScript.GetHealthSystem().TakeHit(damage);
		}
        return (true);
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
		return (caster.Attack() + spell.GetPower() + spell.GetGuardManager().FindGuardOfType(Guard.EType.DMG_BOOST));
	}

	void Report(Character defender)
	{
        string main;
        string details;

        main = defender.name + " took " + Damage(defender) + " damage of type " + spell.GetElement();
        details = "Attack: " + caster.Attack() + " + Power: " + spell.GetPower() +
                " + GuardBoost: " + spell.GetGuardManager().FindGuardOfType(Guard.EType.DMG_BOOST) + ")";

        UI_Manager.UIManager.UI_Open("UI_Battle_DamageReport");
        UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(main);
        UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(details);
	}
}
