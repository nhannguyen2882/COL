using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawn : MonoBehaviour
{
	public GameObject[] spawnEnemy;
	public int spawnRate = 5;
	public int level = 0;
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
			int startX,endX;
			if(level == 0){
				startX = -200;
				endX = -183;
				Spawn(startX,endX,spawnRate/3);
				startX = -155;
				endX = -124;
				Spawn(startX,endX,spawnRate/3);
				startX = -118;
				endX = -95;
				Spawn(startX,endX,spawnRate/3);
			}else if(level == 1){
				startX = -85;
				endX = -56;
				Spawn(startX,endX,spawnRate);
			}else if(level == 2){
				startX = -50;
				endX = 30;
				Spawn(startX,endX,spawnRate);
			}else{
				startX = 40;
				endX = 23;
				Spawn(startX,endX,spawnRate);
			}

			isSpawn = true;
		 }
		 //spawnenemy.LookAtTarget=gameObject;
		 //Debug.Log("SPAWN ENEMIES!");
	}
	void Spawn(int startX,int endX, int rate){
		System.Random random = new System.Random();
		int indexEnemy;
		int x, y;
		Vector3 position,p1,p2;
		for (int i =0;i<rate;i++)
		{
			indexEnemy = Random.Range(0, spawnEnemy.Length);
			x = Random.Range(startX, endX);
			y = Random.Range(startY, endY);
			position = new Vector3(x, y, 0);
			p1 = new Vector3(x, y - 2, 0);
			p2 = new Vector3(x, y + 2, 0);
			while (availablePlaces.Contains(position) || availablePlaces.Contains(p1) || availablePlaces.Contains(p2))
			{
				x = Random.Range(startX, endX);
				y = Random.Range(startY, endY);
				position = new Vector3(x, y, 0);
				p1 = new Vector3(x, y - 2, 0);
				p2 = new Vector3(x, y + 2, 0);
			}
			Debug.Log(position.ToString());
			Instantiate(spawnEnemy[indexEnemy], new Vector2(position.x,position.y),Quaternion.identity);
		}
	}
}
