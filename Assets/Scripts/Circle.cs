using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Wall") {
			GetComponent<SpriteRenderer> ().material.color = Color.magenta;
		}
		if (col.transform.tag != "Circle") {
			

		}
	}
}
