using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDeBuff : MonoBehaviour, IDeBuff
{
    // 틱 대미지
    [SerializeField]
    private float tickDamage = 1f;
    // 지속시간
    [SerializeField]
    private float duration = 5f;
    // 틱 대미지 주기
    [SerializeField]
    private float tickTime = 1f;

    // MonoBehaviour는 생성자를 호출하지 않기 때문에 초기화를 따로 실행
    public void  Initialize(float tickDamage, float duration, float tickTime)
    {
        this.tickDamage = tickDamage;
        this.duration = duration;
        this.tickTime = tickTime;
    }

    public void Action()
    {
        StartCoroutine(Tick());
    }

    public IEnumerator Tick()
    {
        float curTime = 0f;
        
        // 지속시간과 현재까지 지속된 시간의 차이가 Epsilon보다 클때까지
        while (duration - curTime > float.Epsilon)
        {
            // 받고있는 시간 증가
            curTime += Time.deltaTime;
            // 받고있는 시간이 틱 타임보다 크다면
            if (curTime >= tickTime)
            {
                // 받고있는 시간 초기화
                curTime = 0f;
                // 지속시간에서 틱타임을 뺌
                duration -= tickTime;
                // 틱대미지 받는 로직
                Debug.Log($"Poison {tickDamage}TickDamage!");
            }
            yield return null;
        }

        // 캐릭터 스크립트의 디버프 리스트에서 현재 스크립트 제거
        Character.Instance.deBuff.Remove(this);
        // 캐릭터 오브젝트에서 현재 스크립트 제거
        Destroy(this);
    }

}
