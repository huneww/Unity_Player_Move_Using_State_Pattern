using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // �̱��� ����
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

    // ĳ���� ���� ���� �ؽ�Ʈ
    public Text stateText;
    // ĳ���� ���� ������ ����
    //private STATE curState;
    // ���� ���� ��ũ��Ʈ ���� ����
    private IState state;

    public float speed = 5f;

    void Start()
    {
        // ���¸� IdleState�� ����
        // ���¸� state�� ����
        state = gameObject.AddComponent<IdleState>();

        // ���� ���¸� IDLE�� ����
        //curState = STATE.IDLE;

        // ���� ���¸� Ȯ��
        // �ؽ�Ʈ ����
        CheckState(typeof(IdleState));
    }

    private void Update()
    {
        // ���� ���¿� �ִ� Action�Լ��� ��� ȣ��
        state.Action();
    }

    // ������Ʈ�� ������Ʈ�� �߰������ؼ�
    // Type���·� �Ű������� ����
    public void ChangeState(System.Type newState)
    {
        // ���� ���¸� Ȯ��
        // ���� ���� ������Ʈ�� ����
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

        // state�� ����ȯ ���� �ϸ� ���� �߻�
        // state�� UnityObject�� ����ȯ�� ���� ���� ������Ʈ ����
        Destroy(state as Object);

        // state ������Ʈ�� �߰�
        this.state = gameObject.AddComponent(newState) as IState;

        Debug.Log(newState.Name);

        // ������ ���¸� Ȯ�� ��
        // ���¸� ����
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

        // ���� Ȯ��
        CheckState(newState);
    }

    private void CheckState(System.Type state)
    {
        // ���� ���¿� ���� �ؽ�Ʈ ����
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
