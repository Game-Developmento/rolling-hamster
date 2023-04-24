using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardHandler : MonoBehaviour
{

    [SerializeField] public Rigidbody2D rb;
    [Tooltip("We will check if the rigid body is touching this collider!")]
    [SerializeField] public Collider2D col;

    [SerializeField] float forceAmount = 5f;

    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] float slowDownAtJump = 0.5f;
    [SerializeField] InputAction jump;
    [SerializeField] InputAction horizontal;
    private bool playerWantsToJump = false;
    private void OnValidate()
    {
        if (jump == null)
            jump = new InputAction(type: InputActionType.Button);
        if (jump.bindings.Count == 0)
            jump.AddBinding("<Keyboard>/space");

        if (horizontal == null)
            horizontal = new InputAction(type: InputActionType.Button);
        if (horizontal.bindings.Count == 0)
            horizontal.AddCompositeBinding("1DAxis")
                .With("Positive", "<Keyboard>/rightArrow")
                .With("Negative", "<Keyboard>/leftArrow");

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (jump.WasPressedThisFrame())
        {
            playerWantsToJump = true;
        }
    }
    private void OnEnable()
    {
        horizontal.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        horizontal.Disable();
        jump.Disable();
    }

    private void FixedUpdate()
    {
        if (rb.IsTouching(col))
        {
            float xPos = horizontal.ReadValue<float>();
            rb.AddForce(new Vector2(xPos * forceAmount, 0), ForceMode2D.Force);
            if (playerWantsToJump)
            {
                rb.velocity = new Vector2(rb.velocity.x * slowDownAtJump, rb.velocity.y);
                rb.AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse);
                playerWantsToJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Platform")
        {
            Debug.Log("Touching platform!");
        }


    }
}
