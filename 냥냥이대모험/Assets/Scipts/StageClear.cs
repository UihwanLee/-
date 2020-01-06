using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageClear : MonoBehaviour {

    /*
     * Stage 클리어시 맵 갱신 
     * 
     * 1 Stage 성공시 -> 2 Stage 갱신
     * 2 Stage 성공시 -> 3 Stage + 다음 단계 1 Stage 갱신
     * 
    */

    public GameObject morning_stage1;
    public GameObject morning_stage2;
    public GameObject morning_stage3;

    public GameObject sunset_stage1;
    public GameObject sunset_stage2;
    public GameObject sunset_stage3;

    public GameObject night_stage1;
    public GameObject night_stage2;
    public GameObject night_stage3;

    public GameObject dawn_stage1;
    public GameObject dawn_stage2;
    public GameObject dawn_stage3;

    public Button morning_stage1_button;
    public Button morning_stage2_button;
    public Button morning_stage3_button;

    public Button sunset_stage1_button;
    public Button sunset_stage2_button;
    public Button sunset_stage3_button;

    public Button night_stage1_button;
    public Button night_stage2_button;
    public Button night_stage3_button;

    public Button dawn_stage1_button;
    public Button dawn_stage2_button;
    public Button dawn_stage3_button;

    public static bool morning_stage1_clear = false;
    public static bool morning_stage2_clear = false;
    public static bool morning_stage3_clear = false;

    public static bool sunset_stage1_clear = false;
    public static bool sunset_stage2_clear = false;
    public static bool sunset_stage3_clear = false;

    public static bool night_stage1_clear = false;
    public static bool night_stage2_clear = false;
    public static bool night_stage3_clear = false;

    public static bool dawn_stage1_clear = false;
    public static bool dawn_stage2_clear = false;
    public static bool dawn_stage3_clear = false;

    private CodeDirector codeDirector;

    // Sprite 관리

    public Sprite morning_stage1_clear_img;
    public Sprite morning_stage2_clear_img;
    public Sprite morning_stage3_clear_img;

    public Sprite sunset_stage1_clear_img;
    public Sprite sunset_stage2_clear_img;
    public Sprite sunset_stage3_clear_img;

    public Sprite night_stage1_clear_img;
    public Sprite night_stage2_clear_img;
    public Sprite night_stage3_clear_img;

    public Sprite dawn_stage1_clear_img;
    public Sprite dawn_stage2_clear_img;
    public Sprite dawn_stage3_clear_img;

    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("CodeDirector"))
        {
            this.codeDirector = FindObjectOfType<CodeDirector>();
            if (codeDirector.getCodeCorrect())
            {
                codeConfirm();
            }
        }
        if (GameObject.Find("Morning_Stage1") && !codeDirector.getCodeCorrect())
        {
            morning_stage2.SetActive(false);
            morning_stage3.SetActive(false);

            sunset_stage1.SetActive(false);
            sunset_stage2.SetActive(false);
            sunset_stage3.SetActive(false);

            night_stage1.SetActive(false);
            night_stage2.SetActive(false);
            night_stage3.SetActive(false);

            dawn_stage1.SetActive(false);
            dawn_stage2.SetActive(false);
            dawn_stage3.SetActive(false);
        }
        checkStageClear();
    }

    public void checkStageClear()
    {
        if(morning_stage1_clear == true)
        {
            morning_stage2.SetActive(true);
            if(GameObject.Find("Morning_Stage1"))
            {
                morning_stage1_button.image.sprite = morning_stage1_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true)
        {
            morning_stage3.SetActive(true);
            sunset_stage1.SetActive(true);
            if (GameObject.Find("Morning_Stage2"))
            {
                morning_stage2_button.image.sprite = morning_stage2_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true && morning_stage3_clear)
        {
            if (GameObject.Find("Morning_Stage3"))
            {
                morning_stage3_button.image.sprite = morning_stage3_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true)
        {
            sunset_stage2.SetActive(true);
            if (GameObject.Find("Sunset_Stage1"))
            {
                sunset_stage1_button.image.sprite = sunset_stage1_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true)
        {
            sunset_stage3.SetActive(true);
            night_stage1.SetActive(true);
            if (GameObject.Find("Sunset_Stage2"))
            {
                sunset_stage2_button.image.sprite = sunset_stage2_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true &&
            sunset_stage3_clear)
        {
            if (GameObject.Find("Sunset_Stage3"))
            {
                sunset_stage3_button.image.sprite = sunset_stage3_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true &&
            night_stage1_clear == true)
        {
            night_stage2.SetActive(true);
            if (GameObject.Find("Night_Stage1"))
            {
                night_stage1_button.image.sprite = night_stage1_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true &&
            night_stage1_clear == true && night_stage2_clear == true)
        {
            night_stage3.SetActive(true);
            dawn_stage1.SetActive(true);
            if (GameObject.Find("Night_Stage2"))
            {
                night_stage2_button.image.sprite = night_stage2_clear_img;
            }
        }
        if (morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true &&
            night_stage1_clear == true && night_stage2_clear == true && night_stage3_clear)
        {
            if (GameObject.Find("Night_Stage3"))
            {
                night_stage3_button.image.sprite = night_stage3_clear_img;
            }
        }
        if (morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true &&
            night_stage1_clear == true && night_stage2_clear == true && dawn_stage1_clear == true)
        {
            dawn_stage2.SetActive(true);
            if (GameObject.Find("Dawn_Stage1"))
            {
                dawn_stage1_button.image.sprite = dawn_stage1_clear_img;
            }
        }
        if(morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true &&
            night_stage1_clear == true && night_stage2_clear == true && dawn_stage1_clear == true && dawn_stage2_clear == true)
        {
            dawn_stage3.SetActive(true);
            if (GameObject.Find("Dawn_Stage2"))
            {
                dawn_stage2_button.image.sprite = dawn_stage2_clear_img;
            }
        }
        if (morning_stage1_clear == true && morning_stage2_clear == true && sunset_stage1_clear == true && sunset_stage2_clear == true &&
            night_stage1_clear == true && night_stage2_clear == true && dawn_stage1_clear == true && dawn_stage2_clear == true
            && dawn_stage3_clear)
        {
            if (GameObject.Find("Dawn_Stage3"))
            {
                dawn_stage3_button.image.sprite = dawn_stage3_clear_img;
            }
        }
    }

    public void morning_stage1_success()
    {
        morning_stage1_clear = true;
    }
    public void morning_stage2_success()
    {
        morning_stage2_clear = true;
    }
    public void morning_stage3_success()
    {
        morning_stage3_clear = true;
    }

    public void sunset_stage1_success()
    {
        sunset_stage1_clear = true;
    }
    public void sunset_stage2_success()
    {
        sunset_stage2_clear = true;
    }
    public void sunset_stage3_success()
    {
        sunset_stage3_clear = true;
    }

    public void night_stage1_success()
    {
        night_stage1_clear = true;
    }
    public void night_stage2_success()
    {
        night_stage2_clear = true;
    }
    public void night_stage3_success()
    {
        night_stage3_clear = true;
    }

    public void dawn_stage1_success()
    {
        dawn_stage1_clear = true;
    }
    public void dawn_stage2_success()
    {
        dawn_stage2_clear = true;
    }
    public void dawn_stage3_success()
    {
        dawn_stage3_clear = true;
    }

    public void codeConfirm()
    {
        morning_stage2.SetActive(true);
        morning_stage3.SetActive(true);

        sunset_stage1.SetActive(true);
        sunset_stage2.SetActive(true);
        sunset_stage3.SetActive(true);

        night_stage1.SetActive(true);
        night_stage2.SetActive(true);
        night_stage3.SetActive(true);

        dawn_stage1.SetActive(true);
        dawn_stage2.SetActive(true);
        dawn_stage3.SetActive(true);
    }
}
