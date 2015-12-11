using UnityEngine;
using System.Collections;

public class UI_Battle_Summary : UI_Base
{
	public Character		attacker;
	public Action_Attack	attack;

	public float 	next_x_p;
	public float 	next_y_p;
	public float 	next_w_p;
	public float 	next_h_p;
	
	public float 	cancel_x_p;
	public float 	cancel_y_p;
	public float 	cancel_w_p;
	public float 	cancel_h_p;
	
	public float	detail_x_p;
	public float	detail_y_p;
	public float	detail_w_p;
	public float	detail_h_p;

	public float	touch_x_p;
	public float	touch_y_p;

	public float	d_touch_x_p;
	public float	d_touch_y_p;

	public float	touch_result_x_p;
	public float	touch_result_y_p;

	public float	defense_x_p;
	public float	defense_y_p;

	public float	d_defense_x_p;
	public float	d_defense_y_p;

	//public float	defense_result_x_p;
	//public float	defense_result_y_p;

	public float	damage_x_p;
	public float	damage_y_p;

	private Rect	next;
	private Rect	cancel;	
	private Rect	detail;

	private float	touch_x;
	private float	touch_y;

	private float	d_touch_x;
	private float	d_touch_y;

	private float	touch_result_x;
	private float	touch_result_y;

	private float	defense_x;
	private float	defense_y;
	
	private float	d_defense_x;
	private float	d_defense_y;

	//private float	defense_result_x;
	//private float	defense_result_y;
	
	private float	damage_x;
	private float	damage_y;

	private bool	bDetails;
	
