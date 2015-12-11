using UnityEngine;
using System.Collections;

public class S_Damage : SpellEffect_Base
{
	public override bool CastOn(Character caster, GameObject target)
	{
		Character 	targetScript;
		
		print (name + "(" + caster.faction + ") : CastOn " + target.name);
		if (target.tag != "Character")
			return (false);
		if (((targetScript = target.GetComponent<Character>()) != null) && caster.faction != targetScript.faction)
		{	
			Report(targetScript);

            targetScript.GetHealthSystem().TakeHit(Damage(targetScript));
			return (true);
		}
		return (false);
	}

	public override bool CastOff(Character caster, GameObject target)
	{
		return (false);
	}
	
	int Damage(Character target)
	{
		return (caster.Attack() + spell.GetPower());
	}

	void Report(Character target)
	{
		string main;
		string details;
		
		if (caster == null)
			print("caster null");
		if (spell == null)
			print("Spel");
		if (spell.GetGuardManager() == null)
			print("guar null");
		main = target.name + " took " + Damage(target) + " damage of type " + spell.GetElement();
		details = "Attack: " + caster.Attack() + " + Power: " + spell.GetPower() + 
			" + GuardBoost: " + spell.GetGuardManager().FindGuardOfType(Guard.EType.DMG_BOOST);
		
		UI_Manager.UIManager.UI_Open("UI_Battle_DamageReport");
		UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(main);
		UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(details);
	}

	public override bool IsValidTarget(GameObject target)
	{
        if (!IsCharacter(target))
            return (false);
        if (IsOnSameTeam(target))
            return (false);
        return (true);
	}
}
