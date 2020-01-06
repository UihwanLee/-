using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour {

    public GameObject Loadingscene;
    public Slider slider;
    public Text progressText;
    public Animator catmoving;

    public AudioSource clickSound;

    // Use this for initialization
    void Start()
    {
        clickSound.Stop();
    }

    public void LoadLevel(int sceneIndex)
    {
        ClickSoundPlay();
        Loadingscene.SetActive(true);
        this.catmoving = GameObject.Find("catmoving").GetComponent<Animator>();
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            float persentage = progress * 100f;

            slider.value = progress;
            progressText.text = persentage.ToString("0") + "%";

            yield return null;
        }
    }

    public void ClickSoundPlay()
    {
        clickSound.Play();
    }
}
