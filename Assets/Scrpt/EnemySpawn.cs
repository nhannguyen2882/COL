using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawn : MonoBehaviour
{
	public GameObject[] spawnEnemy;
	public int spawnRate = 5;
	public int startX = -180, endX = 10;
	public int startY = 0, endY = 7;
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
	void Update(){

	}
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		 if(collider.gameObject.name== "Player" && !isSpawn)
		 {
			Debug.Log("Trigger");
			
            System.Random random = new System.Random();
			int indexEnemy;
			int x, y;
			Vector3 position;
			for (int i =0;i<spawnRate;i++)
            {
				indexEnemy = Random.Range(0, spawnEnemy.Length);
				x = Random.Range(startX, endX);
				y = Random.Range(startY, endY);
				position = new Vector3(x, y, 0);
				while (availablePlaces.Contains(position))
				{
					x = Random.Range(startX, endX);
					y = Random.Range(startY, endY);
					position = new Vector3(x, y, 0);
				}
				Debug.Log(position.ToString());
				Instantiate(spawnEnemy[indexEnemy], new Vector2(position.x,position.y)
						 ,
						 Quaternion.identity);
			}
			isSpawn = true;
		 }
		 //spawnenemy.LookAtTarget=gameObject;
		 //Debug.Log("SPAWN ENEMIES!");
	}
}
