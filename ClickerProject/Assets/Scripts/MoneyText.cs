using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class MoneyText : MonoBehaviour
{

    [SerializeField] //�������� �̹���� ���� ����.
    private Canvas canvas = null;
    [SerializeField]
    private Transform pool = null;
    private TextMeshProUGUI monyTextMeshProUGUI = null;


    public void Show(Vector2 mousePosition) //Ŭ���� ��ġ���� ��Ÿ��������
    {
        monyTextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        monyTextMeshProUGUI.text = string.Format("+{0}", GameManager.Instance.CurrentUser.ePc);

        transform.SetParent(canvas.transform);
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, 0f);
        gameObject.SetActive(true);

        RectTransform rectTransform = GetComponent<RectTransform>();
        float targetPositionY = rectTransform.anchoredPosition.y + 50f;

        monyTextMeshProUGUI.DOFade(0f, 0.5f).OnComplete(() => Despawn()); //���ٽ�
        rectTransform.DOAnchorPosY(targetPositionY, 0.5f); //��Ŀ�������� Ÿ������������ �ٲߴϴ�.
        
    }

    public void Despawn()
    {
        monyTextMeshProUGUI.DOFade(1f, 0f);
        transform.SetParent(pool);
        gameObject.SetActive(false);
    }
}
