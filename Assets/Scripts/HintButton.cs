using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void hintButton()
    {
        // ��Ʈ�� ������ �������� ���� ī�� �ΰ��� ���� ����.
        GameManager.instance.Hint();
    }
}
