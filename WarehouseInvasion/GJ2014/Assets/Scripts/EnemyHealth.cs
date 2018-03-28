using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
    public AudioClip explosionAudio;
    public AudioSource hurtSource;
    public AudioSource deadSource;
	public int health = 100;
    public GameObject explosion;
    public AnimationClip deathClip;

    private Spawn_Destroy_Enemies spawn_destroy_enemies;
    private Player player;
    private Animator animator;
    private BoxCollider2D enemyCol;
    private EnemyMovement enemyMovement;
    private bool isDead = false;

	void Start()
	{
		spawn_destroy_enemies = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Spawn_Destroy_Enemies>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        enemyCol = GetComponent<BoxCollider2D>();
        enemyMovement = GetComponent<EnemyMovement>();
	}

	void Update () 
	{
		if(health <= 0 && !isDead)
		{
            isDead = true;
            animator.SetBool("isDead", true);
            enemyCol.enabled = false;
            StartCoroutine(DestroyZombie());
		}
	}

    IEnumerator DestroyZombie()
    {
        deadSource.Play();
        spawn_destroy_enemies.remainingEnemies--;
        player.increaseScore();
        enemyMovement.velocity = 0f;
        yield return new WaitForSeconds(deadSource.clip.length);
        Destroy (this.gameObject);
    }

	void OnCollisionEnter2D(Collision2D col)
	{
        hurtSource.Play();

		if(col.gameObject.tag == "Bullet")
		{
			Destroy (col.gameObject);
			health -= 25;
		}
		if(col.gameObject.tag == "Rocket")
		{
			AudioSource.PlayClipAtPoint(explosionAudio,transform.position);
            Instantiate(explosion, col.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			health -= 100;
		}
		if(col.gameObject.tag == "Flame")
		{
			health -= 10;
		}
	}
}