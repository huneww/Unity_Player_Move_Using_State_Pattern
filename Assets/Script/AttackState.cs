using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, IState
{
    // �ڷ�ƾ ���� ����
    Coroutine coroutine;

    public void Action()
    {
        Debug.Log("Attack!");
        // �ڷ�ƾ�� ���������� �ʴٸ�
        // �ڷ�ƾ�� ����
        if (coroutine == null)
        {
            coroutine = StartCoroutine(ReturnIdle());
        }
    }

    private IEnumerator ReturnIdle()
    {
        // 0.5���� �ٽ� IdleState�� ĳ���� ���� ��ȯ
        yield return new WaitForSeconds(0.5f);

        Character.Instance.ChangeState(typeof(IdleState));
    }

    private void Update()
    {
        // �ٽ� �ѹ� ���콺 Ŭ����
        if (Input.GetMouseButtonDown(0))
        {
            // �ڷ�ƾ�� ����
            StopCoroutine(coroutine);
            // ���� ���� ��ũ��Ʈ�� ĳ���� ���� ��ȯ
            Character.Instance.ChangeState(typeof(AttackState1));
        }
    }

}
