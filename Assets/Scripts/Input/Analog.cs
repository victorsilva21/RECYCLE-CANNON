using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Analog : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] GameObject m_externalCircle, m_internalCircle;
    private Vector2 startPosition;
    public RectTransform movement;
    private RectTransform externalCircleRect;
    private bool isDragging = false;

    void Start()
    {
        startPosition = m_externalCircle.GetComponent<RectTransform>().transform.position;
        movement = m_internalCircle.GetComponent<RectTransform>();
        externalCircleRect = m_externalCircle.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = m_externalCircle.GetComponent<RectTransform>().transform.position;
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        movement.transform.position = startPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(externalCircleRect, eventData.position, null, out localPoint))
            {
                float x = (localPoint.x / (externalCircleRect.sizeDelta.x));
                float y = (localPoint.y / (externalCircleRect.sizeDelta.y));

                Vector2 offset = new Vector2(x, y);
                if (offset.magnitude > 0.5f) offset = offset.normalized * 0.45f;

                movement.localPosition = offset * externalCircleRect.sizeDelta.x ;
            }
        }    


    }
}