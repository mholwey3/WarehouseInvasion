using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject bullet;
	public GameObject rocket;
	public GameObject flame;
	public AudioClip ouch;
	public AudioClip death;
	public Transform bulletSpawn;
	public Transform missleSpawn;
	public Transform flameSpawn;

	public Sprite player_bullet;
	public Sprite player_missle;
	public Sprite player_flame;
	private SpriteRenderer spriteRenderer;

	public float speed;
	private float currentHealth;
	private float currentAmmo;
	public float map_x_max;
	public float map_x_min;
	public float map_y_max;
	public float map_y_min;
	
	public int gunState;
	
	public bool flamecool;

	public Slider healthSlider;
	public float maxHealth;

	public Slider ammoSlider;
	public float maxAmmo;


	public Text scoreText;
	private int score;
	private GameObject gameManager;
	
	// Use this for initialization
	void Start () 
	{
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		transform.position = new Vector2 (0f, 0f);
		speed *= Time.deltaTime;
		gunState = 0;
		flamecool = true;
		currentHealth = maxHealth;
		score = 0;
		currentAmmo = maxAmmo;
		scoreText.text = "Score: " + score;
		InvokeRepeating ("addAmmo", 1f, .05f);
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!gameManager.GetComponent<GameManager>().paused)
		{
			ammoSlider.value = currentAmmo;

			var pos = Camera.main.WorldToScreenPoint(transform.position);
			var dir = Input.mousePosition - pos;
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
				transform.position = new Vector2 (Mathf.Clamp(transform.position.x, map_x_min, map_x_max), Mathf.Clamp(transform.position.y+ speed, map_y_min, map_y_max));
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow))
				transform.position = new Vector2 (Mathf.Clamp(transform.position.x, map_x_min, map_x_max), Mathf.Clamp(transform.position.y- speed, map_y_min, map_y_max));
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
				transform.position = new Vector2 (Mathf.Clamp(transform.position.x + speed, map_x_min, map_x_max), Mathf.Clamp(transform.position.y, map_y_min, map_y_max));
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))
				transform.position = new Vector2 (Mathf.Clamp(transform.position.x - speed, map_x_min, map_x_max), Mathf.Clamp(transform.position.y, map_y_min, map_y_max));
				
			if (Input.GetMouseButtonDown(1))
			{
				gunState = (gunState+1)%3;
			}
			
			if(gunState != 2)
			{
				if(gunState == 0)
				{
					spriteRenderer.sprite = player_bullet;
				}
				else
				{
					spriteRenderer.sprite = player_missle;
				}
				if(Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0))
				{
					if(gunState == 0 && currentAmmo - 10 >= 0)
					{
						Instantiate(bullet, new Vector3(bulletSpawn.position.x, bulletSpawn.position.y, 0f), Quaternion.AngleAxis(angle, Vector3.forward));
						currentAmmo-=10;
					}
					if(gunState == 1 && currentAmmo - 50 >= 0)
					{
						Instantiate(rocket, new Vector3(missleSpawn.position.x, missleSpawn.position.y, 0f), Quaternion.AngleAxis(angle, Vector3.forward));
						currentAmmo-=50;
					}
				}
			}
			else if(gunState == 2)
			{
				spriteRenderer.sprite = player_flame;
				if(Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.Mouse0) && flamecool && currentAmmo - 5 >= 0)
				{
					Instantiate(flame, new Vector3(flameSpawn.position.x, flameSpawn.position.y, 0f), Quaternion.LookRotation(new Vector2(dir.x,dir.y)));
					flamecool = false;
					currentAmmo-=5;
					Invoke ("ToggleCooldown", 0.05f);
					if (Input.GetMouseButtonDown(0))
						GetComponent<AudioSource>().Play ();
				}
			}

			if (Input.GetMouseButtonUp(0))
				GetComponent<AudioSource>().Stop ();
			
			if (currentHealth  <= 0)
			{
				AudioSource.PlayClipAtPoint(death,transform.position);
				Destroy (this.gameObject);
				Application.LoadLevel(0);
			}
				
			if (Physics.CheckSphere (transform.position,2f))
				Debug.Log ("Nom");
		}
	}
	
	void ToggleCooldown ( )
	{
		flamecool = true;
	}

	void addAmmo()
	{
		if(currentAmmo < maxAmmo)
			currentAmmo++;
	}
	
	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			currentHealth--;
			healthSlider.value = currentHealth;
			Debug.Log ("Nom - " + currentHealth);
		}
		if(col.gameObject.tag == "Flame")
		{
			currentHealth -= .1f;
			healthSlider.value = currentHealth;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag != "Bullet")
			AudioSource.PlayClipAtPoint(ouch,transform.position);
	}

	public void increaseScore()
	{
		score++;
		scoreText.text = "Score: " + score;
	}
}