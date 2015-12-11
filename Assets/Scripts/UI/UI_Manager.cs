using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Manager : MonoBehaviour
{
	public static UI_Manager UIManager;
	
	public UI_Base[]	UIs;
	//private Character	character;

	void Awake()
	{
		if (UIManager != null)
			Destroy(UIManager);
		else
			UIManager = this;
	}

	public bool UI_Open(string UIName)
	{
		foreach (UI_Base ui in UIs)
		{
			if (ui.name == UIName)
			{	
				ui.enabled = true;
				ui.OpenUI();
                return (true);
				//AddUI(ui);
			}
		}
        Debug.LogError("Error : UI " + UIName + " failed to open correctly.");
        return (false);
	}

	public void UI_Close(string UIName)
	{
		foreach (UI_Base ui in UIs)
		{
			if (ui.name == UIName)
			{
				ui.CloseUI();
				//RemoveUI(ui);
			}
		}
	}

	public void UI_CloseAll()
	{
		foreach (UI_Base ui in UIs)
		{
			ui.CloseUI();
		}
	}

	public bool IsOpen(string UIName)
	{
		foreach (UI_Base ui in UIs)
		{
			if (ui.name == UIName)
				return (ui.IsOpen());
		}
		return (false);
	}

	public UI_Base	GetUI(string UIName)
	{
		foreach (UI_Base ui in UIs)
		{
			if (ui.name == UIName)
				return (ui);
		}
		return (null);
	}
}
