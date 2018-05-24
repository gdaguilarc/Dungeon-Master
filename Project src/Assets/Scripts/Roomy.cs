using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomy {
	public Vector2 gridPos;
	public bool doorTop, doorBot, doorLeft, doorRight;
	public Roomy(Vector2 _gridPos){
		gridPos = _gridPos;
	}
}
