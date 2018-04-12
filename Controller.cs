using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public static int counter = 0;
	GameObject startFort;
	public static GameObject desFort;
	public GameObject gabby;
	public GameObject clone;
	public GameObject badgabby;
	public string stored_tag;
	public static int number;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Click ();
	}


	void Click ()
	{
		
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.collider.tag != "you" && hit.collider.tag != "me" && hit.collider.tag != "him" ) {
					counter = 0;
					Debug.Log ("not here");
				} 
				//if (counter == 1){
				//	Debug.Log ("now " + stored_tag);
				//	stored_tag = hit.collider.tag;
				//}
				else if (counter == 0 && hit.collider.tag == "him"){
					counter = 0;
				}
				else{
					//stored_tag = hit.collider.tag;
					Debug.Log("here");
					counter += 1;
					if (counter == 1) {
						startFort = hit.collider.gameObject;
						stored_tag = hit.collider.tag;
					}
					if (counter >= 2 && hit.collider.gameObject != startFort) {
						//if (hit.collider.gameObject == startFort) {
						//	counter = 0;
						//}
						//counter = 0;
						desFort = hit.collider.gameObject;
						spawn (startFort, desFort);
						FortController fort = startFort.GetComponent<FortController> ();
						number = fort.numberOfSoldiers;
						counter = 0;
					}
				} 
			}
		}
	}

	void spawn(GameObject from,  GameObject to){
		FortController start = from.GetComponent<FortController> ();
		FortController end = to.GetComponent<FortController> ();


		if(end.reportDes () == start.spawnpoint1.name){
			if (stored_tag == "me") {
				clone = Instantiate (gabby, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
				clone.SetActive (true);
			} else {
				clone = Instantiate (badgabby, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
				clone.SetActive (true);
			}
		}
		else if(end.reportDes () == start.spawnpoint2.name){
			if (stored_tag == "me") {
				clone = Instantiate (gabby, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
				clone.SetActive (true);
			} else {
				clone = Instantiate (badgabby, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
				clone.SetActive (true);
			}
		}
		else if(end.reportDes () == start.spawnpoint3.name){
			if (stored_tag == "me") {
				clone = Instantiate (gabby, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
				clone.SetActive (true);
			} else {
				clone = Instantiate (badgabby, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
				clone.SetActive (true);
			}
		}

		}

		
	}








