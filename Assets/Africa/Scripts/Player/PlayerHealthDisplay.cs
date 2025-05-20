using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Slider healthSlider;

    [Header("Player References")]
    [SerializeField] public GameObject playerObject; // Drag your player GameObject here
    private Health playerHealth;
    void Awake()
    {
        if (playerObject == null)
        {
            //Debug.LogError("Player GameObject not assigned to HealthDisplay!");
            Debug.Log("Player GameObject not assigned to HealthDisplay!");
            enabled = false; // Disable the script if no player is assigned
            return;
        }
            playerHealth = playerObject.GetComponent<Health>();
        if (playerHealth == null)
        {
            Debug.LogError("Player GameObject does not have a Health component!");
            enabled = false; // Disable the script if the player has no Health component
            return;
        }

        if (healthSlider == null)
        {
            healthSlider = GetComponent<Slider>();
            if (healthSlider == null)
            {
                 Debug.LogError("Health Slider UI element not assigned or found on the same GameObject!");
                 enabled = false;
                 return;
            }
        }
        healthSlider.maxValue = 1f;
        UpdateHealthDisplay(playerHealth.CurrentHealth / playerHealth.MaxHealth);
    }
    void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged.AddListener(UpdateHealthDisplay);
        }
    }

    // Update is called once per frame
    void OnDisable()
    {
        // Unsubscribe when the object is disabled to prevent errors
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged.RemoveListener(UpdateHealthDisplay);
        }
    }
    private void UpdateHealthDisplay(float normalizedHealth)
    {
        if(healthSlider != null){
            healthSlider.value = normalizedHealth;
        }
        if(normalizedHealth == 0f){
            Debug.Log("died");
        }
    }
}
