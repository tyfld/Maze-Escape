using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Déplacement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;


    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Vector2 moveInput;
    private bool jumpQueued;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        //Vérifier si le perso est au sol
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Gestion de saut
        if (jumpQueued && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            jumpQueued = false;
        }

        // Appliquer la gravité
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        print("Je me déplace de : " + moveInput);
        Debug.Log("Test");
        Debug.LogError("Error");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            jumpQueued = true;
            print("Je veux sauter");
        }

    }
}

