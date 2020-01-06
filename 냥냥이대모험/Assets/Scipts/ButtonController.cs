using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public void Startdown()
    {
        StartCoroutine(StartChange());
    }

    IEnumerator StartChange()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("3_mapscreen");
    }

    public void Backdown()
    {
        StartCoroutine(Back());
    }

    IEnumerator Back()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("2_startscreen_menu");
    }

    public void Morning_Stage1_down()
    {
        StartCoroutine(Morning_Stage1());
    }

    IEnumerator Morning_Stage1()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("4_morning_stage1");
    } 
 

    public void Morning_Stage2()
    {
        StartCoroutine(Morning_Stage2_down());
    }

    IEnumerator Morning_Stage2_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("5_morning_stage2");
    }

    public void Morning_Stage3()
    {
        StartCoroutine(Morning_Stage3_down());
    }

    IEnumerator Morning_Stage3_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("6_morning_stage3");
    }

    public void Sunset_Stage1()
    {
        StartCoroutine(Sunset_Stage1_down());
    }

    IEnumerator Sunset_Stage1_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("7_sunset_stage1");
    }

    public void Sunset_Stage2()
    {
        StartCoroutine(Sunset_Stage2_down());
    }

    IEnumerator Sunset_Stage2_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("8_sunset_stage2");
    }

    public void Sunset_Stage3()
    {
        StartCoroutine(Sunset_Stage3_down());
    }

    IEnumerator Sunset_Stage3_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("9_sunset_stage3");
    }

    public void Night_Stage1()
    {
        StartCoroutine(Night_Stage1_down());
    }

    IEnumerator Night_Stage1_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("10_night_stage1");
    }

    public void Night_Stage2()
    {
        StartCoroutine(Night_Stage2_down());
    }

    IEnumerator Night_Stage2_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("11_night_stage2");
    }

    public void Night_Stage3()
    {
        StartCoroutine(Night_Stage3_down());
    }

    IEnumerator Night_Stage3_down()
    {
        // fade out the game and load new level
        float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("12_night_stage3");
    }
}
