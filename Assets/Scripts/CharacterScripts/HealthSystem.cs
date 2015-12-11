using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
	private Character	owner;

	public enum EHealth
	{
		HEALTH_FINE,
		HEALTH_DEAD
	}

	public int  health;
    public int  healthMax;
	public int  stamina;

	public EHealth	state;

	public bool		bDead;

	public GameObject	text_losingValues;

//	public GameObject	Graph_Live;
//	public GameObject	Graph_Dead;

	// Use this for initialization
	void Start ()
	{
		owner = GetComponent<Character>();
	}

	public void Init()
	{
		owner = GetComponent<Character>();
		if (owner != null)
		{
            healthMax = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX);
            health = healthMax;
			stamina = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_STAMINA_MAX);
		}
	}

	// Update is called once per frame
	void Update ()
	{
	}

	public void UpdateHealthSystem()
	{
		if (health > owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX))
		{
			health = owner.GetSpecManager().GetValue(StatsSheet.EStats.STATS_HEALTH_MAX);
		}
	}

	public void TakeHit(int damage)
	{
		if (bDead)
			return ;
		print (owner.name + " took " + damage + " damage.");
		health -= damage;
		FloatingTextManager.textManager.CreateText("-" + damage + " hp", Color.red, text_losingValues, owner.transform.position);
		if (health <= 0)
		{
			FloatingTextManager.textManager.CreateText("Dead!", Color.red, text_losingValues, owner.transform.position);
			print (owner.name + " is dead.");

			UI_Manager.UIManager.GetUI("UI_Battle_DamageReport").GetComponent<UI_Battle_DamageReport>().AddDetails(owner.name + " is dead!");
			UI_Manager.UIManager.UI_Open("UI_Battle_DamageReport");

			health = 0;
			state = EHealth.HEALTH_DEAD;
			bDead = true;
			Dead();
		}
	}

    public void Heal(int heal)
    {
        if (bDead)
            return ;
        print(owner.name + " is healed " + heal + " point.");
        health += heal;
        FloatingTextManager.textManager.CreateText("+" + heal + " hp", Color.green, text_losingValues, owner.transform.position);
        if (health >= healthMax)
        {
            health = healthMax;
        }
    }

	public void Dead()
	{
		owner.GetGraphicManager().SetGraphic(GraphicManager.EGraphic.GRAPHIC_DEAD);
		//owner.EndTurn();
	}
}