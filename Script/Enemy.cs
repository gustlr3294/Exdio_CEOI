using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.tag == "Player") {   //플레이어와 충돌하면
			HP.instance.hpControl (20);         //플레이어의 체력을 20 깎음
			Debug.Log ("충돌");
		}
	}
}
