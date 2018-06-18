using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	private float moveSpeed = 5.0f;    //이동 속도
	private float jumpPower = 10.0f;    //점프 속도
	private bool isGrounded = true;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))   //입력키가 위화살표면 실행함
		{
			Jump();
		}

		if (Input.GetKey(KeyCode.LeftArrow))    //왼쪽화살표 입력시 실행함
		{
			Vector3 scale = transform.localScale;
			scale.x = -Mathf.Abs(scale.x);
			transform.localScale = scale;
			transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.RightArrow))    //오른쪽화살표 입력시 실행함
		{
			Vector3 scale = transform.localScale;
			scale.x = +Mathf.Abs(scale.x);
			transform.localScale = scale;
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
		}
		if(Input.GetKeyDown(KeyCode.Z))         //Z키 입력시 실행함
		{
			HP_Enemy.instance.hpControl (25);   //적의 체력을 25 깎음
			Debug.Log ("공격");
		}
	}

	void Jump()
	{
		if (!isGrounded || rb.velocity.y != 0) { return; }

		rb.AddForce(new Vector2(0, 1) * jumpPower, ForceMode2D.Impulse);
		isGrounded = false;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Platform")
		{
			isGrounded = true;
		}
	}
}
