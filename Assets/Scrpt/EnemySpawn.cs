using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawn : MonoBehaviour
{
	public GameObject[] spawnEnemy;
	public int spawnRate = 5;
	public int startX = -180, endX = 10;
	bool isSpawn = false;
	GameObject enemy;
	public Tilemap tileMap;
	public List<Vector3> availablePlaces;
	void Start (){
		enemy = GetComponent<GameObject>();

		availablePlaces = new List<Vector3>();

		for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
		{
			for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
			{
				Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
				Vector3 place = tileMap.CellToWorld(localPlace);
				if (tileMap.HasTile(localPlace))
				{
					availablePlaces.Add(place);
				}
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		 if(collider.gameObject.name== "Player" && !isSpawn)
		 {
			Debug.Log("Trigger");
			
            System.Random random = new System.Random();
			int indexEnemy;
			for (int i =0;i<spawnRate;i++)
            {
				indexEnemy = Random.Range(0, spawnEnemy.Length);
				Vector3 position = new Vector3(Random.Range(startX, endX), Random.Range(0, 20), 0);
				while (availablePlaces.Contains(position))
				{
					position = new Vector3(Random.Range(startX, endX), Random.Range(0, 20), 0);
				}
				Instantiate(spawnEnemy[indexEnemy], position
						 ,
						 Quaternion.identity);
			}
			isSpawn = true;
		 }
		 //spawnenemy.LookAtTarget=gameObject;
		 //Debug.Log("SPAWN ENEMIES!");
	}
}
