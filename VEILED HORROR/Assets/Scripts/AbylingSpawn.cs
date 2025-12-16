using Unity.VisualScripting;
using UnityEngine;

public class AbylingSpawn : MonoBehaviour
{
    [SerializeField] private GameObject abylingPrefab;
    [SerializeField] private float startTime;
    [SerializeField] private float endTime;

    private void Update()
    {
        if(startTime < endTime)
            startTime += Time.deltaTime;
        
        if(startTime >= endTime)
        {
            GameObject abyling = Instantiate(abylingPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            startTime = 0f;
        }
    }
}
