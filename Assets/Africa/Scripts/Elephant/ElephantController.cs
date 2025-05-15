using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyenaController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Collider2D biteLeft;
    [SerializeField] private Collider2D biteRight;

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
    }

    private void OnEnable() {
        HyenaControls.Enable();

        // Subscribe to the attack action's performed event
        attackAction.performed += OnAttackPerformed;
    }

    private void OnDisable() {
        HyenaControls.Disable();

        // Unsubscribe from the attack action's performed event
        attackAction.performed -= OnAttackPerformed;
    }

    private void Update() {
        // Only process input if not attacking
        // Health myHealth = this.gameObject.GetComponent<Health>();
        // myHealth.TakeDamage(.01f);
        if (!isAttacking)
        {
            PlayerInput();
        }
    }

    private void FixedUpdate() {
        // Only move if not attacking
        if (!isAttacking)
        {
            Move();
        }
    }

    private void PlayerInput() {
        movement = HyenaControls.Movement.Move.ReadValue<Vector2>();
        if(movement.magnitude > 0.1f){
            if(movement.x > 0.1f){
                animator.SetBool("isLeft", false);
                animator.SetBool("isRight", true);
                wasMovingRight = true;
                lastDirectionChangeTime = Time.time;
            }else if(movement.x < -0.1f){
                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                wasMovingRight = false;
                lastDirectionChangeTime = Time.time;
            }else if(Mathf.Abs(movement.y) > 0.1f){
                if(Time.time - lastDirectionChangeTime >= directionChangeBuffer){
                    animator.SetBool("isLeft", !wasMovingRight);
                    animator.SetBool("isRight", wasMovingRight);
                }
            }
        }else if(Time.time - lastDirectionChangeTime >= directionChangeBuffer){
            animator.SetBool("isLeft", false);
            animator.SetBool("isRight", false);
        }
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    // New method to handle the attack action
    private void OnAttackPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (!isAttacking) // Prevent spamming attack
        {

            isAttacking = true;
            // Trigger the attack animation
            if (wasMovingRight == true){
                biteRight.enabled = true;
                animator.SetTrigger("BiteRight"); // Make sure you have an "Attack" trigger in your Animator
            } else {
                biteLeft.enabled = true;
                animator.SetTrigger("BiteLeft"); // Make sure you have an "Attack" trigger in your Animator
            }
           
        }
    }

    // This method will be called by an Animation Event when the attack animation finishes
    public void EndAttackAnimation()
    {
        isAttacking = false;
        // Optionally reset any animation parameters here if needed
        // e.g., animator.SetBool("IsAttacking", false); if you used a boolean
        biteLeft.enabled = false;
        biteRight.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Hyena detected collider");

        // if (other.CompareTag("Player")){
            Health enemyHealth = other.GetComponent<Health>();
            enemyHealth.TakeDamage(.5f);
            Debug.Log("Damage dealt to " + other.name);
        // }

    }
}
