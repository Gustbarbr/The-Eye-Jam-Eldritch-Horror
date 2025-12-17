using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Sanity")]
    public int sanity;
    public TextMeshProUGUI sanityText;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    float horizonatlMovement;

    void Update()
    {
        rb.linearVelocity = new Vector2(horizonatlMovement * moveSpeed, rb.linearVelocity.y);
        if (horizonatlMovement > 0)
            transform.localScale = new Vector2(3, 3);
        else if (horizonatlMovement < 0)
            transform.localScale = new Vector2(-3, 3);

        if (transform.position.x < -1.45f)
            transform.position = new Vector2(-1.45f, -0.5f);
        if (transform.position.x > 1.45f)
            transform.position = new Vector2(1.45f, -0.5f);

        sanityText.text = "SANITY: " + sanity.ToString() + "%";
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizonatlMovement = context.ReadValue<Vector2>().x;
    }
}
