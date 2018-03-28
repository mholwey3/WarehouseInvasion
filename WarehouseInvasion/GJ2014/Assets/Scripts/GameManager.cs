using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool paused;

	// Use this for initialization
	void Start () {

		paused = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P))
		{
			paused = !paused;
		}

	
	}
}
