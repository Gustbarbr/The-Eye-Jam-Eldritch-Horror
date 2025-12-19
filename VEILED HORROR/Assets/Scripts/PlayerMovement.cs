using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    [Header("Tutorial")]
    public TextMeshProUGUI tutorialText;
    [SerializeField] private float startShowTutorialTime;
    [SerializeField] private float endShowTutorialTime;

    [Header("Meters")]
    public int meters;
    public TextMeshProUGUI metersText;
    [SerializeField] private float startMetersCooldownTime;
    [SerializeField] private float endMetersCooldownTime;

    [Header("Sanity")]
    public int sanity;
    public TextMeshProUGUI sanityText;

    [Header("Eyes")]
    [SerializeField] private GameObject bigEye;
    [SerializeField] private float startShowEyeTime;
    [SerializeField] private float endShowEyeTime;
    [SerializeField] private List<GameObject> eyeList = new List<GameObject>();

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    float horizonatlMovement;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

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
            meters -= 1;
        }

        if (startShowTutorialTime < endShowTutorialTime)
        {
            startShowTutorialTime += Time.deltaTime;
            tutorialText.enabled = true;
        }

        else if (startShowTutorialTime >= endShowTutorialTime)
            tutorialText.enabled = false;

        sanityText.text = "SANITY: " + sanity.ToString() + "%";

        metersText.text = "METERS: " + meters.ToString() + "m";

        if(sanity <= 75)
        {
            for (int i = 0; i < eyeList.Count/2; i++)
            {
                eyeList[i].SetActive(true);
            } 
        }

        if (sanity <= 25)
        {
            for (int i = eyeList.Count / 2; i < eyeList.Count; i++)
            {
                eyeList[i].SetActive(true);
            }
        }

        if (sanity <= 0)
        {
            if (startShowEyeTime < endShowEyeTime)
            {
                bigEye.SetActive(true);
                startShowEyeTime += Time.deltaTime;
            }

            else if(startShowEyeTime >= endShowEyeTime) 
                SceneManager.LoadScene("Menu");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizonatlMovement = context.ReadValue<Vector2>().x;
    }
}
