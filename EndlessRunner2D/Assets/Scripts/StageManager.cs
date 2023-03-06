using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
	
	[Header("Floor")]
	[SerializeField] GameObject[] floorTilePrefabs;
	[SerializeField] Transform realFloor, floorParent, firstTile;
	
	[Header("Stacks")]
	[SerializeField] GameObject cubePrefab;
	[SerializeField] Transform cubesParent;
	[SerializeField] float firstStackPositionX, distanceBetweenStacks, bottomCubePositionY, cubeHeight;
	
	[Header("Other")]
	[SerializeField] float cameraOffset;
	
	
	Camera gameCamera;
	Player player;
	
	int generatedTiles;
	Vector2 firstTilePosition;
	float floorTileWidth;
	int floorTileIndex;
	
	int generatedStacks;
	
    void Start()
    {
	    gameCamera = FindObjectOfType<Camera>();
	    player = FindObjectOfType<Player>();
	    
	    generatedTiles = 4;
	    firstTilePosition = firstTile.position;
	    floorTileWidth = 2;
    }

    // Update is called once per frame
    void Update()
    {
	    MoveCamera();
	    MoveFloor();
	    AddFloorTiles();
	    AddCubeStack();
    }
    
	void MoveCamera()
	{
		gameCamera.transform.position = new Vector3(player.transform.position.x + cameraOffset, gameCamera.transform.position.y, gameCamera.transform.position.z); 
		
	}
	
	void MoveFloor()
	{
		realFloor.position = new Vector2(gameCamera.transform.position.x, realFloor.position.y);
	}
	
	void AddFloorTiles()
	{
		if(player.transform.position.x + 10 > generatedTiles*floorTileWidth)
		{
			Vector2 tilePosition = new Vector2(firstTilePosition.x + (generatedTiles*floorTileWidth),firstTilePosition.y);
			GameObject newTile = Instantiate(floorTilePrefabs[floorTileIndex],tilePosition,Quaternion.identity);
			newTile.transform.SetParent(floorParent);
			generatedTiles++;
		
			floorTileIndex = floorTileIndex == 0 ? 1:0;
		}
		
	}
	void AddCubeStack()
	{
		if(player.transform.position.x+10 > firstStackPositionX + (generatedStacks * distanceBetweenStacks))
		{
			float stackPositionX = firstStackPositionX + (generatedStacks);
			GameObject  Cube1, Cube2, Cube3, Cube4, Cube5;
			Cube1 = NewCube(stackPositionX, bottomCubePositionY + (cubeHeight * 4));
			Cube2 = NewCube(stackPositionX, bottomCubePositionY + (cubeHeight * 3));
			Cube3 = NewCube(stackPositionX, bottomCubePositionY + (cubeHeight * 2));
			Cube4 = NewCube(stackPositionX,bottomCubePositionY + cubeHeight);
			Cube5 = NewCube(stackPositionX, bottomCubePositionY);
			generatedStacks++;
			
			int randomNumber = Random.Range(1,5);
			if(randomNumber ==1)
			{
				SetObjectGravity(Cube1);
				Destroy(Cube2);
				Destroy(Cube3);
			}
			else if(randomNumber ==2)
			{
				SetObjectGravity(Cube1);
				SetObjectGravity(Cube2);
				Destroy(Cube3);
				Destroy(Cube4);
			}
			else if(randomNumber ==3)
			{
				SetObjectGravity(Cube1);
				SetObjectGravity(Cube2);
				SetObjectGravity(Cube3);
				Destroy(Cube4);
				Destroy(Cube5);
			}
			else if(randomNumber ==4)
			{
				Destroy(Cube5);
			}
			
		}
		
		
	}
	
	GameObject NewCube(float positionX, float positionY)
	{
		GameObject newCube = Instantiate(cubePrefab, new Vector2(positionX, positionY),Quaternion.identity );
		newCube.transform.SetParent(cubesParent);
		return newCube;
	}
	
	void SetObjectGravity(GameObject objectWithRigidbody, float gravityScale = 0)
	{
		objectWithRigidbody.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
	}
}

