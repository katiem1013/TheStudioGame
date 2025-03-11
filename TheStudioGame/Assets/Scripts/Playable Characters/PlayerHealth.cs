using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Positions")]
    public Vector3 startingPos;

    [Header("Health")]
    public float playerHealth = 100f;
    public float playerMaxHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if the players health goes over max health it gets set to max health
        if (playerHealth > playerMaxHealth)
            playerHealth = playerMaxHealth;

        if (playerHealth <= 0)
            Die();
    }

    // the player takes damage
    public void TakeDamage(float amount)
    {
        playerHealth -= amount;

        // kills the player if their health hits zero
        if (playerHealth <= 0f)
            Die();
    }

    // the player dies and health gets set back
    public void Die()
    {
        transform.position = startingPos;
        playerHealth = playerMaxHealth;
    }
}
