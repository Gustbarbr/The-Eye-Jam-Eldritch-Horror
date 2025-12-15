using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AbylingControl : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Rotation")]
    [SerializeField] private Transform diveBell;
    [SerializeField] private float rotationSpeed;
    private float rotationOffset;

    [Header("Spawn")]
    [SerializeField] private GameObject spawnPointA;
    [SerializeField] private GameObject spawnPointB;
    [SerializeField] private List<GameObject> spawnList = new List<GameObject>();
    private GameObject chosenPoint;

    private void Start()
    {
        if(!spawnList.Contains(spawnPointA))
            spawnList.Add(spawnPointA);
        if (!spawnList.Contains(spawnPointB))
            spawnList.Add(spawnPointB);

        ChooseSpawnPoint();
    }

    private void Update()
    {
        RotateAbyling();

        float moveSpeed = speed * Time.deltaTime;
        if(Vector2.Distance(transform.position, diveBell.position) > 3f)
            transform.position = Vector2.MoveTowards(transform.position, diveBell.position, moveSpeed);
    }

    private void ChooseSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnList.Count);
        chosenPoint = spawnList[randomIndex];
        transform.position = chosenPoint.transform.position;
    }

    private void RotateAbyling()
    {
        Vector3 direction = diveBell.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Deg2Rad;
        if (transform.position.x < 0)
            rotationOffset = -90f;
        else if (transform.position.x > 0)
            rotationOffset = 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
