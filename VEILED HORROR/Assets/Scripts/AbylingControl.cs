using System.Collections.Generic;
using UnityEngine;

public class AbylingControl : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float sanityDrainStartTime;
    [SerializeField] private float sanityDrainEndTime;

    [Header("Position")]
    [SerializeField] private float moveSpeed;

    [Header("Rotation")]
    [SerializeField] private GameObject diveBell;
    [SerializeField] private float rotationSpeed;
    private float rotationOffset;

    [Header("Spawn")]
    [SerializeField] private GameObject spawnPointA;
    [SerializeField] private GameObject spawnPointB;
    [SerializeField] private GameObject spawnPointC;
    [SerializeField] private GameObject spawnPointD;
    [SerializeField] private List<GameObject> spawnList = new List<GameObject>();
    private GameObject chosenPoint;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        diveBell = GameObject.Find("Dive Bell");
        spawnPointA = GameObject.Find("Abyling Spawn Point A");
        spawnPointB = GameObject.Find("Abyling Spawn Point B");
        spawnPointC = GameObject.Find("Abyling Spawn Point C");
        spawnPointD = GameObject.Find("Abyling Spawn Point D");

        if (!spawnList.Contains(spawnPointA))
            spawnList.Add(spawnPointA);
        if (!spawnList.Contains(spawnPointB))
            spawnList.Add(spawnPointB);
        if (!spawnList.Contains(spawnPointC))
            spawnList.Add(spawnPointC);
        if (!spawnList.Contains(spawnPointD))
            spawnList.Add(spawnPointD);

        ChooseSpawnPoint();
    }

    private void Update()
    {
        RotateAbyling();

        if(Vector2.Distance(transform.position, diveBell.transform.position) > 3f)
            transform.position = Vector2.MoveTowards(transform.position, diveBell.transform.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, diveBell.transform.position) <= 3f)
        {
            if (sanityDrainStartTime < sanityDrainEndTime)
                sanityDrainStartTime += Time.deltaTime;
            if (sanityDrainStartTime >= sanityDrainEndTime)
            {
                player.sanity -= 5;
                sanityDrainStartTime = 0;
            }
        }
    }

    private void ChooseSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnList.Count);
        chosenPoint = spawnList[randomIndex];
        transform.position = chosenPoint.transform.position;
    }

    private void RotateAbyling()
    {
        Vector3 direction = diveBell.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Deg2Rad;
        if (transform.position.x < 0)
            rotationOffset = -90f;
        else if (transform.position.x > 0)
            rotationOffset = 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
