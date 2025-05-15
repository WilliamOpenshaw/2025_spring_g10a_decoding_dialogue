using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoController : MonoBehaviour
{
    public enum RhinoState
    {
        Idle,
        Wander,
        Chase,
        Attack
    }
    private RhinoState currentState = RhinoState.Idle;

    [SerializeField] private float moveSpeed = 4f; // Standard move speed for chase and wander
    [SerializeField] private Collider2D biteLeft; // Likely the final attack collider
    [SerializeField] private Collider2D biteRight; // Likely the final attack collider
    [SerializeField] private Collider2D WalkingAttackLeft; // Potential collider for attacks during movement
    [SerializeField] private Collider2D WalkingAttackRight; // Potential collider for attacks during movement
    [SerializeField] private CapsuleCollider2D mainCollider; // Main body collider

    [SerializeField] private float idleDuration = 2.5f; // Idle time
    [SerializeField] private float wanderDuration = 4f; // Wander time
    [SerializeField] private Transform player; // Drag your player object here in the inspector
    [SerializeField] private float chaseDistance = 8f; // Distance to start chasing
    [SerializeField] private float attackDistance = 3f; // Distance to start the final attack
    [SerializeField] private float loseTargetDistance = 12f; // Distance to stop chasing and return to wander

    private float idleTimer;
    private float wanderTimer;
    private Vector2 wanderDirection;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private bool wasMovingRight; // Used for attack direction and facing

    private bool isAttacking = false; // Flag to track if the final attack is active

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mainCollider = GetComponent<CapsuleCollider2D>();

        // Disable attack colliders on Awake
        if (biteLeft != null) biteLeft.enabled = false;
        if (biteRight != null) biteRight.enabled = false;
        if (WalkingAttackLeft != null) WalkingAttackLeft.enabled = false;
        if (WalkingAttackRight != null) WalkingAttackRight.enabled = false;

        // Ensure main collider is enabled unless an attack animation disables it
        if (mainCollider != null) mainCollider.enabled = true;

        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogWarning("RhinoController: Player GameObject not found. Please tag your player as 'Player'.");
            }
        }
    }

    private void Update()
    {
        HandleState();
    }

    public void HandleState()
    {
        // Check for player within chase distance, potentially overriding current state
        // unless currently performing the final attack
        if (!isAttacking && player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Transition to Chase if player is close enough
            if (distanceToPlayer < chaseDistance && currentState != RhinoState.Chase && currentState != RhinoState.Attack)
            {
                currentState = RhinoState.Chase;
            }
            // Transition to Attack if player is within attack range while chasing
            else if (distanceToPlayer < attackDistance && currentState == RhinoState.Chase)
            {
                currentState = RhinoState.Attack;
                TriggerAttack(); // Start the attack sequence
                return; // Exit the rest of the state handling for this frame
            }
            // Transition back to Wander if player gets too far while chasing
            else if (distanceToPlayer > loseTargetDistance && currentState == RhinoState.Chase)
            {
                currentState = RhinoState.Wander;
            }
        }


        switch (currentState)
        {
            case RhinoState.Idle:
                HandleIdle();
                break;
            case RhinoState.Wander:
                HandleWander();
                break;
            case RhinoState.Chase:
                HandleChase();
                break;
            case RhinoState.Attack:
                HandleAttack();
                break;
        }
    }

    public void HandleIdle()
    {
        movement = Vector2.zero;
        SetAnimationDirection(Vector2.zero); // Keep facing last direction or idle pose
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            currentState = RhinoState.Wander;
            idleTimer = 0f;
        }
    }

    public void HandleWander()
    {
        wanderTimer += Time.deltaTime;
        if (wanderTimer >= wanderDuration)
        {
            wanderDirection = Random.insideUnitCircle.normalized;
            // Occasionally return to idle state
            if (Random.Range(0, 3) == 2)
            { // Slightly less likely to idle than elephant/hyena
                currentState = RhinoState.Idle;
                wanderTimer = 0f;
                return;
            }
            wanderTimer = 0f; // Reset timer for next wander phase
        }

        movement = wanderDirection;
        SetAnimationDirection(movement);
    }

    public void HandleChase()
    {
        if (player == null)
        { // Fallback if player somehow becomes null
            currentState = RhinoState.Wander;
            return;
        }

        // Movement is towards the player during chase
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        movement = directionToPlayer;
        SetAnimationDirection(movement); // Face the player while chasing
    }

    public void HandleAttack()
    {
        movement = Vector2.zero; // Stop movement for the final attack animation
        // The final attack logic (enabling/disabling hitboxes) is handled by animation events
    }

    private void SetAnimationDirection(Vector2 moveVector)
    {
        if (movement.magnitude > 0.1f)
        {
            // Prioritize horizontal movement for facing direction during chase/wander
            if (movement.x > 0.1f)
            {
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", true);
                wasMovingRight = true;
            }
            else if (movement.x < -0.1f)
            {
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                wasMovingRight = false;
            }
            // If only moving vertically, maintain the last horizontal direction
            else if (Mathf.Abs(movement.y) > 0.1f)
            {
                animator.SetBool("isLeft", !wasMovingRight);
                animator.SetBool("isRight", wasMovingRight);
            }
        }
        else
        {
            // When idle, keep the last facing direction or set an idle state
             animator.SetBool("isLeft", false); // Assuming idle doesn't have left/right specific states
             animator.SetBool("isRight", false);
             // You might have an "isIdle" bool or similar if needed
        }

        // Control walking/movement animation based on if we are moving
        animator.SetBool("isWalking", movement.magnitude > 0.05f); // Use a small threshold
    }


    private void FixedUpdate()
    {
        // Move if not in the final attack state
        if (!isAttacking)
        {
            float currentMoveSpeed = moveSpeed; // Always use standard move speed
            rb.MovePosition(rb.position + movement * (currentMoveSpeed * Time.fixedDeltaTime));
        }
    }

    private void TriggerAttack()
    {
        if (!isAttacking) // Ensure we only trigger the attack animation once
        {
            isAttacking = true;

            // Determine attack direction based on player's position
            bool attackRight = player != null && player.position.x > transform.position.x;

            // Trigger the appropriate attack animation
            if (attackRight)
            {
                animator.SetTrigger("BiteRight"); // Assuming "BiteRight" is your final attack trigger
                wasMovingRight = true; // Ensure facing is correct during the attack animation
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", true);
            }
            else
            {
                animator.SetTrigger("BiteLeft"); // Assuming "BiteLeft" is your final attack trigger
                wasMovingRight = false;
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
            }

             // The main collider disable/enable and final attack collider enable/disable
             // should be handled by animation events during the final attack animation.
             // Do NOT disable the main collider here at the start of TriggerAttack.
        }
    }

    // Methods called by Animation Events for walking attacks (if applicable)
    public void EnableWalkAttackHitBoxLeft()
    {
        if (WalkingAttackLeft != null) WalkingAttackLeft.enabled = true;
         Debug.Log("Rhino Walking Attack Left enabled");
    }
    public void EnableWalkAttackHitBoxRight()
    {
        if (WalkingAttackRight != null) WalkingAttackRight.enabled = true;
         Debug.Log("Rhino Walking Attack Right enabled");
    }
    public void DisableWalkAttackHitBoxLeft()
    {
        if (WalkingAttackLeft != null) WalkingAttackLeft.enabled = false;
         Debug.Log("Rhino Walking Attack Left disabled");
    }
    public void DisableWalkAttackHitBoxRight()
    {
        if (WalkingAttackRight != null) WalkingAttackRight.enabled = false;
         Debug.Log("Rhino Walking Attack Right disabled");
    }

    // Methods called by Animation Events for the final bite/horn attack animations
    // This should be placed during the frames where the final attack actually hits.
    public void EnableAttackHitbox() // This is for the final attack (BiteLeft/Right trigger)
    {
        Debug.Log("Rhino final attack collider enabled");
        if (wasMovingRight)
        {
            if (biteRight != null) biteRight.enabled = true;
        }
        else
        {
            if (biteLeft != null) biteLeft.enabled = true;
        }
        // Disable main collider during the active frames of the final attack
        if (mainCollider != null) mainCollider.enabled = false;
    }

    // This method will be called by an Animation Event when the final attack animation finishes
    public void EndAttackAnimation()
    {
        isAttacking = false;

        // Disable all attack colliders
        if (biteLeft != null) biteLeft.enabled = false;
        if (biteRight != null) biteRight.enabled = false;
        // Make sure walking attack colliders are also off after the final attack,
        // in case they were still on due to animation timing issues.
        if (WalkingAttackLeft != null) WalkingAttackLeft.enabled = false;
        if (WalkingAttackRight != null) WalkingAttackRight.enabled = false;

        // Re-enable main collider
        if (mainCollider != null) mainCollider.enabled = true;

        // After the final attack, decide what to do next
        if (player != null && Vector2.Distance(transform.position, player.position) < loseTargetDistance)
        {
            currentState = RhinoState.Chase; // Restart chasing if player is still within range
        }
        else
        {
            currentState = RhinoState.Wander; // Wander if player got too far or is null
        }

        // Reset animation booleans related to movement/attack ending
        animator.SetBool("isWalking", false); // Ensure walking animation stops initially
         // If you have an "IsAttacking" bool, set it to false here as well
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Rhino detected collider collision with: " + other.name);

        if (other.CompareTag("Player"))
        {
             // Debug.Log("Rhino hit Player");
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                float damageToDeal = 0f; // Start with no damage

                // Check which Rhinos collider is currently active
                if ((biteLeft != null && biteLeft.enabled) || (biteRight != null && biteRight.enabled))
                {
                    damageToDeal = 1.0f; // Higher damage for the final attack (bite/horn stab)
                     // Debug.Log("Rhino final attack hit Player");
                }
                else if ((WalkingAttackLeft != null && WalkingAttackLeft.enabled) || (WalkingAttackRight != null && WalkingAttackRight.enabled))
                {
                    damageToDeal = 0.3f; // Lower damage for walking attacks (horn swipe)
                    // Debug.Log("Rhino walking attack hit Player");
                }
                 // You could add a check here for the main collider potentially dealing damage if the player just runs into the rhino's body.

                if (damageToDeal > 0f)
                {
                    playerHealth.TakeDamage(damageToDeal);
                    Debug.Log("Damage dealt to " + other.name + " from Rhino (" + damageToDeal + ")");
                }
            }

            // Apply knockback if the player has a GavinPlayerController
            GavinPlayerController playerController = other.gameObject.GetComponent<GavinPlayerController>();
            if (playerController != null)
            {
                 float knockbackForce = 0f; // Start with no knockback

                 if (currentState == RhinoState.Attack && ((biteLeft != null && biteLeft.enabled) || (biteRight != null && biteRight.enabled)))
                 {
                     knockbackForce = 15000.0f; // Highest knockback for the final attack
                     // Debug.Log("Rhino final attack caused knockback");
                 }
                 else if ((WalkingAttackLeft != null && WalkingAttackLeft.enabled) || (WalkingAttackRight != null && WalkingAttackRight.enabled))
                 {
                      knockbackForce = 7000.0f; // Moderate knockback for walking attacks
                       // Debug.Log("Rhino walking attack caused knockback");
                 }
                 // You could add knockback if the player just runs into the rhino's body during chase/wander.
                 // else if (currentState == RhinoState.Chase && mainCollider != null && mainCollider.enabled) // Example check
                 // {
                 //     knockbackForce = 3000.0f; // Small nudge when colliding with body while chasing
                 // }


                if (knockbackForce > 0f)
                {
                    playerController.ApplyKnockback(knockbackForce, (transform.position - other.transform.position).normalized);
                    // Debug.Log("Applied " + knockbackForce + " knockback to Player");
                }
            }
        }
    }
}
