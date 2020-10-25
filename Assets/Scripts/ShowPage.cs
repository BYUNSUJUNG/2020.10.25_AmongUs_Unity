using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPage : MonoBehaviour
{
    // Color: 2, Hat: 2, Pet:3, Skin:1
    public GameObject[] pageArr = new GameObject[8];
    

    public void colorPage01() { showPage(0); }
    public void colorPage02() { showPage(1); }

    public void hatPage01() { showPage(2); }
    public void hatPage02() { showPage(3); }

    public void petPage01() { showPage(4); }
    public void petPage02() { showPage(5); }
    public void petPage03() { showPage(6); }

    public void skinPage01() { showPage(7); }


    public void showPage(int checkNum)
    {
        for (int i = 0; i< pageArr.Length; i++) {
            if (i == checkNum)
            {
                pageArr[i].SetActive(true);
            }
            else {
                pageArr[i].SetActive(false);
            }
        }
        
    }
    
    
}
