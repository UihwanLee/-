using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPersentage : MonoBehaviour {

    private Text percentageText;
    private MusicManager musicmanager;

    // Use this for initialization
    void Start () {
        musicmanager = FindObjectOfType<MusicManager>();
        percentageText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        showVolumePersentage();
    }

    public void showVolumePersentage()
    {
        percentageText.text = Mathf.RoundToInt(musicmanager.getValue() * 100) + "%";
    }
}
