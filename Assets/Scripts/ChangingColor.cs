using UnityEngine;
using System.IO;


public class ChangingColor : MonoBehaviour
{
    public GameObject[] color = new GameObject[12];

    private string wearingBool; // 착용 여부
    private int iWearingColorNum; // 착용 번호 



    void Start()
    {
        wearingBool = "false";
        iWearingColorNum = 0;

    }

    public void color01Click() { colorMethod(1); }
    public void color02Click() { colorMethod(2); }
    public void color03Click() { colorMethod(3); }
    public void color04Click() { colorMethod(4); }
    public void color05Click() { colorMethod(5); }
    public void color06Click() { colorMethod(6); }
    public void color07Click() { colorMethod(7); }
    public void color08Click() { colorMethod(8); }
    public void color09Click() { colorMethod(9); }
    public void color10Click() { colorMethod(10); }
    public void color11Click() { colorMethod(11); }
    public void color12Click() { colorMethod(12); }

    public void colorMethod(int iWearingColorNumCheck)
    {
        // 무언가 착용 O 
        if (wearingBool.Equals("true"))
        {

            // 해당 번호 착용중 -> 벗음
            if (iWearingColorNum == iWearingColorNumCheck)
            {
                Debug.Log(iWearingColorNum + "벗음");
                wearingBool = "false";
                iWearingColorNum = 0;
                color[iWearingColorNumCheck - 1].SetActive(false);

            }
            else
            {    // 다른 것 착용중 -> 벗음 -> 해당 번호 착용
                 // 그대로 착용중이기에 wearing(true/false)값은 변경하지 않음

                color[iWearingColorNum - 1].SetActive(false);
                color[iWearingColorNumCheck - 1].SetActive(true);
                Debug.Log(iWearingColorNum + "벗고" + iWearingColorNumCheck + "착용");
                iWearingColorNum = iWearingColorNumCheck;
            }

        }

        else
        { // 착용 X ->  착용
            Debug.Log(iWearingColorNumCheck + "착용");
            wearingBool = "true";
            iWearingColorNum = iWearingColorNumCheck;
            color[iWearingColorNumCheck - 1].SetActive(true);

        }

    } // end

}
