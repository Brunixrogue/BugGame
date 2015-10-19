using UnityEngine;
using System.Collections;

public class BugSpawner : MonoBehaviour {

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    public Transform hill;
    public GameObject bugPrefab;
    // Use this for initialization
    void Start()
    {
        Invoke("SpawnBug", minSpawnTime);
    }

    void SpawnBug()
    {
        /*Camera camera = Camera.main;
        Vector3 cameraPos = camera.transform.position;
        float xMax = camera.aspect * camera.orthographicSize;
        float xRange = camera.aspect * camera.orthographicSize * 1.75f;
        float yMax = camera.orthographicSize - 0.5f;

        // 2
        Vector3 bugPos =
            new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax),
                        Random.Range(-yMax, yMax),
                        bugPrefab.transform.position.z);
                        */

        // 3
        Instantiate(bugPrefab, hill.position, Quaternion.identity);

        Invoke("SpawnBug", Random.Range(minSpawnTime, maxSpawnTime));




    }

    // Update is called once per frame
    void Update () {
	
	}
}
