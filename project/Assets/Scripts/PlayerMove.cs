﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;    //이동 속도
    public float jumpSpeed = 15f;    //점프 속도
    public bool isGrounded = false;
    public int jumpCount = 1; //점프횟수    2를 3으로 바꾸면 3단 점프
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //컴포넌트를 불러옴
        jumpCount = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            isGrounded = true;    //Ground에 닿으면 isGround는 true
            jumpCount = 1;          //Ground에 닿으면 점프횟수가 2로 초기화됨
        }
    }

    void Update()
    {
        if (isGrounded)
        {
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))   //입력키가 위화살표면 실행함
                {
                    rb.AddForce(new Vector2(0, 1) * jumpSpeed, ForceMode2D.Impulse); //위방향으로 올라가게함
                    jumpCount--;    //점프할때 마다 점프횟수 감소
                }
            }
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
    }
}
