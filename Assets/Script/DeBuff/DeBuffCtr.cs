using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeBuffCtr : MonoBehaviour
{
    // 디버프 부여 버튼
    public Button posionBtn;
    public Button bleedingBtn;
    public Button burnBtn;

    private void Start()
    {
        Button btn = posionBtn.GetComponent<Button>();
        // 버튼 클릭 이벤트 추가
        btn.onClick.AddListener(() => 
        {
            // 캐릭터 오브젝트에 디버프 스크립트 추가
            var obj = Character.Instance.gameObject.AddComponent<PoisonDeBuff>();
            // 디버프 스크립트 초기화
            obj.Initialize(1, 5, 1);
            // 디버프 활성화
            obj.Action();
            // 캐릭터 스크립트의 디버프 리스트에 추가한 디버프 추가
            Character.Instance.deBuff.Add(obj);
        });

        btn = bleedingBtn.GetComponent<Button>();
        // 버튼 클릭 이벤트 추가
        btn.onClick.AddListener(() => 
        { 
            // 캐릭터 오브젝트에 디버프 스크립트 추가
            var obj = Character.Instance.gameObject.AddComponent<BleedingDeBuff>();
            // 디버프 스크립트 초기화
            obj.Initialize(2, 10, 0.5f);
            // 디버프 활성화
            obj.Action();
            // 캐릭터 스크립트의 디버프 리스트에 추가한 디버프 추가
            Character.Instance.deBuff.Add(obj);
        });

        btn = burnBtn.GetComponent<Button>();
        // 버튼 클릭 이벤트 추가
        btn.onClick.AddListener(() =>
        {
            // 캐릭터 오브젝트에 디버프 스크립트 추가
            var obj = Character.Instance.gameObject.AddComponent<BurnDeBuff>();
            // 디버프 스크립트 초기화
            obj.Initialize(3, 10, 1.5f);
            // 디버프 활성화
            obj.Action();
            // 캐릭터 스크립트의 디버프 리스트에 추가한 디버프 추가
            Character.Instance.deBuff.Add(obj);
        });

    }

}
