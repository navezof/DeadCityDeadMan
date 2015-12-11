using UnityEngine;
using System.Collections;

public class C_Heal : ConjurationEffect_Base
{
    public override bool CastOn(Character caster, GameObject target)
    {
        Character   targetScript;
        int         heal;

        if (target.tag != "Character")
            return (false);
        if (((targetScript = target.GetComponent<Character>()) != null) && caster.faction == targetScript.faction)
        {
            heal = Heal(caster, targetScript);
            targetScript.GetHealthSystem().Heal(heal);
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
        return (true);
    }

    int Heal(Character caster, Character target)
    {
        return (caster.Attack() + spell.GetPower() + spell.GetGuardManager().FindGuardOfType(Guard.EType.HEAL_BOOST));
    }
    
    void Report(Character target)
    {
        string main;
        string details;

        main = target.name + " receive " + Heal(caster, target) + " health points of type : " + spell.GetElement();
        details = "Attack: " + caster.Attack() + " + Power: " + spell.GetPower() + " + GuardBoost: " + spell.GetGuardManager().FindGuardOfType(Guard.EType.HEAL_BOOST);

        UI_Manager.UIManager.UI_Open("UI_Battle_DamageReport");
        UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(main);
        UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(details);
    }
}
