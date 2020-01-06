using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloudController_Moving_Circle : MonoBehaviour {

    public float RotateSpeed;
    public float Radius;

    private Vector2 pos;
    private float angle;

    public GameObject cat;
    private PlayerController controller;

    // Use this for initialization
    void Start () {
        pos = transform.position;
        this.cat = GameObject.Find("cat");
        this.controller = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = pos + offset;
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
