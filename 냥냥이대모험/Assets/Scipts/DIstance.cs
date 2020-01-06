using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIstance : MonoBehaviour {

    GameObject cat;
    GameObject flag;
    GameObject Distance;

	// Use this for initialization
	void Start () {
        this.cat = GameObject.Find("cat");
        this.flag = GameObject.Find("flag");
        this.Distance = GameObject.Find("Distance");
	}
	
	// Update is called once per frame
	void Update () {
        float length = this.flag.transform.position.y - this.cat.transform.position.y;
        this.Distance.GetComponent<Text>().text = "목표 지점까지 : " + length.ToString("F2") + "m";
	}
}
