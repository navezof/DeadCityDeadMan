using UnityEngine;
using System.Collections;

public class SignCast : SpellCast
{
    public GameObject signPrefab;

	public override void Cast(Character caster, GameObject target)
	{
		UI_Battle_Notification.notification.AddNotification("You cast a sign", Color.red);

        signPrefab = (GameObject) Instantiate(signPrefab, caster.transform.position, new Quaternion());
        signPrefab.GetComponent<Sign>().SetTarget(target);
        signPrefab.GetComponent<Sign>().InitSpell(caster, power, range, element, mainEffect, secondaryEffect);

		GameSystem.game.character.GetActionSystem().action.Action_End(true);
	}
}
