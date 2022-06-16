using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private GameObject Robo;

    public Rigidbody rb;
    public Animator anim;
    public Target Enemy;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim.SetBool("Idle", true);
    }

    void Update()
    {
        if (Vector3.Distance(Player.transform.position, Robo.transform.position) > 20)
        {
            anim.SetBool("Seen", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Shoot", false);
            anim.SetBool("OutOfView", true);
        }

        if (Enemy.health <= 0f)
        {
            anim.SetBool("Die", true);
            anim.SetBool("Seen", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Shoot", false);
            anim.SetBool("OutOfView", false);
        }
        
    }    
}
