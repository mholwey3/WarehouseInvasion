using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	private GameObject player;
	
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ( "Player" );
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z);
	}

	void OnTriggerExit2D(Collider2D obj)
	{
		Destroy(obj.gameObject);
	}


}
