using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol1Anim: MonoBehaviour
{
    public Animator anim;
    public PlayerMovement player;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x == 0f && y == 0)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            anim.SetBool("Shoot", false);
        }
        else
        {
            if (player.iswalking == false)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
                anim.SetBool("Shoot", false);
            }
            if (player.iswalking == true)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
                anim.SetBool("Shoot", false);
            }
        }    
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
              anim.SetBool("Idle", false);
              anim.SetBool("Walk", false);
              anim.SetBool("Run", false);
              anim.SetBool("Shoot", true);
            }       
    } 
}
