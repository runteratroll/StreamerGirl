using System.Collections.Generic;

[System.Serializable] //����ȭ JSON�� �ٷιٷ� ��ȯ��
public class User
{
    public string userName;
    public long energy;
    public long ePc; //Ŭ���� ������
    public long humans;
    
    // ���� ����? ���׷��̵�?
    public List<Ability> soldierList = new List<Ability>();
    public List<Equipment> equipmentList = new List<Equipment>();
}
