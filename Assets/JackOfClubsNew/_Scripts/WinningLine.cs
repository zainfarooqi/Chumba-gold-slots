using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningLine : MonoBehaviour
{
    int ooasd;
    int herer;
    public Detector[] Ds;
    public SpriteRenderer sp;
    public bool ISwin;
    public GameObject Effect;
    public int winstreak, call1time;
    Animator lineanim;
    public string animationname;
    bool withwild;
    string Priority,IconName;
    float wildpoints;
    public AudioSource minigamesound;
    private void Start()
    {
        wildpoints = 0;
        withwild = false;
        call1time = 0; winstreak = 1;
        lineanim = this.GetComponent<Animator>();
        ZombieGameManager.winamount = 0.8f;
       
    }
    private void OnEnable()
    {
        ISwin = false;
        call1time = 0;
        winstreak = 1;
        sp.enabled = false;
       // ZombieGameManager.king10 = 0;
      //  ZombieGameManager.king15 = 0;
    }
    private void Update()
    {
        if (call1time == 0)
        {
            Invoke("checkresult", 0.5f);
            call1time = 1;
        }
    }
    void checkresult()
    {
        for (int i = 0; i < ZombieGameManager.slots-1; i++)
        {
            int call1time = 0;
            for (int j = i + 1; j < ZombieGameManager.slots; j++)
            {
                if(Ds[0].BlockName=="wild"&&call1time==0)
                {
                    withwild = true;
                    wildpoints = 0.5f;
                    winstreak++;
                    call1time++;
                    i = 1; j = 2;
                }
                if ((Ds[1].BlockName == "wild" && call1time == 0&&winstreak==1)|| 
                    (Ds[2].BlockName == "wild" && call1time == 0 && winstreak == 2))
                {
                    withwild = true;
                    winstreak++;
                    call1time++;
                    wildpoints = 0.5f;
                }
                if (Ds[i].BlockName == Ds[j].BlockName && Ds[j].BlockName != "NoPoints")
                {
                    winstreak++;                  
                    IconName = Ds[i].BlockName;
                    if ( IconName == "2" || IconName == "3" || IconName == "5"
                        || IconName == "8" || IconName == "9" || IconName == "11" || IconName == "12")
                    {
                        Priority = "Low";
                    }
                    else if ( IconName == "1" || IconName == "4" || IconName == "10" || IconName == "13")
                    {
                        Priority = "Medium";
                    }   
                    else if( IconName == "6" || IconName == "7")
                    {
                        Priority = "Low";
                    }
                   
                }
                else
                {
                    break;
                }
            }
        }
            if (winstreak > 2)
            {
                sp.enabled = true;
                Effect.SetActive(false);
                Effect.SetActive(true);
                ZombieGameManager.win = 1;
                Invoke("newanimation", 3f);
            }

        if (winstreak > 2)
        {
            if (Priority == "Low")
            {
                ZombieGameManager.winamount += (0.1f*winstreak)+wildpoints;
                Debug.Log("Low "+ZombieGameManager.winamount);
            }
            if (Priority == "Medium")
            {
                ZombieGameManager.winamount += (0.3f * winstreak) + wildpoints;
                Debug.Log("Medium " + ZombieGameManager.winamount);
            }
            if (Priority == "High")
            {
                ZombieGameManager.winamount += (0.5f * winstreak) + wildpoints;
                Debug.Log("High " + ZombieGameManager.winamount);
            }
            /*if (Priority == "bellaMini")
            {
                ZombieGameManager.winamount += (0.5f * winstreak) + wildpoints;
                kingkong.SetActive(true);
                minigamesound.Play();
                Invoke("bellamini", 2.5f);
            }
            if (Priority == "alicemini")
            {
                ZombieGameManager.winamount += (0.5f * winstreak) + wildpoints;
                kingkong.SetActive(true);
                minigamesound.Play();
                Invoke("alicemini", 2.5f);
            }
            if (Priority == "kingkongmini")
            {
                ZombieGameManager.winamount += (0.5f * winstreak) + wildpoints;
                kingkong.SetActive(true);
                ZombieGameManager.kingkong = 1;
                if (winstreak == 3)
                {
                    ZombieGameManager.king10 = 1;
                }
                if (winstreak == 4)
                {
                    ZombieGameManager.king10 = 0;
                    ZombieGameManager.king15 = 1;
                }
                Invoke("kingkonghide", 3f);
                Priority = "";
                
            }*/
        }
        Invoke("hide", 3f);
    }/*
    void kingkonghide()
    {
        kingkong.SetActive(false);
       
    }
    void bellamini()
    {
        BellaMini.timer = 30;
        SceneManager.LoadScene(12);
    }
    void alicemini()
    {
        SceneManager.LoadScene(15);
    }*/
    void hide()
    {
        withwild = false;
        wildpoints = 0;
        winstreak = 1;
    }
    void newanimation()
    {
        lineanim.SetBool(animationname, true);
        Invoke("hidesp", 2.5f);
    }
    void hidesp()
    {
        sp.enabled = false;
    }
}
