using UnityEngine;
using System.Collections;

public class HillSpawner : MonoBehaviour {

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 4f;
    public int hillcounter;
    public GameObject hillPrefab;
    
    //2    
    void Start()
    {
        Invoke("SpawnHill", minSpawnTime);
    }

    //3
    void SpawnHill()
    {
        // 1
        Camera camera = Camera.main;
        Vector3 cameraPos = camera.transform.position;
        float xMax = camera.aspect * camera.orthographicSize;
        float xRange = camera.aspect * camera.orthographicSize * 1.75f;
        float yMax = camera.orthographicSize - 0.5f;

        // 2
        Vector3 hillPos =
            new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax),
                        Random.Range(-yMax, yMax),
                        hillPrefab.transform.position.z);

        // 3
        if (hillcounter < 3)
        {
            Instantiate(hillPrefab, hillPos, Quaternion.identity);
            Invoke("SpawnHill", Random.Range(minSpawnTime, maxSpawnTime));
            //hillcounter++;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
