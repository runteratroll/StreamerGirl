//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ChatingChang : MonoBehaviour
//{
//    public static ChatingChang Instance;

//    [SerializeField]
//    private GameObject ChatingPrefab;

    
//    Queue<TwichUser> poolingObjectQueue = new Queue<TwichUser>();

//    private void Awake()
//    {
//        Instance = this;

//        Initialize(10);
//    }
    
//    private void Initialize(int initCount)
//    {
//        for(int i =0; i< initCount; i++)
//        {
//            poolingObjectQueue.Enqueue(CreateNewObject());
//        }
//    }


//    private TwichUser CreateNewObject()
//    {
//        var newObj = Instantiate(ChatingPrefab).GetComponent<TwichUser>();
//        newObj.gameObject.SetActive(false);
//        newObj.transform.SetParent(Instance.transform);
//        return newObj;
      
//    }

//    public static TwichUser GetObject()
//    {
//        if (Instance.poolingObjectQueue.Count > 0)
//        {
//            var obj = Instance.poolingObjectQueue.Dequeue();
//            obj.transform.SetParent(null);
//            obj.gameObject.SetActive(true);
//            return obj;
//        }
//        else
//        {
//            var newObj = Instance.CreateNewObject();
//            newObj.gameObject.SetActive(true);
//            newObj.transform.SetParent(null);
//            return newObj;
//        }
//    }

//    public static void ReturnObject(TwichUser obj)
//    {
//        obj.gameObject.SetActive(false);
//        obj.transform.SetParent(Instance.transform);
//        Instance.poolingObjectQueue.Enqueue(obj);
//    }





//}
