using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    public float sprintSpeed = 8f;
    
    [Header("Interaction")]
    public float interactionRange = 2f;
    public LayerMask interactableLayer;
    
    [Header("Animation")]
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isSprinting = false;
    private GameObject currentInteractable;
    
    private InputSystem_Actions controls;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Enable();
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
        controls.Player.Interact.performed += OnInteract;
        controls.Player.Sprint.performed += ctx => isSprinting = true;
        controls.Player.Sprint.canceled += ctx => isSprinting = false;
    }

    void OnDisable()
    {
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;
        controls.Player.Interact.performed -= OnInteract;
        controls.Player.Sprint.performed -= ctx => isSprinting = true;
        controls.Player.Sprint.canceled -= ctx => isSprinting = false;
        controls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        HandleInput();
        HandleInteraction();
    }
    
    void FixedUpdate()
    {
        HandleMovement();
    }
    
    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Player Interact pressed!");
        if (currentInteractable != null)
        {
            IInteractable interactable = currentInteractable.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    void HandleInput()
    {
        // Get movement input
        // moveInput.x = Input.GetAxisRaw("Horizontal");
        // moveInput.y = Input.GetAxisRaw("Vertical");
        // moveInput = moveInput.normalized;
        
        // Sprint input
        // isSprinting = Input.GetKey(KeyCode.LeftShift);
        
        // Interaction input
        // if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        // {
        //     currentInteractable.Interact();
        // }
    }
    
    void HandleMovement()
    {
        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        Vector2 movement = moveInput * currentSpeed;
        
        rb.linearVelocity = movement;
        
        // Update animations
        if (animator != null)
        {
            animator.SetBool("IsMoving", moveInput.magnitude > 0.1f);
            animator.SetBool("IsSprinting", isSprinting && moveInput.magnitude > 0.1f);
        }
        
        // Flip sprite based on movement direction
        if (moveInput.x != 0 && spriteRenderer != null)
        {
            spriteRenderer.flipX = moveInput.x < 0;
        }
    }
    
    void HandleInteraction()
    {
        // Find interactable objects in range
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer);
        
        GameObject closestInteractable = null;
        float closestDistance = float.MaxValue;
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<IInteractable>() != null)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = collider.gameObject;
                }
            }
        }
        
        // Update current interactable
        if (currentInteractable != closestInteractable)
        {
            if (currentInteractable != null)
            {
                IInteractable oldInteractable = currentInteractable.GetComponent<IInteractable>();
                if (oldInteractable != null)
                    oldInteractable.OnInteractionExit();
            }
            
            currentInteractable = closestInteractable;
            Debug.Log("Current interactable set to: " + currentInteractable?.name);
            
            if (currentInteractable != null)
            {
                IInteractable newInteractable = currentInteractable.GetComponent<IInteractable>();
                if (newInteractable != null)
                    newInteractable.OnInteractionEnter();
            }
        }
    }
    
    void InteractWithObject()
    {
        if (currentInteractable != null)
        {
            IInteractable interactable = currentInteractable.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw interaction range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}

public interface IInteractable
{
    void Interact();
    void OnInteractionEnter();
    void OnInteractionExit();
} 