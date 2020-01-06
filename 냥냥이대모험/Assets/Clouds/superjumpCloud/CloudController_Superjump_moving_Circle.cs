using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController_Superjump_moving_Circle : MonoBehaviour {

    Rigidbody2D rigid2D;
    public GameObject cat;
    public float jumpForce;

    public float RotateSpeed;
    public float Radius;

    private Vector2 pos;
    private float _angle;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        this.cat = GameObject.Find("cat");
        this.rigid2D = this.cat.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = pos + offset;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == this.cat)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }
}
