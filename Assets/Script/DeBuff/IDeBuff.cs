using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �߻�Ŭ������ �ؼ� ������ ��������� ���� ������ ��
public interface IDeBuff
{
    public void Action();
    public IEnumerator Tick();
}
