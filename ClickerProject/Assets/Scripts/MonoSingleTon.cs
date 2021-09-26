using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ƽ�����尡 ��������!
// T�� �ƹ��ų� ���� �� ����
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //������Ʈ �ƹ��ų� ��밡���ϴ�
    private static bool shuttingDown = false; //���α׷��� �������!
    private static object locker = new object();
    private static T instance = null;  //�ƹ�Ÿ���̳� �� �� �ִٴ� ��?
    public static T Instance
    {
        get
        {
            if (shuttingDown)
            {
                //�� �ڵ尡 ������ �ֱ���!~
                Debug.LogWarning("[Instance] instance " + typeof(T) + " is already destroyed. Returning null.");
                return null;
            }

            lock (locker)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {

                        //GameManager ����� ���̸��� ��
                        instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                        DontDestroyOnLoad(instance); //������Ʈ ������ �������̾� 2���������� �ּ�ȭ
                    }
                }
                return instance;
            }
        }
    }

    private void OnDestroy() //
    {
        shuttingDown = true;
    }

    private void OnApplicationQuit() //
    {
        shuttingDown = true;
    }
}
