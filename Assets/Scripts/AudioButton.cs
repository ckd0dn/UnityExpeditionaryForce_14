using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public GameObject soundPanel;

    public void  ClickSound()
    {
        soundPanel.SetActive(true);
    }

    public void ExitSound()
    {
        soundPanel.SetActive(false);
    }
   
}
