using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Circle") {
			Debug.Log (1);
			GetComponent<SpriteRenderer> ().material.color = Color.magenta;
			Invoke ("ToWhite",2.0f);
		}
	}

	void ToWhite(){
		GetComponent<SpriteRenderer> ().material.color = Color.white;

	}
}
