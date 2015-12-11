using UnityEngine;
using System.Collections;

public class R_Block : RuneEffect_Base
{
    public ConjurationEffect_Base[] blockable;
    public int power;

    public override bool CastOn(Character caster, GameObject target)
    {
        Conjuration targetScript;
        int         damage;

        print(name + " : CastOn " + target.name);

        if (((targetScript = target.GetComponent<Conjuration>()) != null) && targetScript.GetCaster().faction != caster.faction)
        {
            UI_Manager.UIManager.UI_Open("UI_Battle_DamageReport");
			UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(name + " activated!");


            damage = targetScript.GetConjurationPower();
						
            UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(name + " blocked " + spell.GetPower() + " damages!");
            UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(
                                        name + " power : " + spell.GetPower() + " - vs - " + targetScript.name + " power : " + damage);

            targetScript.SetPower(targetScript.GetPower() - spell.GetPower());
            spell.SetPower(spell.GetPower() - damage);

            if (spell.GetPower() <= 0)
            {
                spell.SetPower(0);
				UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(name + " is broken!");
                UI_Battle_Notification.notification.AddNotification(name + " is broken!", Color.red);
                spell.Die();               
            }
            else if (targetScript.GetConjurationPower() <= 0)
            {
				UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(targetScript + " is blocked!");
                targetScript.Die();
            }
            else
            {
				UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(targetScript.name + " has " + targetScript.GetConjurationPower() + " power left!");
            }
         }
        return (false);
    }

    public override bool CastOff(Character caster, GameObject target)
    {
        return (false);
    }
}
