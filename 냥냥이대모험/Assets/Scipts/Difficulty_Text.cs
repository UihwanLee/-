using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty_Text : MonoBehaviour {

    private Difficulty_Trigger difficulty;
    public GameObject diffculty_level;

	// Use this for initialization
	void Start () {
        this.difficulty = FindObjectOfType<Difficulty_Trigger>();
        this.diffculty_level = GameObject.Find("Level");
	}
	
	// Update is called once per frame
	void Update () {
        if (difficulty.getLevel() == 1)
        {
            this.diffculty_level.GetComponent<Text>().text = "Easy";
        }
        else if (difficulty.getLevel() == 2)
        {
            this.diffculty_level.GetComponent<Text>().text = "Medium";
        }
        else
        {
            this.diffculty_level.GetComponent<Text>().text = "Hard";
        }
    }
}
