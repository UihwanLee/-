using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController_Falling : MonoBehaviour
{

    private Rigidbody2D rigid2D;
    private BoxCollider2D boxcollider;
    public GameObject cat;

    public float fallSpeed; // 대기 시간
    public float fallSecond; // 떨어지는 시간

    private SpriteRenderer oj;

    private Vector3 Spawnpos; // 스폰 위치

    private void Awake()
    {
        this.rigid2D = this.GetComponent<Rigidbody2D>();
        this.boxcollider = this.GetComponent<BoxCollider2D>();
        this.oj = this.GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        this.cat = GameObject.Find("cat");
        Spawnpos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Spawnpos.y - this.transform.position.y >= 1)
        {
            oj.enabled = false;
            Respawn();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == this.cat)
        {
            Invoke("Fall", fallSpeed);
        }
    }

    private void Fall()
    {
        rigid2D.isKinematic = false;
        boxcollider.isTrigger = true;
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