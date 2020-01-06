using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_SceneManager : MonoBehaviour {

    public float stage_level;
    public GameObject cat;
    public GameObject flag;
    public GameObject currentcheckpoint;
    public GameObject currentsavepoint;

    private GameObject checkpoint1;
    private GameObject checkpoint2;
    private GameObject savepoint_obj;

    private CheckPoint checkpoint;
    private SavePoint savepoint;

    private Difficulty_Trigger difficulty;
    private StageClear stageclear;

    // Use this for initialization
    void Start () {
        this.cat = GameObject.Find("cat");
        this.flag = GameObject.Find("flag");
        this.savepoint = FindObjectOfType<SavePoint>();
        this.difficulty = FindObjectOfType<Difficulty_Trigger>();
        this.stageclear = FindObjectOfType<StageClear>();

        this.checkpoint1 = GameObject.Find("checkpoint1");
        this.checkpoint2 = GameObject.Find("checkpoint2");
        this.savepoint_obj = GameObject.Find("savepoint");

        // 초기 난이도 조정

        /*
        * 난이도 조정 스크립트
        * 
        * 하(1) : 세이브 포인트 + 체크 포인트
        * 중(2) : 세이브 포인트
        * 상(3) : 없음
        * 
        */

        if (difficulty.getLevel() == 2)
        {
            checkpoint1.SetActive(false);
            checkpoint2.SetActive(false);
        }
        else if (difficulty.getLevel() == 3)
        {
            checkpoint1.SetActive(false);
            checkpoint2.SetActive(false);
            savepoint_obj.SetActive(false);
        }
        else
        {
            checkpoint1.SetActive(true);
            checkpoint2.SetActive(true);
            savepoint_obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {

        if(this.flag.activeSelf == false)
        {
            checkStageClear();
            SceneManager.LoadScene("3_mapscreen");
        }
        // 플레이어가 화면 밖으로 나갔다면 처음부터
        if (this.cat.transform.position.y < -10)
        {
            // 난이도: 하 (savepoint + checkpoint)
            if(savepoint_obj.activeSelf == true && checkpoint1.activeSelf == true && checkpoint2.activeSelf == true)
            {
                this.checkpoint = currentcheckpoint.GetComponent<CheckPoint>();
                if (savepoint.SaveReach == true)
                {
                    if (checkpoint.priority == 2 && checkpoint.CheckReach == true && checkpoint.savecount > 0)
                    {
                        this.cat.transform.position = this.currentcheckpoint.transform.position + new Vector3(0, 1, 0);
                        checkpoint.LoseHeart();
                        checkpoint.savecount--;
                    }
                    else
                    {
                        checkpoint.ResetPoint();
                        this.cat.transform.position = this.currentsavepoint.transform.position + new Vector3(0, 1, 0);
                    }
                }
                else
                {
                    if (checkpoint.CheckReach == true && checkpoint.savecount > 0)
                    {
                        this.cat.transform.position = this.currentcheckpoint.transform.position + new Vector3(0, 1, 0);
                        checkpoint.LoseHeart();
                        checkpoint.savecount--;
                    }
                    else
                    {
                        checkpoint.ResetPoint();
                        this.cat.transform.position = new Vector3(0, 1, 0);
                    }
                }
            }
            // 난이도: 중 (savepoint)
            else if(savepoint_obj.activeSelf == true && checkpoint1.activeSelf == false && checkpoint2.activeSelf == false)
            {
                if (savepoint.SaveReach == true)
                {
                    this.cat.transform.position = this.currentsavepoint.transform.position + new Vector3(0, 1, 0);
                }
                else
                {
                    this.cat.transform.position = new Vector3(0, 1, 0);
                }
            }
            // 난이도: 상 ()
            else
            {
                this.cat.transform.position = new Vector3(0, 1, 0);
            }
        }
    }

    public void checkStageClear()
    {
        if(this.stage_level == 1)
        {
            stageclear.morning_stage1_success();
        }
        else if(this.stage_level == 2)
        {
            stageclear.morning_stage2_success();
        }
        else if(this.stage_level == 3)
        {
            stageclear.morning_stage3_success();
        }
        else if(this.stage_level == 4)
        {
            stageclear.sunset_stage1_success();
        }
        else if (this.stage_level == 5)
        {
            stageclear.sunset_stage2_success();
        }
        else if (this.stage_level == 6)
        {
            stageclear.sunset_stage3_success();
        }
        else if(this.stage_level == 7)
        {
            stageclear.night_stage1_success();
        }
        else if (this.stage_level == 8)
        {
            stageclear.night_stage2_success();
        }
        else if (this.stage_level == 9)
        {
            stageclear.night_stage3_success();
        }
        else if(this.stage_level == 10)
        {
            stageclear.dawn_stage1_success();
        }
        else if (this.stage_level == 11)
        {
            stageclear.dawn_stage2_success();
        }
        else if (this.stage_level == 12)
        {
            stageclear.dawn_stage3_success();
        }
        else
        {
            Debug.Log("ERROR");
        }
    }
}
