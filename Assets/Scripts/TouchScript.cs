using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour {
	
	public GameObject circle; 
	bool flag = false;
	GameObject obj;
	int num = 0;
	GameObject en;
	Vector3 pre_pos = Vector3.zero;

	
	// Use this for initialization
	void Start () {
		en = new GameObject ();
		en.transform.position = new Vector2 (111,111);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collision = Physics2D.OverlapPoint(pos);
			flag = !collision;
			if (flag) {
				obj = Instantiate (new GameObject (num.ToString ()), new Vector3 (pos.x, pos.y, 0), Quaternion.identity)as GameObject;
				obj.AddComponent<Rigidbody2D> ();
				obj.GetComponent<Rigidbody2D> ().gravityScale = 0;
				obj.AddComponent<ParentScript> ();
				//obj.layer =  LayerMask.NameToLayer("Circle");
				obj.tag = "Circle";
				pre_pos = new Vector3 (pos.x, pos.y, 0);

				en = Instantiate (circle, new Vector3 (pos.x, pos.y, 0), Quaternion.identity) as GameObject;
				en.transform.SetParent (obj.transform);
				CircleCollider2D col = obj.AddComponent<CircleCollider2D> ();
				col.radius = 0.385f;
				col.offset = en.transform.localPosition;
			}
			//pre_pos = pos3;

			
		}
		if (flag) {
			Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 pos3 = new Vector3(pos.x,pos.y,0);


			if (Vector3.Distance (pre_pos, pos3) > 0.5f) {
				for(float i = 0.0f; i < 1.0f; i = i + 0.05f){
					Vector3 pos_between = Vector3.Lerp (pre_pos,pos3,i);
					GameObject en2 = Instantiate (circle, pos_between, Quaternion.identity) as GameObject;
					en2.transform.SetParent (obj.transform);
					CircleCollider2D col = obj.AddComponent<CircleCollider2D> ();
					col.radius = 0.385f;
					col.offset = en2.transform.localPosition;
				}

			}
			if (Vector3.Distance (pre_pos, pos3) > 0.05f) {

				en = Instantiate (circle, pos3, Quaternion.identity) as GameObject;
				en.transform.SetParent (obj.transform);
				CircleCollider2D col = obj.AddComponent<CircleCollider2D> ();
				col.radius = 0.385f;
				col.offset = en.transform.localPosition;
				pre_pos = pos3;

			}

		}if (Input.GetMouseButtonUp (0)) {
			flag = false;
			num++;
			obj.GetComponent<Rigidbody2D> ().gravityScale = 1;
			/*
			for (int i = 0; i < obj.transform.childCount; i++) {
				obj.transform.GetChild (i).GetComponent<Rigidbody2D> ().gravityScale = 1;
			}*/
		}
		
	}
	public void Clear(){
		int count = GameObject.FindGameObjectsWithTag ("Circle").Length;
		for (int i = 0; i < count; i++) {
			Destroy (GameObject.FindGameObjectsWithTag ("Circle")[i]);
		}
		num = 0;
	}
}
