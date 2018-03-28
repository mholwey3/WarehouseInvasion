using UnityEngine;
using System.Collections;

public class Flamethrower : MonoBehaviour 
{
	public float speed;
	private Vector3 clickedPosition, startPoint;
	// Use this for initialization
	void Start () 
	{
		clickedPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		clickedPosition = Camera.main.ScreenToWorldPoint(clickedPosition);
		startPoint = transform.position;
		GetComponent<Rigidbody2D>().AddForce (transform.right*speed);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Invoke ("goAway", 1.5f);
	}
	
	void goAway ()
	{
		Destroy (this.gameObject);
	}
}
