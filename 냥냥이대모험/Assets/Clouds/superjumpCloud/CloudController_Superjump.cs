using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController_Superjump : MonoBehaviour {

    Rigidbody2D rigid2D;
    public GameObject cat;
    public float jumpForce;

    // Use this for initialization
    void Start () {
        this.cat = GameObject.Find("cat");
        this.rigid2D = this.cat.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == this.cat)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
    }
}
