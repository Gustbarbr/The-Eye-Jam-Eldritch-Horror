using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    float horizonatlMovement;

    void Update()
    {
        rb.linearVelocity = new Vector2(horizonatlMovement * moveSpeed, rb.linearVelocity.y);
        if (horizonatlMovement > 0)
            transform.localScale = new Vector2(1, 1);
        else if (horizonatlMovement < 0)
            transform.localScale = new Vector2(-1, 1);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizonatlMovement = context.ReadValue<Vector2>().x;
    }
}
