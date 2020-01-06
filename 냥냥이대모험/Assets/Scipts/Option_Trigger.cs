using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option_Trigger : MonoBehaviour {

    public GameObject Option_Page; // 옵션
    public GameObject MusicOption;  // 음악 설정
    public GameObject Diffculty;  // 난이도 조정
    public GameObject cat;
    public bool Optiondown;

    public AudioSource ClickSound;

    private MusicManager musicmanager;

    // Use this for initialization
    void Start () {
        this.cat = GameObject.Find("cat");
        this.musicmanager = FindObjectOfType<MusicManager>();
        ClickSound.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionDown();
        }
        Optiondown = false;
    }

    public void OptionDown()
    {
        Optiondown = true;
        if (Option_Page)
        {
            ClickSoundPlay();
            Time.timeScale = 0;
            Option_Page.SetActive(true);
        }
        else
        {
            Debug.Log("No game object called Option_Page found");
        }
    }

    public void OptionConfirm() // 옵션 종료하는 창
    {
        ClickSoundPlay();
        Option_Page.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        ClickSoundPlay();
        this.cat.transform.position = new Vector3(0, 1, 0);
        Option_Page.SetActive(false);
        Time.timeScale = 1;
    }

    public void MusicDown() // Music 옵션 보여주는 창
    {
        ClickSoundPlay();
        MusicOption.SetActive(true);
        if(GameObject.Find("Toggle") && musicmanager.getToggledown() == false)
        {
            Toggle toggle = (Toggle)FindObjectOfType<Toggle>();
            toggle.isOn = musicmanager.getToggle().isOn;
        }
        if (GameObject.Find("Slider"))
        {
            Slider slider = (Slider)FindObjectOfType<Slider>();
            slider.value = musicmanager.getValue();
        }
    }

    public void MusicConfirm()
    {
        ClickSoundPlay();
        MusicOption.SetActive(false);
    }

    public void ExitMapP() // Map Page로 나가는 버튼
    {
        ClickSoundPlay();
        Time.timeScale = 1;
        SceneManager.LoadScene("3_mapscreen");
    }

    public void DifficultyDown() // 난이도 조정
    {
        ClickSoundPlay();
        Diffculty.SetActive(true);
    }

    public void Exit() // 게임 나가기
    {
        ClickSoundPlay();
        Application.Quit();
    }
    
    public void ClickSoundPlay()
    {
        ClickSound.Play();
    }
}
