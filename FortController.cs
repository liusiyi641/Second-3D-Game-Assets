using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortController : MonoBehaviour {

	public int numberOfSoldiers = 20;
	int remainingSoldiers;
	public GameObject spawnpoint1;
	public GameObject spawnpoint2;
	public GameObject spawnpoint3;
	private float Prsudo_Time = 1f;
	public int FortLevel;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AddToScore ();
	}

	void AddToScore(){
		Prsudo_Time -= Time.deltaTime;
		if(Prsudo_Time <=0 ){
			numberOfSoldiers++;
			Prsudo_Time = 1f;
		//	Debug.Log (numberOfSoldiers);
		}

	
	}





	void OnTriggerEnter(Collider other) 
	{
		Debug.Log (numberOfSoldiers);
		GabbyController gabby = other.gameObject.GetComponent<GabbyController> ();
		Destroy (other.gameObject);

		if (other.gameObject.CompareTag ("me") || other.gameObject.CompareTag("you")) 
		{ 
			
			if (gameObject.tag == other.gameObject.tag) {
				numberOfSoldiers = numberOfSoldiers + gabby.numberOfMovingSoldiers;
				Debug.Log (" + " + gabby.numberOfMovingSoldiers + " = " + numberOfSoldiers);
			} else { 
				numberOfSoldiers = numberOfSoldiers - gabby.numberOfMovingSoldiers/FortLevel;
				Debug.Log (" - " + gabby.numberOfMovingSoldiers/FortLevel + " = " + numberOfSoldiers);
				if (numberOfSoldiers < 0) {
					gameObject.tag = other.gameObject.tag;
				}
			}
			Debug.Log (numberOfSoldiers);

		}
	}

	public string reportDes(){
		if (gameObject.name == "fort1") {
			return "spawnpoint1";

		}
		else if (gameObject.name == "fort2") {
			return "spawnpoint2";

			}
		else if (gameObject.name == "fort3") {
			return "spawnpoint3";

			}
		else if (gameObject.name == "fort4") {
			return "spawnpoint4";
			}
		else{
			Debug.Log ("error on reportDes()");
			return "false";
	}

}
}
