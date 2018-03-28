using UnityEngine;
using System.Collections;

public class Follow_Player : MonoBehaviour 
{

	private GameObject player;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ( "Player" );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player)
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, this.transform.position.z);
	}
}
