using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyenaController : MonoBehaviour
{
    public enum HyenaState
    {
        Idle,
        Wander,
        Chase,
        Attack
    }
    private HyenaState currentState = HyenaState.Idle;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float wanderMoveSpeedPercentage = .3f;
    [SerializeField] private Collider2D biteLeft;
    [SerializeField] private Collider2D biteRight;
    [SerializeField] private float idleDuration = 2f;
    [SerializeField] private float wanderDuration = 3f;
    [SerializeField] private Transform player; // Drag your player object here in the inspector
    [SerializeField] private float chaseDistance = 5f; // Distance to start chasing
    [SerializeField] private float attackDistance = 1.7f; // Distance to start attacking
    [SerializeField] private float loseTargetDistance = 8f; // Distance to stop chasing

    private float idleTimer;
    private float wanderTimer;
    private Vector2 wanderDirection;
    private HyenaControls HyenaControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    private float directionChangeBuffer = .1f;
    private float lastDirectionChangeTime;
    private bool wasMovingRight;

    private bool isAttacking = false; // New flag to track if attacking

    // Add a reference to the attack action
    private UnityEngine.InputSystem.InputAction attackAction;

    private void Awake() {
        HyenaControls = new HyenaControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Find the attack action in your HyenaControls
        attackAction = HyenaControls.Movement.attack; // Assuming "attack" is in the "Movement" action map
        if (biteLeft != null)
        {
            biteLeft.enabled = false;
            Debug.Log("Parent: Spear Tip Collider disabled on Awake.");
        }
        if (biteRight != null)
        {
            biteRight.enabled = false;
            Debug.Log("Parent: Spear Tip Collider disabled on Awake.");
        }
        if (player == null) {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogWarning("HyenaController: Player GameObject not found. Please tag your player as 'Player'.");
            }
        }
    }

    private void Update() {
        HandleState();
    }

    public void HandleState() {
        switch (currentState) {
            case HyenaState.Idle:
                HandleIdle();
                break;
            case HyenaState.Wander:
                HandleWander();
                break;
            case HyenaState.Chase:
                HandleChase();
                break;
            case HyenaState.Attack:
                HandleAttack();
                break;
        }
    }

    public void HandleIdle() {
        movement = Vector2.zero;
        SetAnimationDirection(Vector2.zero);
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration) {
            currentState = HyenaState.Wander;
            idleTimer = 0f;
        }
    }
    
    public void HandleWander() {
        if (Vector2.Distance(transform.position, player.position) < chaseDistance) {
            currentState = HyenaState.Chase;
            return;
        }
        wanderTimer += Time.deltaTime;
        if (wanderTimer >= wanderDuration)
        {
            wanderDirection = Random.insideUnitCircle.normalized * wanderMoveSpeedPercentage;
            wanderTimer = 0f;
            if (Random.Range(0, 5) == 4) {
                currentState = HyenaState.Idle;
                return;
            }       
        }

        movement = wanderDirection;
        SetAnimationDirection(movement);
    }
    
    public void HandleChase() {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position); 
        if (distanceToPlayer > loseTargetDistance) {
            currentState = HyenaState.Wander;
            return;
        }
        if (distanceToPlayer < attackDistance) {
            currentState = HyenaState.Attack;
            TriggerAttack();
            return; // Exit chase logic to handle attack state
        }
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        movement = directionToPlayer;
        SetAnimationDirection(movement);
    }

    public void HandleAttack() {
        movement = Vector2.zero;
    }

    private void SetAnimationDirection(Vector2 moveVector)
    {
        if (moveVector.magnitude > 0.1f)
        {
            if (moveVector.x > 0.1f)
            {
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", true);
                wasMovingRight = true; // Still track direction for attack
            }
            else if (moveVector.x < -0.1f)
            {
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                wasMovingRight = false; // Still track direction for attack
            }
        }
        else
        {
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
        }
    }

    private void FixedUpdate() {
        if (!isAttacking && (currentState == HyenaState.Wander || currentState == HyenaState.Chase))
        {
            Move();
        }
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    // New method to handle the attack action

    private void TriggerAttack() {
        if (!isAttacking) // Prevent spamming attack
        {
            isAttacking = true;

            // Determine attack direction based on player's position
            bool attackRight = player.position.x > transform.position.x;

            // Trigger the appropriate attack animation and enable the correct collider
            if (attackRight)
            {
                biteRight.enabled = true;
                biteLeft.enabled = false; // Make sure the other collider is off
                animator.SetTrigger("BiteRight");
                // Set animation parameters to face right during attack
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", true);
            }
            else
            {
                biteLeft.enabled = true;
                biteRight.enabled = false; // Make sure the other collider is off
                animator.SetTrigger("BiteLeft");
                 // Set animation parameters to face left during attack
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
            }

            // Even though movement is zero, we should still orient the hyena
            // based on the attack direction. We already did this above.
        }
    }

    // This method will be called by an Animation Event when the attack animation finishes
    public void EndAttackAnimation()
    {
        isAttacking = false;
        biteLeft.enabled = false;
        biteRight.enabled = false;

        // After attacking, decide what to do next
        if (player != null && Vector2.Distance(transform.position, player.position) < loseTargetDistance)
        {
            currentState = HyenaState.Chase; // Continue chasing if player is still within range
        }
        else
        {
            currentState = HyenaState.Wander; // Wander if player got too far
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hyena detected collider");
        if (other.CompareTag("Player")){
            Health enemyHealth = other.GetComponent<Health>();
            enemyHealth.TakeDamage(.5f);
            Debug.Log("Damage dealt to " + other.name);
        }
    }
}
