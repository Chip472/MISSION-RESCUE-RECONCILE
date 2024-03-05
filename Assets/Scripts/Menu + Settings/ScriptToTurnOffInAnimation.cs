using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptToTurnOffInAnimation : MonoBehaviour
{
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
