using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebugWindow : EditorWindow
{
    [MenuItem("Window/My Custom Window")]
    public static void ShowWindow()
    {
        // â�� ����
        GetWindow<DebugWindow>("My Window Title");
    }

    int valueA = 0;
    int valueB = 0;


    private void OnGUI()
    {
        GUILayout.Label("�̰� Ŀ���� ������ â�Դϴ�!", EditorStyles.boldLabel);

        GUILayout.Label("���� �� �Է�", EditorStyles.boldLabel);

        valueA = EditorGUILayout.IntField("Value A", valueA);
        valueB = EditorGUILayout.IntField("Value B", valueB);

        if (GUILayout.Button("�� ���"))
        {
            Debug.Log($"�Էµ� ��: A = {valueA}, B = {valueB}");
            Player.Instance.playerInventory.AddItem(valueA, valueB, new ItemInfo() { Key = 1 });
        }
    }
}
