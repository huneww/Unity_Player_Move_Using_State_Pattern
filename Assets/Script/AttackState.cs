using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, IState
{
    // 코루틴 저장 변수
    Coroutine coroutine;

    public void Action()
    {
        Debug.Log("Attack!");
        // 코루틴이 실행중이지 않다면
        // 코루틴을 실행
        if (coroutine == null)
        {
            coroutine = StartCoroutine(ReturnIdle());
        }
    }

    private IEnumerator ReturnIdle()
    {
        // 0.5초후 다시 IdleState로 캐릭터 상태 변환
        yield return new WaitForSeconds(0.5f);

        Character.Instance.ChangeState(typeof(IdleState));
    }

    private void Update()
    {
        // 다시 한번 마우스 클릭시
        if (Input.GetMouseButtonDown(0))
        {
            // 코루틴을 정지
            StopCoroutine(coroutine);
            // 다음 공격 스크립트로 캐릭터 상태 변환
            Character.Instance.ChangeState(typeof(AttackState1));
        }
    }

}
