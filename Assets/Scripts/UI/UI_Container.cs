using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Container : UI_Base
{
	//public List<UI_Base> Uis = new List<UI_Base>();
	public UI_Base[] UIs;

	// Use this for initialization
	void Start ()
	{
		foreach (UI_Base ui in UIs)
			ui.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OpenUI()
	{
		foreach (UI_Base ui in UIs)
			ui.enabled = true;
	}

	public override void CloseUI()
	{
		foreach (UI_Base ui in UIs)
			ui.enabled = false;
	}
}
