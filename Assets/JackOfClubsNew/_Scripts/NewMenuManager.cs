using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewMenuManager : MonoBehaviour
{
    int asd;
    int ygh;
    [SerializeField]
    private GameObject WelcomeScreen, loadingscreen,StartTimerGO;
    public Text goldText, goldText2;
    public AudioSource bttnsound,Backsound,welcomesound,welcomeagainsound;
    public Text timertokenText,timertext2;

    bool callTimer = false;
    //private float currentTime = 3600f;
    int gold;

   // public static int firsttime = 0;
    public static int fromslot = 0;
    public GameObject lockScreen, lockscreen2, NotEnoughGoldPanel,timerlock;
   
    private void Start()
    {
       // PlayerPrefs.SetInt("NewAllGold", 500000);

        if (PlayerPrefs.GetInt("lock1") == 1)
        {
            lockScreen.SetActive(false);
        }
        if (PlayerPrefs.GetInt("lock2") == 1)
        {
            lockscreen2.SetActive(false);
        }

        ZombieGameManager.miniloadvalue = 0;
        PlayerPrefs.SetInt("LastScene", 0);
        if (PlayerPrefs.GetInt("firsttime") == 0)
        {
            PlayerPrefs.SetInt("firsttime", 1);
            gold = PlayerPrefs.GetInt("NewAllGold", 50000);
            PlayerPrefs.SetInt("NewAllGold", gold);
            WelcomeScreen.SetActive(true);

        }


        PlayerPrefs.SetInt("Level", 1);
        if (PlayerPrefs.GetInt("noofgames", 0) > 49)
        {
            //SlotButtons[0].interactable = true;
            //Locks[0].SetActive(false);
            PlayerPrefs.SetInt("Level", 2);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 99)
        {
            //SlotButtons[1].interactable = true;
            //Locks[1].SetActive(false);
            PlayerPrefs.SetInt("Level", 3);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 199)
        {
            //SlotButtons[2].interactable = true;
            //Locks[2].SetActive(false);
            PlayerPrefs.SetInt("Level", 4);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 249)
        {
            // SlotButtons[3].interactable = true;
            // Locks[3].SetActive(false);
            PlayerPrefs.SetInt("Level", 5);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 299)
        {
            //  SlotButtons[4].interactable = true;
            //  Locks[4].SetActive(false);
            PlayerPrefs.SetInt("Level", 6);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 349)
        {
            //SlotButtons[5].interactable = true;
            //Locks[5].SetActive(false);
            PlayerPrefs.SetInt("Level", 7);
        }
        if (PlayerPrefs.GetInt("noofgames", 0) > 399)
        {
            // SlotButtons[6].interactable = true;
            // Locks[6].SetActive(false);
            PlayerPrefs.SetInt("Level", 8);
        }
        if (PlayerPrefs.GetInt("callTimer") == 1)
        {
            StartTimerGO.SetActive(true);
            timerlock.SetActive(true);
        }
        else
        {
            StartTimerGO.SetActive(false);
            timerlock.SetActive(false);
        }

    }
    public void BuyNewSlotGame(int INDEX)
    {
        if(PlayerPrefs.GetInt("NewAllGold")>=55000 && INDEX == 0)
        {
            PlayerPrefs.SetInt("lock1", 1);
            PlayerPrefs.SetInt("NewAllGold", PlayerPrefs.GetInt("NewAllGold") - 55000);
            loadingscreen.SetActive(true);
            bttnsound.Play();
            StartCoroutine(Fade(5));
        }
        else if (PlayerPrefs.GetInt("NewAllGold") >= 75000 && INDEX == 1)
        {
            PlayerPrefs.SetInt("lock2", 1);
            PlayerPrefs.SetInt("NewAllGold", PlayerPrefs.GetInt("NewAllGold") - 75000);
            loadingscreen.SetActive(true);
            bttnsound.Play();
            StartCoroutine(Fade(6));
        }
        else
        {
            NotEnoughGoldPanel.SetActive(true);
        }
    }
    public void PlayGame(int index)
    {
        loadingscreen.SetActive(true);

        StartCoroutine(Fade(index));
    }
    private void Update()
    {
        goldText.text = PlayerPrefs.GetInt("NewAllGold").ToString();
       // goldText2.text = PlayerPrefs.GetInt("NewAllGold").ToString();

        if (PlayerPrefs.GetInt("callTimer")==1)
        {
           float currentTime = PlayerPrefs.GetFloat("currentTime") - 1 * Time.deltaTime;
            PlayerPrefs.SetFloat("currentTime", currentTime);
            // Convert timer to hours, minutes, and seconds
            float hours = Mathf.FloorToInt(currentTime / 3600);
            float minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            // Update the UI Text with the timer information
            timertokenText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
           // timertext2.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds); ;
            // Check if the timer has reached zero
            if (PlayerPrefs.GetFloat("currentTime") <= 0)
            {
                Debug.Log("Timer has reached zero!");
                StartTimerGO.SetActive(false);
                timerlock.SetActive(false);

                PlayerPrefs.SetInt("callTimer", 0);

            }
        }

    }
    public void PlayMiniGame()
    {
        PlayerPrefs.SetInt("callTimer", 1);
        PlayerPrefs.SetFloat("currentTime", 3600);

        StartTimerGO.SetActive(true);
        bttnsound.Play();
        StartCoroutine(Fade(4));
    }
    IEnumerator Fade(int s)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(s);
    }
    void welcome()
    {
        welcomesound.Play();
    }
    void welcomeagain()
    {
        welcomeagainsound.Play();
    }

    void BackSoundActive()
    {
        Backsound.Play();
    }

    
    
    public void loading()
    {
        loadingscreen.SetActive(true);
    }
  
  
   
   
    
   
   
   
    
}
