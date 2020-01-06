using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid2d;
    Animator animator;
    //float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    public int key = 0;
    public Button right;
    public Button left;
    public bool rightbuttonDown;
    public bool leftbuttonDown;
    public bool jumpbuttonDown;
    public bool isGround;

    private Option_Trigger option;

    public GameObject flag;

	// Use this for initialization
	void Start () {
        this.rigid2d = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.option = FindObjectOfType<Option_Trigger>();

        this.flag = GameObject.Find("flag");
    }
	
	// Update is called once per frame
	void Update () {
        // 점프한다.
        if (isGround && jumpbuttonDown && this.rigid2d.velocity.y == 0)
        {
            this.animator.SetTrigger("Jump Trigger");
            //this.rigid2d.AddForce(transform.up * this.jumpForce, ForceMode2D.Force);
            this.rigid2d.velocity = new Vector3(rigid2d.velocity.x, 14);
        }

        // 좌우 이동
        int key = 0;
        if (rightbuttonDown)
        {
            key = 1;
        }
        if (leftbuttonDown) 
        {
            key = -1;
        }
        

        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2d.velocity.x);

        // 스피드 제한
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2d.AddForce(transform.right * key * this.walkForce);
        }

        // 움직이는 방향에 따라 이미지 반전 (추가)
        if (key != 0){
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어의 속도에 맞춰 애니메이션 속도를 바꾼다.
        if(this.rigid2d.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        } else
        {
            this.animator.speed = 1.0f;
        }
    }


    // 오브잭트 관리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == this.flag)
        {
            this.flag.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGround = true;

            this.rigid2d.velocity = Vector3.zero;
            this.rigid2d.angularVelocity = 0f;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGround = false;
        }
    }

    public void RightPressed()
    {
        rightbuttonDown = true;
    }

    public void RightRelease()
    {
        rightbuttonDown = false;
    }

    public void LeftPressed()
    {
        leftbuttonDown = true;
    }

    public void LeftRelease()
    {
        leftbuttonDown = false;
    }

    public void JumpPressed()
    {
        jumpbuttonDown = true;
    }

    public void JumpRelease()
    {
        jumpbuttonDown = false;
    }
}
