using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour
{
    [SerializeField] private GameObject bigPic1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPic1()
    {
        bigPic1.SetActive(true);
    }

    public void ClosePic1()
    {
        bigPic1.SetActive(false);
    }
}
