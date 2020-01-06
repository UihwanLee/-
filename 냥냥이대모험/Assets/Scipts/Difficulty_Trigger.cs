using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty_Trigger : MonoBehaviour {
    
    /*
     * 난이도 조정 스크립트
     * 
     * 하(1) : 세이브 포인트 + 체크 포인트
     * 중(2) : 세이브 포인트
     * 상(3) : 없음
    */

    public GameObject difficult_Page;
    public static float diffculty_level = 2;

    public GameObject dificulty;

    public GameObject diffcultyText;


    public void Low()
    {
        diffculty_level = 1;
        difficult_Page.SetActive(false);
    }

    public void Medium()
    {
        diffculty_level = 2;
        difficult_Page.SetActive(false);
    }

    public void Hard()
    {
        diffculty_level = 3;
        difficult_Page.SetActive(false);
    }

    public float getLevel()
    {
        return diffculty_level;
    }
}
