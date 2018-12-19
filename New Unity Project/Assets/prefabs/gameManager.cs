using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	GameObject[] spawns;
	public GameObject enemy;
	public static int count = 0;
	// Use this for initialization
	void Start () {
		spawns = GameObject.FindGameObjectsWithTag ("spawn");
		InvokeRepeating ("spawnNow", 3,3);
	}
	
	// Update is called once per frame
	void spawnNow () {
		//if (count < 5) {
			count++;
			GameObject.Instantiate (enemy, spawns [Random.Range (0, spawns.Length - 1)].transform.position, Quaternion.identity);
		//}
	}
}
