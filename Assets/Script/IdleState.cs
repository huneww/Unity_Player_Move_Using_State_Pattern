using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonoBehaviour, IState
{

    public void Action()
    {
        // 캐릭터 움직일시
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            // 캐릭터의 상태를 MoveState로 변환
            Character.Instance.ChangeState(typeof(MoveState));
        }

        // 캐릭터 공격시
        if (Input.GetMouseButtonDown(0))
        {
            // 캐릭터의 상태를 AttackState로 변환
            Character.Instance.ChangeState(typeof(AttackState));
        }
    }
}
