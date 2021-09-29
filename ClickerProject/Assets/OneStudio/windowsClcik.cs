using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowsClcik : MonoBehaviour
{

    Vector2 direction;

    [SerializeField] //프리펩은 이방법을 쓸수 없다.
    private Canvas canvas = null;
    [SerializeField]
    private Transform pool = null;

    public float moveSpeed = 0.1f;

    public float sizeSpeed = 1f;




    public void Show(Vector2 mousePosition)
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        transform.localScale = new Vector2(1, 1);


        transform.SetParent(canvas.transform);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.Translate(direction * moveSpeed);
        transform.localScale = Vector2.Lerp(transform.localScale,
            Vector2.zero, Time.deltaTime * sizeSpeed);
        gameObject.SetActive(true);


            Invoke("Despawn", 1f);
    }    
 


    public void Despawn()
    {
      
        transform.SetParent(pool.transform);
        gameObject.SetActive(false);
    }
}
