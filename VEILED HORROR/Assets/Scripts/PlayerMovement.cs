using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Meters")]
    public int meters;
    public TextMeshProUGUI metersText;
    [SerializeField] private float startMetersCooldownTime;
    [SerializeField] private float endMetersCooldownTime;

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

        if (startMetersCooldownTime < endMetersCooldownTime)
            startMetersCooldownTime += Time.deltaTime;
        else if(startMetersCooldownTime >= endMetersCooldownTime)
        {
            startMetersCooldownTime = 0;
            meters += 1;
        }

        sanityText.text = "SANITY: " + sanity.ToString() + "%";

        metersText.text = "METERS: " + meters.ToString() + "m";

        if (sanity <= 0)
            SceneManager.LoadScene("Menu");
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizonatlMovement = context.ReadValue<Vector2>().x;
    }
}
