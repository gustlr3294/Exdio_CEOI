using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 1f;
    int moveFlag = 0;   // 0:제자리 1:왼쪽 2:오른쪽. 
    private GameObject traceTarget;
    private bool isTracing;

	// Use this for initialization
	void Start () {
        StartCoroutine("ChangeMovement");
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        string dist = "";

        if(isTracing)
        {
            Vector3 playerPos = traceTarget.transform.position;

            if(playerPos.x < transform.position.x)
            {
                dist = "Left";
            }
            else if(playerPos.x > transform.position.x)
            {
                dist = "Right";
            }
        }
        else
        {
            if(moveFlag == 1)
            {
                dist = "Left";
            }
            else if(moveFlag == 2)
            {
                dist = "Right";
            }
        }

        if(dist == "Left")
        {
            Vector3 scale = transform.localScale;
            scale.x = +Mathf.Abs(scale.x);
            moveVelocity = Vector3.left;
            transform.localScale = scale;
        }
        else if(dist == "Right")
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            moveVelocity = Vector3.right;
            transform.localScale = scale;
        }

        transform.Translate(moveVelocity * speed * Time.deltaTime);
    }

    IEnumerator ChangeMovement()
    {
        moveFlag = Random.Range(0, 3);

        yield return new WaitForSeconds(3f);
        StartCoroutine("ChangeMovement");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            traceTarget = other.gameObject;
            StopCoroutine("ChangeMovement");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
	{
		//if (other.transform.tag == "Weapon") {
		//	if (PlayerMove.instance.isAttack == true)
		//	{
		//		HP_Enemy.instance.hpControl(25);
		//	}
		//}
        if(other.tag == "Player")
        {
            isTracing = true;
        }
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isTracing = false;
            StartCoroutine("ChangeMovement");
        }
    }
}
