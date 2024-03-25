using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieGameManager : MonoBehaviour
{
    int dum;
    int fum;
    public GameObject coinseffect,MoreCoinseffect, MoreCoinseffect2,Lines, coins, MiniGameBttn,MiniLoading,SlotUnlockPanel;
    public Text amountext, bettext,winamounttext,winamounttext2,leveltext,playersonlinetext, GemsText;
    int totalbet,levelno, gems;
    public static int slots;
    public static float winamount, amount;
    public static int win = 0;
    public Image Spinbar,MiniGameBar;
    public SpriteMoving[] sp;
    public int MinBet, minigamescene, thisSceneNo, slotno, BetLimit;
    public AudioSource bttnsound, Spinsound,winsound,slotunlock,losesound;
    public Button[] betbttns;
    float barlevel;
    public static float miniloadvalue=0;


    public GameObject rewardpanel,Adbttn,Kingkongminipanel;

    public int spintotal = 0;
    public int nextlevelunlockvalue;
    int freespins = 0;
    public Text freespingstext;
    public static int autorotate=0;
    #region startF
    void Start()
    {
        autorotate = 0;
        slots = slotno;

        barlevel = PlayerPrefs.GetFloat("LevelBar" + thisSceneNo, 0f);
        levelno = PlayerPrefs.GetInt("Level" + thisSceneNo, 1);

        Spinbar.fillAmount = barlevel;
        totalbet = MinBet;
        amount = PlayerPrefs.GetInt("NewAllGold",500000);

        leveltext.text = "LEVEL " + PlayerPrefs.GetInt("Level",1);
        //playersonlinetext.text = Random.Range(30, 80) + "";

        gems = PlayerPrefs.GetInt("Gems", 0);
        GemsText.text = "" + gems;
        MiniGameBar.fillAmount += miniloadvalue;


    }
    #endregion
    void Update()
    {
        if (amount < totalbet)
        {
            betbttns[3].interactable = false;
        }
        bettext.text = "" + totalbet;
        amountext.text =  amount.ToString("0");
        PlayerPrefs.SetInt("NewAllGold", (int)amount);
       
        if (amount < 0) { amount = 0; }
        if (sp[0].istopped&& sp[1].istopped && sp[2].istopped && sp[3].istopped)
        {
            sp[0].istopped = false;
            Invoke("Active", 0.2f);           
            Spinbar.fillAmount += 0.01f;
            miniloadvalue += 0.05f;
            MiniGameBar.fillAmount += 0.05f;
            PlayerPrefs.SetFloat("LevelBar" + thisSceneNo, Spinbar.fillAmount);

            if (MiniGameBar.fillAmount>0.96&&thisSceneNo!=11 && thisSceneNo != 13 && thisSceneNo != 14 && thisSceneNo != 16)
            {             
                 StartCoroutine("MiniGameLaunch");                             
            }
            if (Spinbar.fillAmount>0.95&Spinbar.fillAmount<1)
            {
                Spinbar.fillAmount = 0f;
                Time.timeScale = 1f;
                levelno++;
                PlayerPrefs.SetFloat("LevelBar" + thisSceneNo, 0);
            }
            sp[0].istopped = false;
            Time.timeScale = 0.95f;
           
        }
        if (win == 1)
        {
            //  winamount = Random.Range(5, 8);
           
            amount += (totalbet * (winamount))+totalbet;
            CoinsSpwan();
            Invoke("CancelInvokes", 2.75F);
            Invoke("MoreCoins", 0.5f);
            win = 0;
        }
       /* if (kingkong == 1&&kingonetime==0)
        {
            kingonetime++;
            //  kingkongbig.SetActive(true);
            StartCoroutine("MiniGameLaunch");
            //Invoke("MiniGameLaunch", 3f);
            kingkong = 0;
        }
        */
    }
    public void Spin()
    {       
            spintotal++;
            Spinsound.Play();
            bttnsound.Play();
            if (freespins < 1)
            {
                amount -= totalbet;
                freespingstext.text = "";
            }
            else { AutoSpin(); }
            CancelInvoke();
            winamounttext.text = "";
            betbttns[0].interactable = false;
            betbttns[1].interactable = false;
            betbttns[2].interactable = false;
            betbttns[3].interactable = false;
            PlayerPrefs.SetInt("noofgames", PlayerPrefs.GetInt("noofgames", 0) + 1);
          //  kingonetime = 0;       
    }
    public void AutoSpin()
    {
        freespins--; freespingstext.text = "" + freespins;
    }
    public void Add()
    {
        bttnsound.Play();

        if (totalbet < BetLimit && amount>totalbet*2)
        {
            print("true");
            totalbet *= 2;
        }
        else
            print("false");

    }
    public void MaxBet()
    {
        bttnsound.Play();

        if (amount > BetLimit)
        {
            totalbet = BetLimit;
        }
    }
    public void Minus()
    {
        bttnsound.Play();
        betbttns[3].interactable = true;
        if (totalbet >MinBet)
        {
            totalbet/=2;
        }
    }
    void Active()
    {
        winamount = 0;
        winamounttext2.text =0+"";
        Lines.SetActive(true);
        Invoke("ActiveButtons", 0.2f);
        if (PlayerPrefs.GetInt("noofgames") == nextlevelunlockvalue)
        {
            slotunlock.Play();
            SlotUnlockPanel.SetActive(true);
            StartCoroutine("unlockpanelfalse");
        }
    }
    IEnumerator unlockpanelfalse()
    {
        yield return new WaitForSeconds(4f);
        SlotUnlockPanel.SetActive(false);
    }
    void ActiveButtons()
    {
        if (winamount < 1&&freespins<1)
        {
          //  losesound.Play();
            betbttns[0].interactable = true;
            betbttns[1].interactable = true;
            betbttns[2].interactable = true;
            betbttns[3].interactable = true;
        }
        if (freespins > 0)
        {
            Invoke("Spin",1);
            
            autorotate = 1;
        }
    }
    public void CoinsSpwan()
    {
        winsound.Play();
        winamounttext.GetComponent<Animator>().enabled = true;
        float amountwon = (totalbet *(winamount))+totalbet;
        if (amountwon > 0)
        {
            winamounttext.text = amountwon.ToString("0");// + "\n Win";
            winamounttext2.text = amountwon.ToString("0");// + "\n Win";
        }
        Invoke("CoinsSpwan", 0.1f);      
    }
    public void CancelInvokes()
    {
        winamounttext.GetComponent<Animator>().enabled = false;
        winamounttext.text = "";
        CancelInvoke();
        coinseffect.SetActive(false);
        if (freespins < 1)
        {
            betbttns[0].interactable = true;
            betbttns[1].interactable = true;
            betbttns[2].interactable = true;
            betbttns[3].interactable = true;
        }
    }
    void MoreCoins()
    {
        MoreCoinseffect.SetActive(false);
        MoreCoinseffect.SetActive(true);
    }
    void MoreCoins2()
    {
        MoreCoinseffect2.SetActive(false);
        MoreCoinseffect2.SetActive(true);
    }
    IEnumerator MiniGameLaunch()
    {
        yield return new WaitForSeconds(5f);
        MiniLoading.SetActive(true);
        SceneManager.LoadScene(minigamescene);
       

    }
  IEnumerator kingkonghide()
    {
        yield return new WaitForSeconds(2.5f);
      
    }

   
   
    public void rewardpanelOff()
    {
        rewardpanel.SetActive(false);
    }
}
