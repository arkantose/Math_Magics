using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private ButtonManager _buttonManager;
    private Image _image;
    public bool notanswered;
    public void OnDrop(PointerEventData eventData)
    {
        
        if (notanswered == false)
        {

            if (eventData.pointerDrag.name == "Answer_Is_Prime")
            {
                notanswered = true;
                eventData.pointerDrag.GetComponent<Drag>().oldPosition = _image.rectTransform.localPosition;
                eventData.pointerDrag.GetComponent<Drag>().ResetPosition();
                _buttonManager.IncreaseScore();
                _buttonManager.rightOrWrong.text = "Correct";
                _buttonManager.nextProblem.gameObject.SetActive(true);
                _buttonManager.FireworksOn();

            }
            else if (eventData.pointerDrag.name != "Answer_Is_Prime")
            {
                var drop = eventData.pointerDrag.GetComponent<Drag>();
                drop.ResetPosition();
                _buttonManager.rightOrWrong.text = "Wrong Answer";
                _buttonManager.DecreaseScore();
            }

        }


    }

    public void TurnOffAnsered()
    {
        notanswered = false;
    }

    void Start()
    {
        _image = GetComponent<Image>();
    }



}
