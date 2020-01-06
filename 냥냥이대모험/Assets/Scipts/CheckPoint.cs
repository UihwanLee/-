using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

    private Player_SceneManager CheckManager;
    public bool CheckReach;
    public Sprite checkConfirm;
    public Sprite checkFasle;
    public SpriteRenderer checkpointSpriteRenderer;
    public int priority;

    public GameObject save_heart;
    public int savecount;
    public int countcontroller = 0;

	// Use this for initialization
	void Start () {
        CheckManager = FindObjectOfType<Player_SceneManager>();
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "cat")
        {
            this.save_heart.SetActive(true);
            if (countcontroller == 0) ResetPoint();
            if (this.priority == 2)
            {
                CheckManager.currentcheckpoint = GameObject.Find("checkpoint2");
            }
            else CheckManager.currentcheckpoint = GameObject.Find("checkpoint1");
            checkpointSpriteRenderer.sprite = checkConfirm;
            CheckReach = true;
            countcontroller++;
        }
    }

    public void LoseHeart()
    {
        this.save_heart.GetComponent<Image>().fillAmount -= 0.33f;
    }

    public void ResetPoint()
    {
        save_heart.GetComponent<Image>().fillAmount += 0.99f;
        save_heart.SetActive(false);
        checkpointSpriteRenderer.sprite = checkFasle;
        savecount = 3;
        CheckReach = false;
    }
}
