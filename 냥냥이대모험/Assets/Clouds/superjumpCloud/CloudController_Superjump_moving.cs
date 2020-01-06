using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController_Superjump_moving : MonoBehaviour {

    Rigidbody2D rigid2D;
    public GameObject cat;
    public float jumpForce;

    Vector3 pos;             //현재위치
    public float delta;     // 좌(우)로 이동가능한 (x)최대값
    public float speed;   // 이동속도

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        this.cat = GameObject.Find("cat");
        this.rigid2D = this.cat.GetComponent<Rigidbody2D>();

        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed); // 좌우 이동의 최대치 및  반전 처리

        transform.position = v;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == this.cat)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }
}
