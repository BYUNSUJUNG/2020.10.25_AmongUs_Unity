using UnityEngine;
using System.IO;

public class ChangingHat : MonoBehaviour
{
    public GameObject[] hat = new GameObject[12];

    private string wearingBool; // 착용 여부
    private int iWearingHatNum; // 착용 번호 



    void Start()
    {
        wearingBool = "false";
        iWearingHatNum = 0;

    }
    
    public void hat01Click() { hatMethod(1); }
    public void hat02Click() { hatMethod(2); }
    public void hat03Click() { hatMethod(3); }
    public void hat04Click() { hatMethod(4); }
    public void hat05Click() { hatMethod(5); }
    public void hat06Click() { hatMethod(6); }
    public void hat07Click() { hatMethod(7); }
    public void hat08Click() { hatMethod(8); }
    public void hat09Click() { hatMethod(9); }
    public void hat10Click() { hatMethod(10); }
    public void hat11Click() { hatMethod(11); }
    public void hat12Click() { hatMethod(12); }

    public void hatMethod(int iWearingHatNumCheck)
    {
        // 무언가 착용 O 
        if (wearingBool.Equals("true"))
        {

            // 해당 번호 착용중 -> 벗음
            if (iWearingHatNum == iWearingHatNumCheck)
            {
                Debug.Log(iWearingHatNum + "벗음");
                wearingBool = "false";
                iWearingHatNum = 0;
                hat[iWearingHatNumCheck - 1].SetActive(false);

            }
            else
            {    // 다른 것 착용중 -> 벗음 -> 해당 번호 착용
                 // 그대로 착용중이기에 wearing(true/false)값은 변경하지 않음

                hat[iWearingHatNum - 1].SetActive(false);
                hat[iWearingHatNumCheck - 1].SetActive(true);
                Debug.Log(iWearingHatNum + "벗고" + iWearingHatNumCheck + "착용");
                iWearingHatNum = iWearingHatNumCheck;
            }

        }

        else
        { // 착용 X ->  착용
            Debug.Log(iWearingHatNumCheck + "착용");
            wearingBool = "true";
            iWearingHatNum = iWearingHatNumCheck;
            hat[iWearingHatNumCheck - 1].SetActive(true);

        }

    } // end

}
