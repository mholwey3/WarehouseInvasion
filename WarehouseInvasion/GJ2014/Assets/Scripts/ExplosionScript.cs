using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour
{
    public AnimationClip animation;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(DestroyExplosion());
    }

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(animation.length - 0.1f);
        Destroy(this.gameObject);
    }

    // For area of affect rocket explosion
//    void OnTriggerEnter2D(Collider2D col)
//    {
//        if(col.gameObject.tag == "Enemy")
//        {
//            col.gameObject.GetComponent<EnemyHealth>().health -= 100;
//        }
//    }
}