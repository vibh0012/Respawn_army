using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public GameObject target;
	public float speed = 4;
	Animator playerAnim;
	// Use this for initialization
	void Start () {
		target = Camera.main.gameObject;
		playerAnim = gameObject.GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((gameObject.transform.position - target.transform.position).sqrMagnitude < 10) {
			playerAnim.SetTrigger ("idle");
			return;
		}
		gameObject.transform.LookAt (target.transform);
		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, target.transform.position, Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag.Equals ("sword")) {
			playerAnim.SetTrigger ("isDead");
			gameManager.count--;
			Invoke ("die", 3);
		}
	}

	void die(){
		
		Destroy (gameObject);
	}
}
