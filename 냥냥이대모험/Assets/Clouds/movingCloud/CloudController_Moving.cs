using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloudController_Moving : MonoBehaviour
{

    Vector3 pos;             //현재위치
    public float delta;     // 좌(우)로 이동가능한 (x)최대값
    public float speed;   // 이동속도

    private Vector3 offset;

    public GameObject cat;
    private PlayerController controller;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        this.cat = GameObject.Find("cat");
        this.controller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed); // 좌우 이동의 최대치 및  반전 처리

        transform.position = v;
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
}

