using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // 싱글톤 패턴
    private static readonly object _lock = new object();
    private static Character instance;
    public static Character Instance
    {
        get
        {
            lock(_lock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<Character>();

                    if (instance == null)
                    {
                        GameObject ch = new GameObject();
                        instance = ch.AddComponent<Character>();
                        ch.name = "Character";
                    }
                }

                return instance;
            }
        }
    }

    // 캐릭터 현재 상태 텍스트
    public Text stateText;
    // 캐릭터 상태 열거형 변수
    //private STATE curState;
    // 현재 상태 스크립트 저장 변수
    private IState state;

    public float speed = 5f;

    void Start()
    {
        // 상태를 IdleState로 변경
        // 상태를 state에 저장
        state = gameObject.AddComponent<IdleState>();

        // 현재 상태를 IDLE로 변경
        //curState = STATE.IDLE;

        // 현재 상태를 확인
        // 텍스트 변경
        CheckState(typeof(IdleState));
    }

    private void Update()
    {
        // 현재 상태에 있는 Action함수를 계속 호출
        state.Action();
    }

    // 컴포넌트를 오브젝트에 추가하위해서
    // Type형태로 매개변수를 설정
    public void ChangeState(System.Type newState)
    {
        // 현재 상태를 확인
        // 현재 상태 컴포넌트를 제거
        //switch(curState)
        //{
        //    case STATE.IDLE:
        //        var idle = gameObject.GetComponent<IdleState>();
        //        Destroy(idle);
        //        break;
        //    case STATE.MOVE:
        //        var move = gameObject.GetComponent<MoveState>();
        //        Destroy(move);
        //        break;
        //    case STATE.ATTACK:
        //        var attack = gameObject.GetComponent<AttackState>();
        //        Destroy(attack);
        //        break;
        //    case STATE.ATTACK1:
        //        var attack1 = gameObject.GetComponent<AttackState1>();
        //        Destroy(attack1);
        //        break;
        //}

        // state를 형변환 없이 하면 오류 발생
        // state를 UnityObject로 형변환후 현재 상태 컴포넌트 제거
        Destroy(state as Object);

        // state 컴포넌트를 추가
        this.state = gameObject.AddComponent(newState) as IState;

        Debug.Log(newState.Name);

        // 변경할 상태를 확인 후
        // 상태를 저장
        //switch(newState.Name)
        //{
        //    case "IdleState":
        //        curState = STATE.IDLE;
        //        break;
        //    case "MoveState":
        //        curState = STATE.MOVE;
        //        break;
        //    case "AttackState":
        //        curState = STATE.ATTACK;
        //        break;
        //    case "AttackState1":
        //        curState = STATE.ATTACK1;
        //        break;
        //}

        // 상태 확인
        CheckState(newState);
    }

    private void CheckState(System.Type state)
    {
        // 현재 상태에 따라 텍스트 변경
        switch (state.Name)
        {
            case "IdleState":
                stateText.text = "State : Idle";
                break;
            case "MoveState":
                stateText.text = "State : Move";
                break;
            case "AttackState":
                stateText.text = "State : Attack";
                break;
            case "AttackState1":
                stateText.text = "State : Attack1";
                break;
        }
    }

}
