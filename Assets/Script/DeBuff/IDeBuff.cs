using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 추상클래스로 해서 변수도 사용했으면 좀더 나았을 듯
public interface IDeBuff
{
    public void Action();
    public IEnumerator Tick();
}
