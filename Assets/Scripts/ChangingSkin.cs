using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System; // Convert.ToInt32
using Newtonsoft.Json; // JsonConvert, Formatting

public class ChangingSkin : MonoBehaviour
{
    public GameObject[] skin = new GameObject[6];

    private string skinString; //파일의 모든 텍스트를 string 형태로 저장하기 위해
    private JsonData skinData; //string 형태의 데이터를 Json 형태로 변경하기 위해
    private string wearingBool; // 옷 착용 여부
    private int iWearingSkinNum; // 입고 있는 옷 번호 // 배열값에 이용 // 데이터를 받을 때 사용
    private string sWearingSkinNum; // 입고 있는 옷 번호 // 데이터를 저장할 때 사용

    private int iWearingSkinNumCheck;
    

    void Start()
    {
        skinString = File.ReadAllText(Application.dataPath + "/DB/SkinData.json");
        skinData = JsonMapper.ToObject(skinString);
        wearingBool = skinData["wearing"].ToString();
        iWearingSkinNum = Convert.ToInt32(skinData["wearingSkinNum"].ToString());

    }
    
    public void skin01Click() { skinMethod(1); }
    public void skin02Click() { skinMethod(2); }
    public void skin03Click() { skinMethod(3); }
    public void skin04Click() { skinMethod(4); }
    public void skin05Click() { skinMethod(5); }
    public void skin06Click() { skinMethod(6); }

    
    public void skinMethod(int iWearingSkinNumCheck)
    {

        // 무언가 착용 O
        if (wearingBool.Equals("true"))
        {
            // 해당 번호 착용중 -> 벗음
            if (iWearingSkinNum == iWearingSkinNumCheck)
            {
                wearingBool = "false";
                skin[iWearingSkinNumCheck-1].SetActive(false);
            }
            else
            {   // 다른 것 착용중 -> 벗음 -> 해당 번호 착용
                // 그대로 착용중이기에 wearing(true/false)값은 변경하지 않음
                skin[iWearingSkinNum - 1].SetActive(false);
                iWearingSkinNum = iWearingSkinNumCheck;
                skin[iWearingSkinNumCheck - 1].SetActive(true);
            }

        }
        else
        {   // 착용 X -> 01 착용
            iWearingSkinNum = iWearingSkinNumCheck;
            wearingBool = "true";
            skin[iWearingSkinNumCheck - 1].SetActive(true);
        }

        sWearingSkinNum = iWearingSkinNum.ToString();
        Dictionary<string, string> DataDict = new Dictionary<string, string>
        {
            {"wearing", wearingBool},
            {"wearingSkinNum", sWearingSkinNum}
        };
        string json = JsonConvert.SerializeObject(DataDict, Formatting.Indented);

        File.WriteAllText(Application.dataPath + "/DB/SkinData.json", json);
        Debug.Log("[wearing]: " + wearingBool + "[wearingSkinNum]" + iWearingSkinNum);
    } // end
    
}
