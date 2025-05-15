using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantController : MonoBehaviour
{
    public enum ElephantState
    {
        Idle,
        Wander,
        Chase,
        Attack
    }
    private ElephantState currentState = ElephantState.Idle;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Collider2D biteLeft;
    [SerializeField] private Collider2D biteRight;
    [SerializeField] private Collider2D colliderLeft;
    [SerializeField] private Collider2D colliderRight;
    [SerializeField] private CapsuleCollider2D mainCollider;

    [SerializeField] private float idleDuration = 3f; // Slightly longer idle for an elephant
    [SerializeField] private float wanderDuration = 5f; // Slightly longer wander for an elephant
    [SerializeField] private Transform player; // Drag your player object here in the inspector
    [SerializeField] private float chaseDistance = 7f; // Distance to start chasing
    [SerializeField] private float attackDistance = 2.5f; // Distance to start attacking (larger for elephant)
    [SerializeField] private float loseTargetDistance = 10f; // Distance to stop chasing

    private float idleTimer;
    private float wanderTimer;
    private Vector2 wanderDirection;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private bool wasMovingRight; // Used for attack direction

    private bool isAttacking = false; // New flag to track if attacking

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mainCollider = GetComponent<CapsuleCollider2D>();

        if (biteLeft != null)
        {
            biteLeft.enabled = false;
            Debug.Log("Elephant: Bite Left Collider disabled on Awake.");
        }
        if (biteRight != null)
        {
            biteRight.enabled = false;
            Debug.Log("Elephant: Bite Right Collider disabled on Awake.");
        }
         if (colliderLeft != null)
        {
            colliderLeft.enabled = false;
            Debug.Log("Elephant: Collider Left disabled on Awake.");
        }
        if (colliderRight != null)
        {
            colliderRight.enabled = false;
            Debug.Log("Elephant: Collider Right disabled on Awake.");
        }
        if (mainCollider != null)
        {
            mainCollider.enabled = true; // Main collider should be enabled initially
        }


        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogWarning("ElephantController: Player GameObject not found. Please tag your player as 'Player'.");
            }
        }
    }

    private void Update()
    {
        HandleState();
    }

    public void HandleState()
    {
        // Check for player within chase distance regardless of current state (except attack)
        if (!isAttacking && player != null && Vector2.Distance(transform.position, player.position) < chaseDistance)
        {
            currentState = ElephantState.Chase;
        }

        switch (currentState)
        {
            case ElephantState.Idle:
                HandleIdle();
                break;
            case ElephantState.Wander:
                HandleWander();
                break;
            case ElephantState.Chase:
                HandleChase();
                break;
            case ElephantState.Attack:
                HandleAttack();
                break;
        }
    }

    public void HandleIdle()
    {
        movement = Vector2.zero;
        SetAnimationDirection(Vector2.zero);
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            currentState = ElephantState.Wander;
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
            if (Random.Range(0, 4) == 3) {
                currentState = ElephantState.Idle;
                wanderTimer = 0f; // Reset timer for next wander phase
                return;
            }
            wanderTimer = 0f;
        }

        movement = wanderDirection;
        SetAnimationDirection(movement);
    }

    public void HandleChase()
    {
        if(player == null) { // Fallback if player somehow becomes null
            currentState = ElephantState.Wander;
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > loseTargetDistance)
        {
            currentState = ElephantState.Wander;
            return;
        }
        if (distanceToPlayer < attackDistance && !isAttacking) // Only try to attack if not already attacking
        {
            currentState = ElephantState.Attack;
            TriggerAttack();
            return; // Exit chase logic to handle attack state
        }

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        movement = directionToPlayer;
        SetAnimationDirection(movement);
    }

    public void HandleAttack()
    {
        movement = Vector2.zero; // Stop moving during attack
        // The actual attack logic is handled in TriggerAttack and animation events
    }

    private void SetAnimationDirection(Vector2 moveVector)
    {
        if (moveVector.magnitude > 0.1f)
        {
            if (moveVector.x > 0.1f)
            {
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", true);
                wasMovingRight = true;
            }
            else if (moveVector.x < -0.1f)
            {
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                wasMovingRight = false;
            }
            // For purely vertical movement, maintain last horizontal direction for animation
            else if (Mathf.Abs(moveVector.y) > 0.1f)
            {
                 animator.SetBool("isLeft", !wasMovingRight);
                 animator.SetBool("isRight", wasMovingRight);
            }
        }
        else
        {
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
        }
    }


    private void FixedUpdate()
    {
        // Only move if not attacking and in Wander or Chase states
        if (!isAttacking && (currentState == ElephantState.Wander || currentState == ElephantState.Chase))
        {
            Move();
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void TriggerAttack()
    {
        if (!isAttacking) // Prevent spamming attack
        {
            isAttacking = true;

            // Determine attack direction based on player's position
            bool attackRight = player.position.x > transform.position.x;

            // Disable main collider and enable appropriate attack collider
            if (mainCollider != null) mainCollider.enabled = false;

            if (colliderLeft != null) colliderLeft.enabled = false;
            if (colliderRight != null) colliderRight.enabled = false;


            // Trigger the appropriate attack animation and enable the correct collider
            if (attackRight)
            {
                 if (colliderRight != null) colliderRight.enabled = true;
                animator.SetTrigger("BiteRight"); // Assumes you have "BiteRight" trigger
                // Set animation parameters to face right during attack
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", true);
                wasMovingRight = true; // Keep track of direction
            }
            else
            {
                if (colliderLeft != null) colliderLeft.enabled = true;
                animator.SetTrigger("BiteLeft"); // Assumes you have "BiteLeft" trigger
                // Set animation parameters to face left during attack
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                wasMovingRight = false; // Keep track of direction
            }
        }
    }

     // This method will be called by an Animation Event during the attack animation to enable the actual damage hitbox
     // Make sure you add Animation Events to your attack animations in the Unity Animator window
    public void EnableAttackHitbox()
    {
       if (wasMovingRight == true){
           if(biteRight != null) biteRight.enabled = true;
        }
        else {
            if(biteLeft != null) biteLeft.enabled = true;
        }
    }

    // This method will be called by an Animation Event when the attack animation finishes
    // Make sure you add an Animation Event at the end of your attack animations
    public void EndAttackAnimation()
    {
        isAttacking = false;

        // Disable all attack colliders and re-enable main collider
        if (biteLeft != null) biteLeft.enabled = false;
        if (biteRight != null) biteRight.enabled = false;
        if (colliderLeft != null) colliderLeft.enabled = false;
        if (colliderRight != null) colliderRight.enabled = false;
        if (mainCollider != null) mainCollider.enabled = true;

        // After attacking, decide what to do next
        if (player != null && Vector2.Distance(transform.position, player.position) < loseTargetDistance)
        {
            currentState = ElephantState.Chase; // Continue chasing if player is still within range
        }
        else
        {
            currentState = ElephantState.Wander; // Wander if player got too far or is null
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Elephant detected collider");

        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(.5f); // Adjust damage as needed
                Debug.Log("Damage dealt to " + other.name + " from Elephant bite.");
            }

            // Apply knockback if the player has a GavinPlayerController
            GavinPlayerController playerController = other.gameObject.GetComponent<GavinPlayerController>();
            if (playerController != null)
            {
                // Adjust knockback force as needed
                playerController.ApplyKnockback(9000.0f, (transform.position - other.transform.position).normalized);
            }
        }
    }
}
