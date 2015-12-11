using UnityEngine;
using System.Collections;

public class UI_Battle_Analyser : UI_Base
{
	private Character	attacker;
	private Character	defender;

	private Action_Attack	attack;

	public float name_x_p;
	public float name_y_p;
	
	public float life_x_p;
	public float life_y_p;

	public float stamina_x_p;
	public float stamina_y_p;

	public float touch_x_p;
	public float touch_y_p;

	public float damage_x_p;
	public float damage_y_p;

	public float confirm_x_p;
	public float confirm_y_p;
	public float confirm_w_p;
	public float confirm_h_p;

	public float cancel_x_p;
	public float cancel_y_p;
	public float cancel_w_p;
	public float cancel_h_p;

	private float name_x;
	private float name_y;
	
	private float life_x;
	private float life_y;
	
	private float stamina_x;
	private float stamina_y;
	
	private float touch_x;
	private float touch_y;
	
	private float damage_x;
	private float damage_y;
	
	private float confirm_x;
	private float confirm_y;
	private float confirm_w;
	private float confirm_h;

	private float cancel_x;
	private float cancel_y;
	private float cancel_w;
	private float cancel_h;

	void Awake()
	{

	}
	// Use this for initialization
	void Start ()
	{
		print ("Attacker set");
		attacker = GameSystem.game.character;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Position();
		PositionText();
	}

	void PositionText()
	{
		name_x = Utils.convertFromPercent(name_x_p, Screen.width) + rect_position.x;
		name_y = Utils.convertFromPercent(name_y_p, Screen.height) + rect_position.y;
		
		life_x = Utils.convertFromPercent(life_x_p, Screen.width) + rect_position.x;
		life_y = Utils.convertFromPercent(life_y_p, Screen.height) + rect_position.y;

		stamina_x = Utils.convertFromPercent(stamina_x_p, Screen.width) + rect_position.x;
		stamina_y = Utils.convertFromPercent(stamina_y_p, Screen.height) + rect_position.y;

		touch_x = Utils.convertFromPercent(touch_x_p, Screen.width) + rect_position.x;
		touch_y = Utils.convertFromPercent(touch_y_p, Screen.height) + rect_position.y;

		damage_x = Utils.convertFromPercent(damage_x_p, Screen.width) + rect_position.x;
		damage_y = Utils.convertFromPercent(damage_y_p, Screen.height) + rect_position.y;

		name_x = Utils.convertFromPercent(name_x_p, Screen.width) + rect_position.x;
		name_y = Utils.convertFromPercent(name_y_p, Screen.height) + rect_position.y;

		confirm_x = Utils.convertFromPercent(confirm_x_p, Screen.width) + rect_position.x;
		confirm_y = Utils.convertFromPercent(confirm_y_p, Screen.height) + rect_position.y;
		confirm_w = Utils.convertFromPercent(confirm_w_p, Screen.width);
		confirm_h = Utils.convertFromPercent(confirm_h_p, Screen.height);

		cancel_x = Utils.convertFromPercent(cancel_x_p, Screen.width) + rect_position.x;
		cancel_y = Utils.convertFromPercent(cancel_y_p, Screen.height) + rect_position.y;
		cancel_w = Utils.convertFromPercent(cancel_w_p, Screen.width);
		cancel_h = Utils.convertFromPercent(cancel_h_p, Screen.height);
	}

	void OnGUI()
	{
		attacker = GameSystem.game.character;
		attack = (Action_Attack) attacker.GetActionSystem().action;
		if (attack == null)
		{
			print ("Attack is null");
			return ;
		}
		if (skin != null)
			GUI.skin = skin;
		GUI.depth = -1;

		GUI.Box(rect_position, "");
		GUI.Label(new Rect(name_x, name_y, rect_position.width, rect_position.y), attacker.name);
		GUI.Label(new Rect(life_x, life_y, rect_position.width, rect_position.y), "Health : " + attacker.Health() + "/" + attacker.HealthMax());
		GUI.Label(new Rect(stamina_x, stamina_y, rect_position.width, rect_position.y), "Stamina : " + attacker.Stamina() + "/" + attacker.StaminaMax());
		GUI.Label(new Rect(touch_x, touch_y, rect_position.width, rect_position.y), "Probabilities of success = " + attack.GetTouchProbality() + "%");
		GUI.Label(new Rect(damage_x, damage_y, rect_position.width, rect_position.y), "Damage estimation = " + attack.GetDamageEstimation());

		if (GUI.Button(new Rect(confirm_x, confirm_y, confirm_w, confirm_h), "Attack!"))
		{
			attack.Attack_Start();
		}
		if (GUI.Button(new Rect(cancel_x, cancel_y, cancel_w, cancel_h), "Cancel"))
		{
			attack.Action_Cancel();
		}
	}
}
