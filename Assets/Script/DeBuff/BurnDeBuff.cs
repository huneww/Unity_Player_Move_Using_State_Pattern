using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnDeBuff : MonoBehaviour, IDeBuff
{
    // ƽ �����
    [SerializeField]
    private float tickDamage = 1f;
    // ���ӽð�
    [SerializeField]
    private float duration = 5f;
    // ƽ ����� �ֱ�
    [SerializeField]
    private float tickTime = 1f;

    // MonoBehaviour�� �����ڸ� ȣ������ �ʱ� ������ �ʱ�ȭ�� ���� ����
    public void Initialize(float tickDamage, float duration, float tickTime)
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

        // ���ӽð��� ������� ���ӵ� �ð��� ���̰� Epsilon���� Ŭ������
        while (duration - curTime > float.Epsilon)
        {
            // �ް��ִ� �ð� ����
            curTime += Time.deltaTime;
            // �ް��ִ� �ð��� ƽ Ÿ�Ժ��� ũ�ٸ�
            if (curTime >= tickTime)
            {
                // �ް��ִ� �ð� �ʱ�ȭ
                curTime = 0f;
                // ���ӽð����� ƽŸ���� ��
                duration -= tickTime;
                // ƽ����� �޴� ����
                Debug.Log($"Burn {tickDamage}TickDamage!");
            }
            yield return null;
        }
        // ĳ���� ��ũ��Ʈ�� ����� ����Ʈ���� ���� ��ũ��Ʈ ����
        Character.Instance.deBuff.Remove(this);
        // ĳ���� ������Ʈ���� ���� ��ũ��Ʈ ����
        Destroy(this);
    }
}