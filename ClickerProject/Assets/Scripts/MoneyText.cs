using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class MoneyText : MonoBehaviour
{

    [SerializeField] //프리펩은 이방법을 쓸수 없다.
    private Canvas canvas = null;
    [SerializeField]
    private Transform pool = null;
    private TextMeshProUGUI monyTextMeshProUGUI = null;


    public void Show(Vector2 mousePosition) //클릭한 위치에서 나타내기위해
    {
        monyTextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        monyTextMeshProUGUI.text = string.Format("+{0}", GameManager.Instance.CurrentUser.ePc);

        transform.SetParent(canvas.transform);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, 0f);
        gameObject.SetActive(true);

        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 100f;

        monyTextMeshProUGUI.DOFade(0f, 1f).OnComplete(() => Despawn()); //람다식
         //앵커포지션을 타겟포지션으로 바꿉니다.
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f);
    }

    public void Despawn()
    {
        monyTextMeshProUGUI.DOFade(1f, 0f);
        transform.SetParent(pool);
        gameObject.SetActive(false);
    }
}
