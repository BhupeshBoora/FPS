using UnityEngine;

public class Gunshoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public float impactforce = 30f;
    public ParticleSystem muzzleFlash;
    public ParticleSystem Impacteffect;
    public float firerate;
    public float nextimetofire = 0f;

    //For sound:
    public AudioSource Pistol1sound;
    void start()
    {
        Pistol1sound = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextimetofire)
        {
            nextimetofire = Time.time + 1f / firerate;
            shoot();
        }    
    }
    void shoot ()
    {
        Pistol1sound.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactforce);
            }

            Instantiate(Impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
        } 
    }
}
