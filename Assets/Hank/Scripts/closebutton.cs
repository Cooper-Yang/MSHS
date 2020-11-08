using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closebutton : MonoBehaviour
{
    public GameObject panel;

    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
