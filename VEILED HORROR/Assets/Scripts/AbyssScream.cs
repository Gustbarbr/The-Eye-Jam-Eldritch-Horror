using UnityEngine;

public class AbyssScream : MonoBehaviour
{
    [SerializeField] private GameObject audioSource;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float startAudioSourceTime;
    [SerializeField] private float endAudioSourceTime;
    private bool firstEyesBatch = false;
    private bool secondEyesBatch = false;
    private bool finalEye = false;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if(player.sanity <= 75 && firstEyesBatch == false)
        {
            audioSource.SetActive(true);
            startAudioSourceTime += Time.deltaTime;
            if(startAudioSourceTime >= endAudioSourceTime)
            {
                audioSource.SetActive(false);
                startAudioSourceTime = 0;
                firstEyesBatch = true;
            }
        }

        if (player.sanity <= 25 && secondEyesBatch == false)
        {
            audioSource.SetActive(true);
            startAudioSourceTime += Time.deltaTime;
            if (startAudioSourceTime >= endAudioSourceTime)
            {
                audioSource.SetActive(false);
                startAudioSourceTime = 0;
                secondEyesBatch = true;
            }
        }

        if (player.sanity <= 0 && finalEye == false)
        {
            audioSource.SetActive(true);
            startAudioSourceTime += Time.deltaTime;
            if (startAudioSourceTime >= endAudioSourceTime)
            {
                audioSource.SetActive(false);
                startAudioSourceTime = 0;
                finalEye = true;
            }
        }
    }
}
