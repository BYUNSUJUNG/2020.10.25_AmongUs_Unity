using UnityEngine;
using System.IO;

public class ChangingPet : MonoBehaviour
{
    public GameObject[] pet = new GameObject[13];

    private string wearingBool; // 착용 여부
    private int iWearingPetNum; // 착용 번호 



    void Start()
    {
        wearingBool = "false";
        iWearingPetNum = 0;

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
                Debug.Log(iWearingPetNum + "벗음");
                wearingBool = "false";
                iWearingPetNum = 0;
                pet[iWearingPetNumCheck - 1].SetActive(false);

            }
            else
            {    // 다른 것 착용중 -> 벗음 -> 해당 번호 착용
                 // 그대로 착용중이기에 wearing(true/false)값은 변경하지 않음

                pet[iWearingPetNum - 1].SetActive(false);
                pet[iWearingPetNumCheck - 1].SetActive(true);
                Debug.Log(iWearingPetNum + "벗고" + iWearingPetNumCheck + "착용");
                iWearingPetNum = iWearingPetNumCheck;
            }

        }

        else
        { // 착용 X ->  착용
            Debug.Log(iWearingPetNumCheck + "착용");
            wearingBool = "true";
            iWearingPetNum = iWearingPetNumCheck;
            pet[iWearingPetNumCheck - 1].SetActive(true);

        }

    } // end

}
