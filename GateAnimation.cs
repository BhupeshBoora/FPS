using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimation : MonoBehaviour
{
    public Transform target;
    public Transform gate;           
    public GameObject Robot;
    public Animator anim;

    void Update()
    {
        float distance = Vector3.Distance(target.position, gate.position);

        if (Robot == null)
        {
            anim.SetBool("Enemies_Dead", true);
        }
        else
        {
            anim.SetBool("Enemies_Dead", false);
        }
        if (distance <= 10.0)
        {
            anim.SetBool("playernearby", true);
        }
        else
        {
            anim.SetBool("playernearby", false);
        }

    }
}
