using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	private GameObject player;
	private GameObject gameManager;

	public float velocity = 1.0f;
	private float distance;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		velocity *= Time.deltaTime;
	}

	void Update () 
	{
		if(!gameManager.GetComponent<GameManager>().paused)
		{
			if(player)
			{
			distance = Vector2.Distance(transform.position, player.transform.position);

			if(distance > 0)
				transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocity);
			}

			var dir = player.transform.position - transform.position;
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}
