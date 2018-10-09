using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour {

	public Waypoint waypointPrefab;
	public static List<Waypoint> path;
	public int sizeX;
	public int sizeY;
	public float turnPercent;
	public Button towerButtonPrefab;
	public Canvas canvas;
	// Use this for initialization
	void Awake () {
		int[,] grid = new int[sizeX,sizeY];
		int x = 0;
		int y = Random.Range (0, sizeY);
		grid [x, y] = 1;
		//1 start waypoint
		//2 normal waypoint
		//3 end waypoint
		//4 towers
		path = new List<Waypoint>();
		//Debug.Log(waypointPrefab);
		path.Add(Instantiate(waypointPrefab, new Vector3(x,0,y), Quaternion.identity,transform));
		path [0].type = 1;
		path [0].x = x;
		path [0].y = y;
		path [0].index = 0;

		bool down = false;
		bool up = false;

		while(x< sizeX -1)
		{
			if (Random.Range (0, 100) < turnPercent) {
				if (down || up) {
					down = false;
					up = false;
				} else {
					if (Random.Range (0, 2) == 0) {
						down = true;
					} else {
						up = true;
					}
				}
			}	

			//stay in bounds if top or bottom
			if (y == sizeY - 1) {
				up = false;
			}
			if(y == 0)
			{			
				down = false;
			}

			if(!down && !up){
				x++;
			}
			if(down){
				y--;
			}
			if(up){
				y++;
			}

			path.Add(Instantiate(waypointPrefab, new Vector3(x,0,y),new Quaternion(),transform));
			if (x == sizeX - 1) {
				grid [x, y] = 3;
				path [path.Count - 1].type = 3;
			} else 
			{
				grid [x, y] = 2;
				path [path.Count - 1].type = 2;
			}
			path [path.Count - 1].x = x;
			path [path.Count - 1].y = y;
			path [path.Count - 1].index = path.Count -1;
		}

		Instantiate (towerButtonPrefab,path[0].transform.position, new Quaternion(),canvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
