using UnityEngine;
using System; // Required for Action
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public Vector3 teleportLocation = new Vector3(0, 0, 0);
    public float MaxHealth = 3f;

    private float currentHealth; // Use a private backing field
    public bool yesHealthBar;
    public float respawnCooldown = 5f;
    private float respawnTimer = 0f;

    public float CurrentHealth // Define the public property
    {
        get { return currentHealth; }
        set
        {
            // Ensure the value stays within the valid range
            currentHealth = Mathf.Clamp(value, 0f, MaxHealth);

            // Invoke the event after the health has been updated
            if (yesHealthBar)
            {
                OnHealthChanged?.Invoke(currentHealth / MaxHealth); // Use null propagation ?. for safety
            }
        }
    }

    public UnityEvent<float> OnHealthChanged;

    void Awake()
    {
        // Initialize current health using the property to trigger the event
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        if (damageAmount < 0) return; // Don't accept negative damage

        // Modify the health directly and then update the CurrentHealth property
        // This way, the setter is called and the event is invoked
        CurrentHealth -= damageAmount;
        // if (gameObject.tag == "Player")
        // {
        //     transform.Find("AttamckEffect").GetComponent<AudioSource>().Play();
        // }

        if (CurrentHealth <= 0.1)
        {
            Die();
        }

        Debug.Log($"Damage Taken: {damageAmount} Current Health: {CurrentHealth}");
    }

    public void Heal(float healAmount)
    {
        if (healAmount < 0) return; // Don't accept negative healing

        // Modify the health directly and then update the CurrentHealth property
        CurrentHealth += healAmount;
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        if (gameObject.tag == "Player")
        {
            if (Time.time - respawnTimer > respawnCooldown)
            {
                Debug.Log("mc ded");
                GetComponent<Animator>().SetTrigger("die");
                respawnTimer = Time.time; 
            }
        }
        else
        {
            gameObject.active = false;
        }
    }
    public void MoveRespawn()
    {
        Heal(3.0f);
        transform.position = teleportLocation;
    }
}
