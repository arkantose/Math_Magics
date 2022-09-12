using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Image _imageDrop;
    public Vector3 oldPosition;
    [SerializeField]
    private Drop _drop;


    public void OnBeginDrag(PointerEventData eventData)
    {
       
      
            var temp = _imageDrop.color;
            temp.a = 0.5f;
            _imageDrop.color = temp;
            _imageDrop.raycastTarget = false;
            oldPosition = _imageDrop.rectTransform.localPosition;
      
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_drop.notanswered == false)
        {
            transform.position = eventData.position;
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var temp = _imageDrop.color;
        temp.a = 1.0f;
        _imageDrop.color = temp;
        _imageDrop.raycastTarget = true;
    }

    public void ResetPosition()
    {
        _imageDrop.rectTransform.localPosition = oldPosition;
    }


}
