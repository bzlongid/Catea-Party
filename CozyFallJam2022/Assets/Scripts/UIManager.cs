using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text topDir;
    public GameObject pointer;

    private void Start()
    {
        pointer.SetActive(false);
    }
    public void DirectToKitchen()
    {
        topDir.text = "Move right to go to kitchen.";
        pointer.SetActive(true);
    }
}
