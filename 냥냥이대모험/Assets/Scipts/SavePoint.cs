using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {

    private Player_SceneManager CheckManager;
    public bool SaveReach = false;
    public Sprite saveConfirm;
    public Sprite saveFasle;
    public SpriteRenderer savepointSpriteRenderer;

    // Use this for initialization
    void Start()
    {
        CheckManager = FindObjectOfType<Player_SceneManager>();
        savepointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "cat")
        {
            CheckManager.currentsavepoint = GameObject.Find("savepoint");
            savepointSpriteRenderer.sprite = saveConfirm;
            SaveReach = true;
        }
    }
}
