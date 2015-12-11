using UnityEngine;
using System.Collections;

public class R_Damage_Boost : RuneEffect_Base
{
    public GameObject   guard;

    public override bool CastOn(Character caster, GameObject target)
	{
		Conjuration 	targetScript;
		
		print (name + " : CastOn " + target.name);
		if ((IsConjuration(target) && IsSameElement(target) && IsOnSameTeam(target)))
		{
            targetScript = target.GetComponent<Conjuration>();
            Report(targetScript);
            targetScript.GetGuardManager().AddGuard(guard);
			return (true);
		}
		return (false);
	}
	
	public override bool CastOff(Character caster, GameObject target)
	{
		return (false);
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
