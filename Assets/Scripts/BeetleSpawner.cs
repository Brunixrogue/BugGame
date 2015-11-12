using UnityEngine;
using System.Collections;

/*
Beetles will have an hp value and should not die to 1 click like the ants
Move slower than ants, do more damage to the goal than ants
Don't spawn from anthills. 

Beetles will burrow up from the ground around the map

Effects: Red warning flash when they spawn + alarm sound
Psuedo boss or boss wave


Edge of screen code snippets can be found in the Zombie Conga tutorial when controlling the enemy
*/

public class BeetleSpawner : MonoBehaviour {

	public enum ScreenEdge {LEFT, RIGHT, TOP, BOTTOM};
	public ScreenEdge screenEdge;
	public float yOffset;
	public float xOffset;

	public float minSpawnTime = 2f;
	public float maxSpawnTime = 4f;

	public Transform Cube;
	public GameObject beetlePrefab;

	private bool isTop;






	void Start() {

		Invoke("moveSpawn", minSpawnTime);


	}


	//Moves the spawner to a random edge of the screen and Instantiates a Beetle Spawn.
	void moveSpawn () {
	
		Vector3 newPosition = transform.position;
		Camera camera = Camera.main;

		ScreenEdge screenEdge = (ScreenEdge)Random.Range (0, 4);

		// 2
		switch (screenEdge) {
		// 3
		case ScreenEdge.RIGHT:
			newPosition.x = camera.aspect * camera.orthographicSize + xOffset;
			newPosition.y = yOffset;
			isTop = false;
			break;
			
		// 4
		case ScreenEdge.TOP:
			newPosition.y = camera.orthographicSize + yOffset;
			newPosition.x = xOffset;
			isTop = true;
			break;
		
		case ScreenEdge.LEFT:
			newPosition.x = -camera.aspect * camera.orthographicSize + xOffset;
			newPosition.y = yOffset;
			isTop = false;
			break;
		
		case ScreenEdge.BOTTOM:
			newPosition.y = -camera.orthographicSize + yOffset;
			newPosition.x = xOffset;
			isTop = true;
			break;
		}
			// 5
		transform.position = newPosition;
		spawnBeetle ();

		Invoke("moveSpawn", Random.Range(minSpawnTime, maxSpawnTime));



	}


	//Spawns an object at the spawner with a random x or y range depending on the edge of the screen.
	void spawnBeetle ()
	{
		float yMax = Camera.main.orthographicSize;
		float xMax = Camera.main.aspect * Camera.main.orthographicSize;
			

		Vector3 beetlePosLeftRight = 
			new Vector3 (Cube.position.x,
			             Random.Range (-yMax, yMax),
			             transform.position.z);

		Vector3 beetlePosTopBottom = 
			new Vector3 (Random.Range (-xMax, xMax),
			             Cube.position.y,
			             transform.position.z);
		if (isTop == true) {
			Instantiate (beetlePrefab, beetlePosTopBottom, Quaternion.identity);
		}
		else if (isTop == false) {
			Instantiate (beetlePrefab, beetlePosLeftRight, Quaternion.identity);

		}

	}






	void Update () {
	
	}




}
