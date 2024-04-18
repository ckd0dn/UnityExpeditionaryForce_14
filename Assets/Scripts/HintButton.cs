using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void hintButton()
    {
        // 힌트를 누르면 무작위로 같은 카드 두개가 빛이 난다.
        GameManager.instance.Hint();
    }
}
