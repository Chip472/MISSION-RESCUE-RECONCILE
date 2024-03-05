using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSettingsHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator menuAnim;
    public bool check = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (check == false)
        {
            menuAnim.Play("FadeInArrowBoard", 0);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (check == false)
        {
            menuAnim.Play("FadeOutArrowBoard", 0);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
