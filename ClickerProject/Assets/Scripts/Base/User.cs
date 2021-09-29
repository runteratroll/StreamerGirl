using System.Collections.Generic;

[System.Serializable] //����ȭ JSON�� �ٷιٷ� ��ȯ��
public class User
{
    public string userName;
    public long energy;
    public long ePc; //Ŭ���� ������
    public long humans;
    public int donationSpeed; //�����̼� ��� �ӵ� �⺻ 30��
    public int donationRandom; //�����̼� Ȯ��
    public int chatingSpeed;
    public int Voicepercentage;
    public int Humorpercentage;
    public int Gamepercentage;
    // ���� ����? ���׷��̵�?
    public List<Ability> soldierList = new List<Ability>();
    public List<Equipment> equipmentList = new List<Equipment>();
}
