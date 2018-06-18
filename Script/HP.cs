using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour {
	public static HP instance;
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
		if (hp == 0)                            //HP가 0이면
			SceneManager.LoadScene ("title");   //타이틀 화면으로 이동
	}

	public void hpControl(int num) {
		hp -= num;                  //num만큼 체력을 깎는다
		hpText.text = "HP: " + hp;  //텍스트에 현재 HP 표시
	}
}
