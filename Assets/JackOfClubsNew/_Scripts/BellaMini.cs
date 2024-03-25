using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BellaMini : MonoBehaviour
{
    int ala, alu;
    float oaa;
    public GameObject  Effects, Effects1, Effects2, GemsEffect, bttn, Sounds,popup,red;
    public Text totalcoinstext,timertext, GemsText, Winamounttext, leveltext;
    int totalcoins = 0;
    int gems;
    public AudioSource winningsound,losesound,extrasound;
    public static int whichcard,previouscard,streak=0;
    public static float timer = 30;
    public GameObject[] Pair1, Pair2, Pair3;//, Pair4, Pair5, Pair6;
    public int thissceneno;
    public static int rightselect;
    public static int playaudio;
    public static int wrongselect;
    void Start()
    {
        streak = 0;
        wrongselect = 0;
        rightselect = 0;
        GemsText.text = "" + gems;
        ZombieGameManager.miniloadvalue = 0;
        leveltext.text = "LEVEL " + PlayerPrefs.GetInt("Level");
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            Sounds.SetActive(false);
        }
        Pair1[Random.Range(0, 3)].SetActive(true);
        Pair2[Random.Range(0, 3)].SetActive(true);
        Pair3[Random.Range(0, 3)].SetActive(true);
      //  Pair4[Random.Range(0, 3)].SetActive(true);
      //  Pair5[Random.Range(0, 3)].SetActive(true);
      //  Pair6[Random.Range(0, 3)].SetActive(true);
        if (thissceneno == 15)
        {
            timer = 15;
        }
    }
    private void Update()
    {
        if (timer < 0)
        {
            timer = 0;
            red.SetActive(true);
            if (thissceneno == 12)
            {
                SceneManager.LoadScene("BellNAntonie");
            }
            else
            {
              //  losesound.Play();
                SceneManager.LoadScene("Alice");
            }
        }
        timer -= Time.deltaTime;
        timertext.text = "" + timer.ToString("0");
        if ((whichcard == 1 && previouscard == 2)|| (whichcard == 2 && previouscard == 1))
        {
            Invoke("Win", 1);
            whichcard = 0;
        }
        if (rightselect == 1)
        {
            Invoke("Win", 1);
            rightselect = 0;
            extrasound.Play();
        }
        if (playaudio == 1&&thissceneno==15)
        {
          //  totalcoins -= 1000;
         //   totalcoinstext.text = "" + totalcoins;
            losesound.Play();
            playaudio = 0;
        }
    }
    public static void resultupdate()
    {
        if (streak == 2)
        {
            
        }
        else
        {
            previouscard = whichcard;
        }
        
    }
    IEnumerator totalcoinscounting()
    {   
        totalcoinstext.text = "" + totalcoins;
        yield return new WaitForSeconds(0f);
        StartCoroutine(totalcoinscounting());
    }
    public void Win()
    {
        popup.SetActive(true);
        
        if (thissceneno == 15)
        {
            totalcoins+= 100000;
        }
        else
        {
            totalcoins = 5000;
        }
        Winamounttext.text = "Win \n" + totalcoins;
        // Effects.SetActive(true);
        //StartCoroutine(totalcoinscounting());
        // Invoke("Moretotalcoins1", 0.5f);
        Invoke("again", 2f);

        // winningsound.Play();
    }
    void Moretotalcoins1()
    {
        Effects1.SetActive(false);
        Effects1.SetActive(true);
        Invoke("Moretotalcoins2", 1f);
    }
    void Moretotalcoins2()
    {
        Effects2.SetActive(false);
        Effects2.SetActive(true);
        GemsEffect.SetActive(false);
        GemsEffect.SetActive(true);
        gems += Random.Range(2, 5);
        GemsText.text = "" + gems;
        Invoke("again", 2f);
    }
 
    public void again()
    {      
        PlayerPrefs.SetInt("NewAllGold", PlayerPrefs.GetInt("NewAllGold") + totalcoins);
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") + gems);
        streak = 0;
        previouscard = -1;whichcard = -1;

       // if (thissceneno == 12)
      //  {
      //      SceneManager.LoadScene("Bella Mini");
      //  }
     ///   else
      //  {
            SceneManager.LoadScene(2);
      //  }
        //StopAllCoroutines();
        //CancelInvoke();
    }
}
