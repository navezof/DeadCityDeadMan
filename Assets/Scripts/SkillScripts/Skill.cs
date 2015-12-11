using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour
{
	protected Character	owner;

	public int			range;
	public int			power;

	public bool			bWaiting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Use() {}

	protected bool InRange(Transform target)
	{
		return (true);
	}

	protected void OnGUI()
	{
		if (bWaiting)
		{
			GUI.Label(new Rect(Screen.width/2, Screen.height * 0.75f, 300, 30), "Select a target");
		}
	}
}
