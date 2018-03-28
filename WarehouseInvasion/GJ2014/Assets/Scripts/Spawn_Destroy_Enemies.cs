using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawn_Destroy_Enemies : MonoBehaviour 
{
	private GameObject player;
	public GameObject enemy;
	public Text waveNum;
	public Text Beginsin;
	public Text countdown;

	private int level = 1;
	private float spawnDistance = 25f;
	private int totalEnemies; //total enemies that will be spawned in a level
	public int remainingEnemies; //number of enemies remaining in the level
	private bool changeLevel = false;
	private bool spawnNext = false;

	void Start () 
	{
		waveNum.text = "Wave " + level;
		player = GameObject.FindGameObjectWithTag("Player");
		SetDifficulty(level);
		StartCoroutine(Countdown(5));
		Invoke ("SpawnNextEnemy", 0.0f);
	}

	void Update () 
	{
        Debug.Log(remainingEnemies);
		if(totalEnemies > 0 && !changeLevel)
		{
			if(spawnNext)
			{
				Invoke ("SpawnNextEnemy", 1.5f);
				spawnNext = false;
			}
		}
        else if(remainingEnemies == 0)
		{
			changeLevel = true;
			StartCoroutine(Countdown(5));
			Invoke ("ToggleChangeLevel", 5.0f);
			level++;
			waveNum.text = "Wave " + level;
			SetDifficulty (level);
		}
	}

	void ToggleChangeLevel()
	{
		changeLevel = false;
	}

	void SpawnNextEnemy()
	{
		int seed = Random.Range (0, 4);
		if(seed == 0)
			Instantiate (enemy, new Vector2(Random.Range (-spawnDistance, spawnDistance), spawnDistance), Quaternion.identity);
		else if(seed == 1)
			Instantiate (enemy, new Vector2(Random.Range (spawnDistance, spawnDistance), -spawnDistance), Quaternion.identity);
		else if(seed == 2)
			Instantiate (enemy, new Vector2(spawnDistance, Random.Range (-spawnDistance, spawnDistance)), Quaternion.identity);
		else if(seed == 3)
			Instantiate (enemy, new Vector2(-spawnDistance, Random.Range (-spawnDistance, spawnDistance)), Quaternion.identity);
        
		totalEnemies--;
		spawnNext = true;
	}

	void SetDifficulty(int level)
	{
        totalEnemies = level * 5;
		remainingEnemies = totalEnemies;
	}

	IEnumerator Countdown(int timer_start_time)
	{
		Beginsin.text = "Begins in";
		for(int i = timer_start_time; i >= 0; i--)
		{
			countdown.text = i.ToString();
			yield return new WaitForSeconds(1);
		}
		Beginsin.text = "";
		countdown.text = "";
		yield return true;
	}
}
