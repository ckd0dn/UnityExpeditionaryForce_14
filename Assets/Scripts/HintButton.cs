using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    public void hintButton()
    {
        // ��Ʈ�� ������ �������� ���� ī�� �ΰ��� ���� ����.
        GameManager.instance.Hint();
    }
}
