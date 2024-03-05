using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonMenuHover : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject bgButton;
    [SerializeField] private float bgY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (gameObject.GetComponent<Button>().interactable)
        {
            bgButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(bgButton.GetComponent<RectTransform>().anchoredPosition.x, bgY);
        }
    }
}
