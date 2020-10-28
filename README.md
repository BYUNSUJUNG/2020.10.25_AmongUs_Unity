# AMONG US - 캐릭터 꾸미기
![1](https://user-images.githubusercontent.com/33121924/97110316-e183d000-171b-11eb-979b-5b4dce1c2179.jpg)

## 1. 제작 기간: 2020.10.25/ 제작 인원: 1명
## 2. 주요 코드
### (1) JSON형태로 현재 착용 여부와 착용 번호를 관리
#### 1) 불러오기
```C#
petString = File.ReadAllText(Application.dataPath + "/DB/PetData.json"); // 저장된 정보 불러오기
petData = JsonMapper.ToObject(petString);
wearingBool = petData["wearing"].ToString(); // 착용 여부
iWearingPetNum = Convert.ToInt32(petData["wearingPetNum"].ToString()); // 착용 번호

```
#### 2) 저장하기
```C#
sWearingPetNum = iWearingPetNum.ToString();
Dictionary<string, string> DataDict = new Dictionary<string, string>
{
    {"wearing", wearingBool},
    {"wearingPetNum", sWearingPetNum}
};
string json = JsonConvert.SerializeObject(DataDict, Formatting.Indented);

File.WriteAllText(Application.dataPath + "/DB/PetData.json", json);
```
### (2) 착용 상태와 미착용 상태에 따른 처리
```C#
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
{ // 착용 X -> 착용
    iWearingPetNum = iWearingPetNumCheck;
    wearingBool = "true";
    pet[iWearingPetNumCheck - 1].SetActive(true);
}
```

## 3. 실제 어몽어스와 비교
![2](https://user-images.githubusercontent.com/33121924/97109567-4d176e80-1717-11eb-9e11-9f539e935305.jpg)
### (1) 같은 점
#### 1) 클릭으로 선택
#### 2) Color, Hat, Pet, Skin 카테고리 구성

### (2) 다른 점
#### 실제 어몽어스에서는
#### 1) 어몽어스 자식 Pet은 똑같은 색만 가능
#### 2) 스크롤 사용

## 4. 착용 가능 이미지
![3](https://user-images.githubusercontent.com/33121924/97110313-e052a300-171b-11eb-8077-ed6a9bebef8c.jpg)

## 5. 이후 업데이트 해보고 싶은 것
### (1) 사용자가 닉네임을 직접 변경
### (2) 캐릭터 여러개 제작 가능
### (3) 제작 캐릭터로 여러 포즈 취해서 이미지 저장 
