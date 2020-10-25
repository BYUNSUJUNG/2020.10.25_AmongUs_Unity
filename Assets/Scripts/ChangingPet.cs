using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System; // Convert.ToInt32
using Newtonsoft.Json; // JsonConvert, Formatting

public class ChangingPet : MonoBehaviour
{
    public GameObject[] pet = new GameObject[13];

    private string petString; //파일의 모든 텍스트를 string 형태로 저장하기 위해
    private JsonData petData; //string 형태의 데이터를 Json 형태로 변경하기 위해
    private string wearingBool; // 착용 여부
    private int iWearingPetNum; // 착용 번호 // 배열값에 이용 // 데이터를 받을 때 사용
    private string sWearingPetNum; // 착용 번호 // 데이터를 저장할 때 사용

    private int iWearingPetNumCheck;



    void Start()
    {
        petString = File.ReadAllText(Application.dataPath + "/DB/PetData.json");
        petData = JsonMapper.ToObject(petString);
        wearingBool = petData["wearing"].ToString();
        iWearingPetNum = Convert.ToInt32(petData["wearingPetNum"].ToString());

    }
    
    public void pet01Click() { petMethod(1); }
    public void pet02Click() { petMethod(2); }
    public void pet03Click() { petMethod(3); }
    public void pet04Click() { petMethod(4); }
    public void pet05Click() { petMethod(5); }
    public void pet06Click() { petMethod(6); }
    public void pet07Click() { petMethod(7); }
    public void pet08Click() { petMethod(8); }
    public void pet09Click() { petMethod(9); }
    public void pet10Click() { petMethod(10); }
    public void pet11Click() { petMethod(11); }
    public void pet12Click() { petMethod(12); }
    public void pet13Click() { petMethod(13); }


    public void petMethod(int iWearingPetNumCheck)
    {
        // 무언가 착용 O 
        if (wearingBool.Equals("true"))
        {
            // 해당 번호 착용중 -> 벗음
            if (iWearingPetNum == iWearingPetNumCheck)
            {
                wearingBool = "false";
                pet[iWearingPetNumCheck - 1].SetActive(false);
            }
            else
            {   // 다른 것 착용중 -> 벗음 -> 해당 번호 착용
                // 그대로 착용중이기에 wearing(true/false)값은 변경하지 않음
                pet[iWearingPetNum - 1].SetActive(false);
                iWearingPetNum = iWearingPetNumCheck;
                pet[iWearingPetNumCheck - 1].SetActive(true);
            }

        }
        else
        { // 착용 X -> 01 착용
            iWearingPetNum = iWearingPetNumCheck;
            wearingBool = "true";
            pet[iWearingPetNumCheck - 1].SetActive(true);
        }

        sWearingPetNum = iWearingPetNum.ToString();
        Dictionary<string, string> DataDict = new Dictionary<string, string>
        {
            {"wearing", wearingBool},
            {"wearingPetNum", sWearingPetNum}
        };
        string json = JsonConvert.SerializeObject(DataDict, Formatting.Indented);

        File.WriteAllText(Application.dataPath + "/DB/PetData.json", json);
        Debug.Log("[wearing]: " + wearingBool + "[wearingPetNum]" + iWearingPetNum);
    } // end
    
}
