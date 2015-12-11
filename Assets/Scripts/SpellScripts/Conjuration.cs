using UnityEngine;
using System.Collections;

public class Conjuration : Spell
{
    /** Moving variables */
    private Transform					target;
	private float 						step;
	public float						distance;
	public float						speed;

    /** Setter and Getter */
	public void SetTarget(Transform newTarget) { target = newTarget; }
    public Transform GetTarget() { return (target); } 

	void Update()
	{
		if (target == null)
			return ;
        
        if (target.position == caster.transform.position)
        {
            if (mainEffect != null && mainEffect.CastOn(caster, caster.gameObject))
            {
                if (secondaryEffect != null)
                    secondaryEffect.CastOn(caster, caster.gameObject);
                Die();
            }
        }
         
		step = speed * Time.deltaTime;
		if (Vector3.Distance(target.position, transform.position) > distance)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		}
	}


	void OnCollisionEnter(Collision col)
	{
		if (secondaryEffect != null)
			secondaryEffect.CastOn(caster, col.gameObject);
	    if (mainEffect != null && mainEffect.CastOn(caster, col.gameObject))
		    Die ();
	}

	public override void Die()
	{
		Destroy(gameObject);
	}

    /** Return the power of the first effect */
    public int GetConjurationPower()
    {
        return (power);
    }

    /** Set the power of the first effect */
    public void SetConjurationPower(int addedValue)
    {
        power += addedValue;
    }
}