	public void SetAttack(Action_Attack _attack) { attack = _attack; }

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		Position();
		PositionChild();
	}

	void PositionChild()
	{
		detail.x = Utils.convertFromPercent(detail_x_p, Screen.width);
		detail.y = Utils.convertFromPercent(detail_y_p, Screen.height);
		detail.width = Utils.convertFromPercent(detail_w_p, Screen.width);
		detail.height = Utils.convertFromPercent(detail_h_p, Screen.height);

		touch_x = Utils.convertFromPercent(touch_x_p, Screen.width) + detail.x;
		touch_y = Utils.convertFromPercent(touch_y_p, Screen.height) + detail.y;

		d_touch_x = Utils.convertFromPercent(d_touch_x_p, Screen.width) + detail.x;
		d_touch_y = Utils.convertFromPercent(d_touch_y_p, Screen.height) + detail.y;

		touch_result_x = Utils.convertFromPercent(touch_result_x_p, Screen.width) + detail.x;
		touch_result_y = Utils.convertFromPercent(touch_result_y_p, Screen.height) + detail.y;

		defense_x = Utils.convertFromPercent(defense_x_p, Screen.width) + detail.x;
		defense_y = Utils.convertFromPercent(defense_y_p, Screen.height) + detail.y;

		d_defense_x = Utils.convertFromPercent(d_defense_x_p, Screen.width) + detail.x;
		d_defense_y = Utils.convertFromPercent(d_defense_y_p, Screen.height) + detail.y;

		//defense_result_x = Utils.convertFromPercent(defense_result_x_p, Screen.width) + detail.x;
		//defense_result_y = Utils.convertFromPercent(defense_result_y_p, Screen.height) + detail.y;

		damage_x = Utils.convertFromPercent(damage_x_p, Screen.width) + detail.x;
		damage_y = Utils.convertFromPercent(damage_y_p, Screen.height) + detail.y;

		next.x = Utils.convertFromPercent(next_x_p, Screen.width) + rect_position.x;
		next.y = Utils.convertFromPercent(next_y_p, Screen.height) + rect_position.y;
		next.width = Utils.convertFromPercent(next_w_p, Screen.width);
		next.height = Utils.convertFromPercent(next_h_p, Screen.height);
		
		cancel.x = Utils.convertFromPercent(cancel_x_p, Screen.width) + rect_position.x;
		cancel.y = Utils.convertFromPercent(cancel_y_p, Screen.height) + rect_position.y;
		cancel.width = Utils.convertFromPercent(cancel_w_p, Screen.width);
		cancel.height = Utils.convertFromPercent(cancel_h_p, Screen.height);
	}

	void OnGUI()
	{
		if (attack == null)
		{
			print ("Attacl is null");
			return ;
		}
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = -1;

		GUI.Box (rect_position, "");
		if (attack.GetAtkTouchScore() <= 0)
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width, rect_position.height), attack.GetTarget().name + " dodged the attack.");
		else
			GUI.Label(new Rect(rect_position.x + offsetX, rect_position.y + offsetY, rect_position.width, rect_position.height), attack.GetTarget().name + " took " + attack.GetAtkDamage() + " damages.");

		if (GUI.Button(next, "Details"))
			bDetails = !bDetails;
		if (GUI.Button(cancel, "X"))
		{
			attack.Action_End(true);
			CloseUI();
			bDetails = false;
		}
		if (bDetails)
			DrawDetails();
	}

	void DrawDetails()
	{
		GUI.Box(detail, "");
		GUI.Label(new Rect(touch_x, touch_y, detail.width, detail.height),
		          "Attacker's Touch : " + (attack.GetAtkTouchScore() + attack.GetDefTouchScore()) +
		          "\t (Atk : " + attack.GetOwner().Attack() + " + Dice : " + (attack.GetAtkTouchScore() + attack.GetDefTouchScore() - attack.GetOwner().Attack()) + ")");
		GUI.Label(new Rect(d_touch_x, d_touch_y, detail.width, detail.height),
		          "Defender's Touch : " + attack.GetDefTouchScore() + 
		          "\t (Def : " + attack.GetTarget().Attack() + " + Dice : " + (attack.GetDefTouchScore() - attack.GetTarget().Attack()) + ")");
		if (attack.GetAtkTouchScore() <= 0)
		{
			GUI.Label(new Rect(touch_result_x, touch_result_y, detail.width, detail.height), attack.GetOwner().name + " missed " + attack.GetTarget().name);
		}
		else 
		{
			GUI.Label(new Rect(touch_result_x, touch_result_y, detail.width, detail.height), attack.GetOwner().name + " touched " + attack.GetTarget().name + " with a bonus of " + attack.GetAtkTouchScore());
			GUI.Label(new Rect(defense_x, defense_y, detail.width, detail.height),
			          "Attacker's Attack : " + (attack.GetAtkDamage() + attack.GetDefDamage()) +
			          "\t (Atk : " + attack.GetOwner().Attack() + " + Dice : " + ((attack.GetAtkDamage() + attack.GetDefDamage()) - (attack.GetOwner().Attack() + attack.GetAtkTouchScore())) +
			          " + Bonus : " + attack.GetAtkTouchScore() + ")");
			GUI.Label(new Rect(d_defense_x, d_defense_y, detail.width, detail.height),
			          "Defender's Protection : " + attack.GetDefDamage() + 
			          "\t (Def : " + attack.GetTarget().Defense() + " + Dice : " + (attack.GetDefDamage() - attack.GetTarget().Defense()) + ")");
			if (attack.GetAtkDamage() <= 1)
			{
				GUI.Label(new Rect(damage_x, damage_y, detail.width, detail.height), attack.GetTarget().name + " defended against " + attack.GetOwner().name);
			}
			else
			{
				GUI.Label(new Rect(damage_x, damage_y, detail.width, detail.height), attack.GetOwner().name + " dealt " + attack.GetAtkDamage() + " damages to " + attack.GetTarget().name);
			}

			//GUI.Label(new Rect(touch_result_x, touch_result_y, detail.width, detail.height), attack.GetOwner().name + " touched " + attack.GetTarget().name + " with a bonus of " + attack.GetAtkTouchScore());
			//GUI.Label(new Rect(defense_x, defense_y, detail.width, detail.height), "Defense : " + (attack.GetAtkDamage() + attack.GetDefDamage()) + " - vs - " + attack.GetDefDamage());
			//GUI.Label(new Rect(damage_x, damage_y, detail.width, detail.height), "Damage : " + attack.GetAtkDamage());
		}
	}
}
