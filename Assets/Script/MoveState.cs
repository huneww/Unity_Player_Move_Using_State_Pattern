using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : MonoBehaviour, IState
{
    public bool downW;
    public bool downS;
    public bool downA;
    public bool downD;

    public void Action()
    {
        // 이동키를 누를시 캐릭터 오브젝트 이동
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, Time.deltaTime);
            downW = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -Time.deltaTime);
            downS = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime, 0, 0);
            downD = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Time.deltaTime, 0, 0);
            downA = true;
        }

        if (downA && Input.GetKeyUp(KeyCode.A))
        {
            downA = false;
        }
        if (downD && Input.GetKeyUp(KeyCode.D))
        {
            downD = false;
        }
        if (downW && Input.GetKeyUp(KeyCode.W))
        {
            downW = false;
        }
        if (downS && Input.GetKeyUp(KeyCode.S))
        {
            downS = false;
        }

        // 아무키도 누르지 안고있다면
        if (!downW && !downA && !downS && !downD)
        {
            // 캐릭터 상태를 IdleState로 변경
            Character.Instance.ChangeState(typeof(IdleState));
        }
    }
}
