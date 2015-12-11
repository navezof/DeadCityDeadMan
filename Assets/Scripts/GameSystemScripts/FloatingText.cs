using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour
{
	public enum EDirection 
	{
		Direction_Up,
		Direction_Right,
		Direction_Down,
		Direction_Left
	}

	public float 		speed;
	public float		spanLife;
	public EDirection	direction;

	private TextMesh	textMesh;

	void Start ()
	{
		textMesh = GetComponent<TextMesh>();
	}

	public void Init(string text, Color color)
	{
		if (textMesh == null)
			textMesh = GetComponent<TextMesh>();
		textMesh.text = text;
		textMesh.color = color;
		this.gameObject.SetActive(false);
	}

	public void Launch()
	{
		this.gameObject.SetActive(true);
		Invoke("Die", spanLife);
	}

	void Update ()
	{
		switch (direction)
		{
		case EDirection.Direction_Up:
			transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
			break;
		case EDirection.Direction_Right:
			transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
			break;
		case EDirection.Direction_Down:
			transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), transform.position.z);
			break;
		case EDirection.Direction_Left:
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y + (speed * Time.deltaTime), transform.position.z);
			break;
		}
	}

	void Die()
	{
		Destroy(this.gameObject);
	}
}
