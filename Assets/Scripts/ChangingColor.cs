using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System; // Convert.ToInt32
using Newtonsoft.Json; // JsonConvert, Formatting

public class ChangingColor : MonoBehaviour
{
    public GameObject[] color = new GameObject[12];

    private string colorString; //파일의 모든 텍스트를 string 형태로 저장하기 위해
    private JsonData colorData; //string 형태의 데이터를 Json 형태로 변경하기 위해
    private string wearingBool; // 착용 여부
    private int iWearingColorNum; // 착용 번호 // 배열값에 이용 // 데이터를 받을 때 사용
    private string sWearingColorNum; // 착용 번호 // 데이터를 저장할 때 사용

    private int iWearingHatNumCheck;



    void Start()
    {
        colorString = File.ReadAllText(Application.dataPath + "/DB/ColorData.json");
        colorData = JsonMapper.ToObject(colorString);
        wearingBool = colorData["wearing"].ToString();
        iWearingColorNum = Convert.ToInt32(colorData["wearingColorNum"].ToString());

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


    public void colorMethod(int iWearingHatNumCheck)
    {
        // 무언가 착용 O 
        if (wearingBool.Equals("true"))
        {
            // 컬러는 캐릭터 자체이기에 다시한번 눌려도 그래도 유지상태
            /*
            // 해당 번호 착용중 -> 벗음
            if (iWearingColorNum == iWearingHatNumCheck)
            {
                wearingBool = "false";
                color[iWearingHatNumCheck - 1].SetActive(false);
            }*/
            //else
            //{    // 다른 것 착용중 -> 벗음 -> 해당 번호 착용
                // 그대로 착용중이기에 wearing(true/false)값은 변경하지 않음
                color[iWearingColorNum - 1].SetActive(false);
                iWearingColorNum = iWearingHatNumCheck;
                color[iWearingHatNumCheck - 1].SetActive(true);
            //}

        }
        else
        { // 착용 X -> 01 착용
            iWearingColorNum = iWearingHatNumCheck;
            wearingBool = "true";
            color[iWearingHatNumCheck - 1].SetActive(true);
        }

        sWearingColorNum = iWearingColorNum.ToString();
        Dictionary<string, string> DataDict = new Dictionary<string, string>
        {
            {"wearing", wearingBool},
            {"wearingColorNum", sWearingColorNum}
        };
        string json = JsonConvert.SerializeObject(DataDict, Formatting.Indented);

        File.WriteAllText(Application.dataPath + "/DB/ColorData.json", json);
        Debug.Log("[wearing]: " + wearingBool + "[wearingColorNum]" + iWearingColorNum);
    } // end

}
