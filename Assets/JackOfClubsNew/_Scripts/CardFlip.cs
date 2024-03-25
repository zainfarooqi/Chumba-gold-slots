using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    int tester;
    float aa;
    public Animator cardanim;
    int onetime = 0;
    private void Update()
    {
        if (BellaMini.wrongselect==1&&onetime==0)
        {
            
            BellaMini.playaudio = 1;
            BellaMini.streak = 0;
            Invoke("idle", 1f);
            onetime = 1;
        }
     
    }
    public void OnClick(int no)
    {
        cardanim.SetBool("flip", true);
        cardanim.SetBool("idle", false);
        if (no == 1 || no == 2)
        {
            BellaMini.whichcard = no;
            BellaMini.wrongselect = 0;
            onetime = 0;
            BellaMini.streak++;
            BellaMini.resultupdate();
            
        }
        else if(no==5)
        {
            BellaMini.rightselect = 1;
        }
        else 
        {
            BellaMini.whichcard = 0; BellaMini.previouscard = 0;
            BellaMini.wrongselect = 1;
            onetime = 0;
            BellaMini.playaudio = 1;
            BellaMini.streak = 0;
            Invoke("idle", 1f);
        }     
    }
    void idle()
    {
        cardanim.SetBool("flip", false);
        cardanim.SetBool("idle", true);
    }
}
