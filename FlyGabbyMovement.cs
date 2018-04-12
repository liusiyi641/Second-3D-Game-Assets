using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGabbyMovement : MonoBehaviour {

	public float speed;
	Vector3 position;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			position = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);
			Debug.Log (Input.mousePosition);
			transform.position = Vector3.MoveTowards(transform.position, position, speed*Time.deltaTime);
		}			
	}
}
