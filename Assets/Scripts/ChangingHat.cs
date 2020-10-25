using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System; // Convert.ToInt32
using Newtonsoft.Json; // JsonConvert, Formatting

public class ChangingHat : MonoBehaviour
{
    public GameObject[] hat = new GameObject[12];

    private string hatString; //파일의 모든 텍스트를 string 형태로 저장하기 위해
    private JsonData hatData; //string 형태의 데이터를 Json 형태로 변경하기 위해
    private string wearingBool; // 옷 착용 여부
    private int iWearingHatNum; // 입고 있는 옷 번호 // 배열값에 이용 // 데이터를 받을 때 사용
    private string sWearingHatNum; // 입고 있는 옷 번호 // 데이터를 저장할 때 사용

    private int iWearingHatNumCheck;



    void Start()
    {
        hatString = File.ReadAllText(Application.dataPath + "/DB/HatData.json");
        hatData = JsonMapper.ToObject(hatString);
        wearingBool = hatData["wearing"].ToString();
        iWearingHatNum = Convert.ToInt32(hatData["wearingHatNum"].ToString());

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
                wearingBool = "false";
                hat[iWearingHatNumCheck-1].SetActive(false);
            }
            else
            {    // 다른 것 착용중 -> 벗음 -> 해당 번호 착용
                // 그대로 착용중이기에 wearing(true/false)값은 변경하지 않음
                hat[iWearingHatNum - 1].SetActive(false);
                iWearingHatNum = iWearingHatNumCheck;
                hat[iWearingHatNumCheck-1].SetActive(true);
            }

        }
        else
        { // 착용 X -> 01 착용
            iWearingHatNum = iWearingHatNumCheck;
            wearingBool = "true";
            hat[iWearingHatNumCheck-1].SetActive(true);
        }

        sWearingHatNum = iWearingHatNum.ToString();
        Dictionary<string, string> DataDict = new Dictionary<string, string>
        {
            {"wearing", wearingBool},
            {"wearingHatNum", sWearingHatNum}
        };
        string json = JsonConvert.SerializeObject(DataDict, Formatting.Indented);

        File.WriteAllText(Application.dataPath + "/DB/HairData.json", json);
        Debug.Log("[wearing]: " + wearingBool + "[wearingHatNum]" + iWearingHatNum);
    } // end
    
}
