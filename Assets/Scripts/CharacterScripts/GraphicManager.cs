using UnityEngine;
using System.Collections;

public class GraphicManager : MonoBehaviour
{
	public enum EGraphic
	{
		GRAPHIC_DEAD,
		GRAPHIC_LIVE
	};

	public GameObject	dead;
	public GameObject	live;
	
	public void Init()
	{
		SetGraphic(GraphicManager.EGraphic.GRAPHIC_LIVE);
	}

	public void SetGraphic(EGraphic graphic)
	{
		switch (graphic)
		{
		case EGraphic.GRAPHIC_DEAD:
			dead.SetActive(true);
			live.SetActive(false);
			break;
		case EGraphic.GRAPHIC_LIVE:
			dead.SetActive(false);
			live.SetActive(true);
			break;
		default:
			break;
		}
	}
}
