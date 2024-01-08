using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeBuffCtr : MonoBehaviour
{
    // ����� �ο� ��ư
    public Button posionBtn;
    public Button bleedingBtn;
    public Button burnBtn;

    private void Start()
    {
        Button btn = posionBtn.GetComponent<Button>();
        // ��ư Ŭ�� �̺�Ʈ �߰�
        btn.onClick.AddListener(() => 
        {
            // ĳ���� ������Ʈ�� ����� ��ũ��Ʈ �߰�
            var obj = Character.Instance.gameObject.AddComponent<PoisonDeBuff>();
            // ����� ��ũ��Ʈ �ʱ�ȭ
            obj.Initialize(1, 5, 1);
            // ����� Ȱ��ȭ
            obj.Action();
            // ĳ���� ��ũ��Ʈ�� ����� ����Ʈ�� �߰��� ����� �߰�
            Character.Instance.deBuff.Add(obj);
        });

        btn = bleedingBtn.GetComponent<Button>();
        // ��ư Ŭ�� �̺�Ʈ �߰�
        btn.onClick.AddListener(() => 
        { 
            // ĳ���� ������Ʈ�� ����� ��ũ��Ʈ �߰�
            var obj = Character.Instance.gameObject.AddComponent<BleedingDeBuff>();
            // ����� ��ũ��Ʈ �ʱ�ȭ
            obj.Initialize(2, 10, 0.5f);
            // ����� Ȱ��ȭ
            obj.Action();
            // ĳ���� ��ũ��Ʈ�� ����� ����Ʈ�� �߰��� ����� �߰�
            Character.Instance.deBuff.Add(obj);
        });

        btn = burnBtn.GetComponent<Button>();
        // ��ư Ŭ�� �̺�Ʈ �߰�
        btn.onClick.AddListener(() =>
        {
            // ĳ���� ������Ʈ�� ����� ��ũ��Ʈ �߰�
            var obj = Character.Instance.gameObject.AddComponent<BurnDeBuff>();
            // ����� ��ũ��Ʈ �ʱ�ȭ
            obj.Initialize(3, 10, 1.5f);
            // ����� Ȱ��ȭ
            obj.Action();
            // ĳ���� ��ũ��Ʈ�� ����� ����Ʈ�� �߰��� ����� �߰�
            Character.Instance.deBuff.Add(obj);
        });

    }

}
