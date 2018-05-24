using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAssigner : MonoBehaviour {
	public GameObject RoomObj;
	public Vector2 roomDimensions = new Vector2(17,17);
	public Vector2 gutterSize = new Vector2(17,17);
	public void Assign(Roomy[,] rooms){
		foreach (Roomy room in rooms){
			//skip point where there is no room
			if (room == null){
				continue;
			}
			//pick a random index for the array
			//find position to place room
			Vector3 pos = new Vector3(room.gridPos.x * (roomDimensions.x + gutterSize.x), room.gridPos.y * (roomDimensions.y + gutterSize.y), 0);
			Rooms myRoom = Instantiate(RoomObj, pos, Quaternion.identity).GetComponent<Rooms>();
			myRoom.Setup(room.gridPos, room.doorTop, room.doorBot, room.doorLeft, room.doorRight);
		}
	}
}
