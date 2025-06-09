using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebugWindow : EditorWindow
{
    [MenuItem("Window/My Custom Window")]
    public static void ShowWindow()
    {
        // 창을 띄운다
        GetWindow<DebugWindow>("My Window Title");
    }

    int valueA = 0;
    int valueB = 0;


    private void OnGUI()
    {
        GUILayout.Label("이건 커스텀 에디터 창입니다!", EditorStyles.boldLabel);

        GUILayout.Label("정수 값 입력", EditorStyles.boldLabel);

        valueA = EditorGUILayout.IntField("Value A", valueA);
        valueB = EditorGUILayout.IntField("Value B", valueB);

        if (GUILayout.Button("값 출력"))
        {
            Debug.Log($"입력된 값: A = {valueA}, B = {valueB}");
            Player.Instance.playerInventory.AddItem(valueA, valueB, new ItemInfo() { Key = 1 });
        }
    }
}
