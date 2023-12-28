using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{

    public void Action()
    {
        // ĳ���� �����Ͻ�
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            // ĳ������ ���¸� MoveState�� ��ȯ
            Character.Instance.ChangeState(typeof(MoveState));
        }

        // ĳ���� ���ݽ�
        if (Input.GetMouseButtonDown(0))
        {
            // ĳ������ ���¸� AttackState�� ��ȯ
            Character.Instance.ChangeState(typeof(AttackState));
        }
    }
}
