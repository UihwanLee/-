using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeDirector : MonoBehaviour {

    public GameObject Code_Page;
    public InputField inputcode;
    private string code1 = "3014";
    private string code2 = "4103";
    private StageClear stageclear;
    public static bool codeCorrect = false;

	// Use this for initialization
	void Start () {
        stageclear = FindObjectOfType<StageClear>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Code_down()
    {
        Code_Page.SetActive(true);
    }


    public void Enter()
    {
        if(string.Compare(code1, inputcode.text) == 0)
        {
            codeCorrect = true;
            stageclear.codeConfirm();
        }
        if(string.Compare(code2, inputcode.text) == 0)
        {
            codeCorrect = false;
        }
        Code_Page.SetActive(false);
    }

    public bool getCodeCorrect()
    {
        return codeCorrect;
    }
}
