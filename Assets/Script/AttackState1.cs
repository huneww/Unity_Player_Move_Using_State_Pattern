using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState1 : MonoBehaviour, IState
{
    Coroutine coroutine;

    public void Action()
    {
        Debug.Log("Attack1!");
        if (coroutine == null)
        {
            coroutine = StartCoroutine(ReturnIdle());
        }
    }

    private IEnumerator ReturnIdle()
    {
        yield return new WaitForSeconds(0.5f);

        Character.Instance.ChangeState(typeof(IdleState));
    }

}
