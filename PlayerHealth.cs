using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxhealth = 100;
    public int currenthealth;
    public HealthBars healthBar;

    void Start()
    {
        currenthealth = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    public void TakeHit(int amount)
    {
        currenthealth -= amount;

        healthBar.SetHealth(currenthealth);

        if (currenthealth <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }

}
