using UnityEngine;
using System.Collections;

public class Sign : Spell
{
    public void SetTarget(GameObject newTarget) { target = newTarget; }

    private GameObject target;

    void Update()
    {
		if (secondaryEffect)
			secondaryEffect.CastOn(caster, caster.gameObject);
		if (mainEffect)
			mainEffect.CastOn(caster, target);

        Die();
    }

	public bool IsValidTarget(GameObject target)
	{
		if (!InRange(target))
		{
			UI_Battle_Notification.notification.AddNotification(target.name + " is not in range.", Color.red);
			return (false);
		}
		if (mainEffect && !mainEffect.IsValidTarget(target))
			return (false);
        return (true);
	}

	public override void Die()
	{
		Destroy (gameObject);
	}
}
