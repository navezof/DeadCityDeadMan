using UnityEngine;
using System.Collections;

public class S_FireEnchantment : SpellEffect_Base
{
	public GameObject	guard;

	public override bool CastOn (Character caster, GameObject target)
	{
		caster.GetGuardManager().AddGuard(guard);
        return (true);
	}

	public override bool CastOff (Character caster, GameObject target)
	{
		throw new System.NotImplementedException ();
	}

    public override bool IsValidTarget(GameObject target)
    {
        if (!IsCharacter(target))
            return (false);
        if (IsOnSameTeam(target))
            return (false);
        return (true);
    }

	void Report(Spell target)
	{
		string details;
		
		details = " received a " + guard.name + " ( " + guard.GetComponent<Guard>().type + ": " + guard.GetComponent<Guard>().power + ")"; 
		
		UI_Manager.UIManager.UI_Open("UI_Battle_DamageReport");
		UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().SetDefender(target);
		UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(details);
	}
}
