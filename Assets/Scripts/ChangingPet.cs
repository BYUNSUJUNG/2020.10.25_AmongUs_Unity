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
    private string wearingBool; // 옷 착용 여부
    private int iWearingPetNum; // 입고 있는 옷 번호 // 배열값에 이용 // 데이터를 받을 때 사용
    private string sWearingPetNum; // 입고 있는 옷 번호 // 데이터를 저장할 때 사용

    private int iWearingPetNumCheck;



    void Start()
    {
        petString = File.ReadAllText(Application.dataPath + "/DB/PetData.json");
        petData = JsonMapper.ToObject(petString);
        wearingBool = petData["wearing"].ToString();
        iWearingPetNum = Convert.ToInt32(petData["wearingPetNum"].ToString());

    }
    
    public void pet01Click() { hatMethod(1); }
    public void pet02Click() { hatMethod(2); }
    public void pet03Click() { hatMethod(3); }
    public void pet04Click() { hatMethod(4); }
    public void pet05Click() { hatMethod(5); }
    public void pet06Click() { hatMethod(6); }
    public void pet07Click() { hatMethod(7); }
    public void pet08Click() { hatMethod(8); }
    public void pet09Click() { hatMethod(9); }
    public void pet10Click() { hatMethod(10); }
    public void pet11Click() { hatMethod(11); }
    public void pet12Click() { hatMethod(12); }
    public void pet13Click() { hatMethod(13); }



    // 모자 처리
    public void hatMethod(int iWearingHatNumCheck)
    {
        // 머리을 이미 쓰고 있음
        if (wearingBool.Equals("true"))
        {
            // 01머리을 이미 쓰고 있음 -> 벗음
            if (iWearingPetNum == iWearingHatNumCheck)
            {
                wearingBool = "false";
                pet[iWearingHatNumCheck-1].SetActive(false);
            }
            else
            {   // 다른 머리를 쓰고 있음 -> 해당 머리를 벗기고 01머리을 씀
                // 그대로 옷입고 있기에 wearing(true/false)값은 변경하지 않음
                pet[iWearingPetNum - 1].SetActive(false);
                iWearingPetNum = iWearingHatNumCheck;
                pet[iWearingHatNumCheck-1].SetActive(true);
            }

        }
        else
        { // 머리을 이미 쓰고 있음 -> 01머리를 씀
            iWearingPetNum = iWearingHatNumCheck;
            wearingBool = "true";
            pet[iWearingHatNumCheck-1].SetActive(true);
        }

        sWearingPetNum = iWearingPetNum.ToString();
        Dictionary<string, string> DataDict = new Dictionary<string, string>
        {
            {"wearing", wearingBool},
            {"wearingHairNum", sWearingPetNum}
        };
        string json = JsonConvert.SerializeObject(DataDict, Formatting.Indented);

        File.WriteAllText(Application.dataPath + "/DB/HairData.json", json);
        Debug.Log("[wearing]: " + wearingBool + "[wearingHairNum]" + iWearingPetNum);
    } // end
    
}
