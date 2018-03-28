using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public AudioClip shoot;
	public float speed;
	private GameObject gameManager;

	// Use this for initialization
	void Start () 
	{
		GetComponent<Rigidbody2D>().AddForce (transform.right*speed);
		AudioSource.PlayClipAtPoint(shoot,transform.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}
}
