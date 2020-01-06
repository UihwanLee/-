using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloudController_Falling_Moving : MonoBehaviour {

    private Rigidbody2D rigid2D;
    private BoxCollider2D boxcollider;

    Vector3 pos;             //현재위치
    public float delta;     // 좌(우)로 이동가능한 (x)최대값
    public float speed;   // 이동속도

    public float fallSpeed; // 대기 시간
    public float fallSecond; // 떨어지는 시간
    public bool isFalling = false;
    private Vector3 Spawnpos; // 스폰 위치

    private Vector3 offset;

    public GameObject cat;
    private SpriteRenderer oj;

    Collision2D collision_cloud;
    private PlayerController controller;

    private void Awake()
    {
        this.rigid2D = this.GetComponent<Rigidbody2D>();
        this.boxcollider = this.GetComponent<BoxCollider2D>();
        this.oj = this.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        this.cat = GameObject.Find("cat");
        Spawnpos = this.transform.position;
        this.controller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFalling == false)
        {
            Vector3 v = pos;
            v.x += delta * Mathf.Sin(Time.time * speed); // 좌우 이동의 최대치 및  반전 처리

            transform.position = v;
        }

        if (Spawnpos.y - this.transform.position.y >= 1)
        {
            collision_cloud.transform.parent = null;
            oj.enabled = false;
            Respawn();
            isFalling = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == this.cat)
        {
            collision_cloud = collision;
            Invoke("Fall", fallSpeed);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == this.cat)
        {
            if (controller.rightbuttonDown)
            {
                collision.transform.parent = null;
            }

            else if (controller.leftbuttonDown)
            {
                collision.transform.parent = null;
            }
            else if (controller.jumpbuttonDown)
            {
                collision.transform.parent = null;
            }
            else
            {
                collision.transform.parent = transform;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == this.cat)
        {
            collision.transform.parent = null;
        }
    }

    private void Fall()
    {
        rigid2D.isKinematic = false;
        boxcollider.isTrigger = true;
        isFalling = true;
    }

    private void Respawn()
    {
        StartCoroutine(RespawnCloud());
    }


    IEnumerator RespawnCloud()
    {
        Destroy(rigid2D);
        yield return new WaitForSeconds(fallSecond);
        gameObject.AddComponent<Rigidbody2D>();
        this.rigid2D = this.GetComponent<Rigidbody2D>();
        rigid2D.isKinematic = true;
        boxcollider.isTrigger = false;
        transform.position = Spawnpos;
        oj.enabled = true;
        rigid2D.velocity = Vector3.zero;
    }
}
