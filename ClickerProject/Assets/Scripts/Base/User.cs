using System.Collections.Generic;

[System.Serializable] //직렬화 JSON이 바로바로 변환함
public class User
{
    public string userName;
    public long energy;
    public long ePc; //클릭당 에너지
    public long humans;
    public int donationSpeed; //도네이션 얻는 속도 기본 30초
    public int donationRandom; //도네이션 확률
    public int chatingSpeed;
    public int Voicepercentage;
    public int Humorpercentage;
    public int Gamepercentage;
    // 병사 갯수? 업그레이드?
    public List<Ability> soldierList = new List<Ability>();
    public List<Equipment> equipmentList = new List<Equipment>();
}
