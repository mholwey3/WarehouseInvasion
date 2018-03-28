using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	public AudioClip launch;
	public float speed;
	private Vector3 clickedPosition, startPoint;
	// Use this for initialization
	void Start () 
	{
		clickedPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		clickedPosition = Camera.main.ScreenToWorldPoint(clickedPosition);
		startPoint = transform.position;
		GetComponent<Rigidbody2D>().AddForce (transform.right*speed);
		AudioSource.PlayClipAtPoint(launch,transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
