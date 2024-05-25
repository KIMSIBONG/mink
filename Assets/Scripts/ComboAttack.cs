using UnityEngine;
using System.Collections.Generic;

public class ComboAttack : MonoBehaviour
{
    public float comboWindow = 0.5f; // 콤보 윈도우 시간 (초)
    public string[] comboSequence; // 콤보 시퀀스
    private List<string> enteredKeys; // 입력된 키들의 리스트
    private float lastKeyPressTime; // 마지막 키 입력 시간

    private void Start()
    {
        enteredKeys = new List<string>();
    }

    private void Update()
    {
        CheckCombo();
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.anyKeyDown)
        {
            string key = Input.inputString.ToLower();
            enteredKeys.Add(key);
            lastKeyPressTime = Time.time;
        }
    }

    private void CheckCombo()
    {
        if (Time.time - lastKeyPressTime > comboWindow)
        {
            // 콤보 윈도우 시간 초과로 초기화
            enteredKeys.Clear();
            return;
        }

        if (enteredKeys.Count > comboSequence.Length)
        {
            // 입력된 키가 콤보 시퀀스보다 더 많으면 초기화
            enteredKeys.Clear();
            return;
        }

        // 입력된 키와 콤보 시퀀스를 비교하여 콤보가 완성되었는지 확인
        bool comboMatch = true;
        for (int i = 0; i < enteredKeys.Count; i++)
        {
            if (enteredKeys[i] != comboSequence[i])
            {
                comboMatch = false;
                break;
            }
        }

        if (comboMatch && enteredKeys.Count == comboSequence.Length)
        {
            // 콤보가 완성되었을 때의 동작 수행
            Debug.Log("Combo Attack!");
            // 여기에 콤보 공격에 대한 동작을 추가하세요.
            // 예를 들어, 공격 애니메이션을 재생하거나 데미지를 입히는 등의 행동을 할 수 있습니다.
        }
    }
}
