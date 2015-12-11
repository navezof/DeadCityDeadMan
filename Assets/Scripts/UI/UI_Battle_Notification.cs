using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI_Battle_Notification : UI_Base
{
	public static UI_Battle_Notification	notification;

	public Rect		exit_button;

	public float	timeout;
	private float	lastTimeout;

	public int		notificationLimit;

	public List< KeyValuePair<string, Color>> notifications = new List<KeyValuePair<string, Color>>();

	void Awake()
	{
		if (notification != null)
			Destroy(notification);
		else
			notification = this;
	}

	void Start ()
	{
		lastTimeout = Time.time;
	}

	void Update ()
	{
		if (notifications.Count > 0)
		{
			Position();
			if (Time.time - lastTimeout > timeout)
			{
				DeleteNotification(0);
				lastTimeout = Time.time;
			}
		}
	}

	void OnGUI()
	{
		if (notifications.Count > 0)
		{
			if (skin)
				GUI.skin = skin;
			GUI.depth = depth;

			for (int i = 0; i < notifications.Count ; i++)
			{
				if (i < notificationLimit)
				{
					GUI.contentColor = notifications[i].Value;
					GUI.Box(new Rect(rect_position.x + offsetX,
					                 rect_position.y + (offsetY + rect_position.height) * -i,
					                 rect_position.width - offsetX, rect_position.height - offsetY),
					        		notifications[i].Key);
					if (GUI.Button(new Rect(rect_position.x + rect_position.width,
					                    rect_position.y + (offsetY + rect_position.height) * -i,
					                    rect_position.width/10, rect_position.height - offsetY), 
					           		 "x"))
					{
						DeleteNotification(i);
					}
				}
			}
		}
	}

	public void AddNotification(string msg, Color color)
	{
		lastTimeout = Time.time;
		notifications.Add(new KeyValuePair<string, Color>(msg, color));
	}

	public void DeleteNotification(int notificationToDelete)
	{
		notifications.RemoveAt(notificationToDelete);
		lastTimeout = Time.time;
	}

	public void DeleteNotification(string msg)
	{
		foreach (KeyValuePair<string, Color> notif in notifications)
		{
			if (notif.Key == msg)
			{
				notifications.Remove(notif);
				return ;
			}
		}
	}

	public void Clear()
	{
		notifications.Clear();
	}
}
