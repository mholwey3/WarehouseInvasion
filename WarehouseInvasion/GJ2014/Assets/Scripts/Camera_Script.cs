using UnityEngine;
using System.Collections;

public class Camera_Script : MonoBehaviour 
{
	
	private GameObject player;
	private float player_x;
	private float player_y;
	
	public float map_x_max;
	public float map_x_min;
	public float map_y_max;
	public float map_y_min;
	
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ( "Player" );
	}
	
	// Update is called once per frame
	void Update () 
	{
		player_x = player.transform.position.x;
		player_y = player.transform.position.y;
		transform.position = new Vector3 (Mathf.Clamp(player_x, map_x_min, map_x_max), Mathf.Clamp(player_y,map_y_min,map_y_max), this.transform.position.z);
	}
}