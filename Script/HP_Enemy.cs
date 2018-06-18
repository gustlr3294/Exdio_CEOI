using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Enemy : MonoBehaviour {
	public static HP_Enemy instance;
	private Text hpText;
	private int hp = 100;


	void Awake() {
		if (!instance)
			instance = this;
	}

	// Use this for initialization
	void Start () {
		hpText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (hp == 0) {                                              //HP가 0이면
			Destroy (gameObject);                                   //텍스트와
			Destroy (GameObject.FindGameObjectWithTag ("Enemy"));   //적 스프라이트 삭제
		}
	}

	public void hpControl(int num) {
		hp -= num;                  //num만큼 체력을 깎는다
		hpText.text = "" + hp;      //적의 체력 표시
	}
}
