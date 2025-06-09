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

    int Row = 0;
    int Col = 0;
    int itemKey = 0;


    private void OnGUI()
    {
        GUILayout.Label("�̰� Ŀ���� ������ â�Դϴ�!", EditorStyles.boldLabel);

        GUILayout.Label("���� �� �Է�", EditorStyles.boldLabel);

        Row = EditorGUILayout.IntField("��", Row);
        Col = EditorGUILayout.IntField("��", Col);

        itemKey = EditorGUILayout.IntField("��Ű", itemKey);

        if (GUILayout.Button("�׽�Ʈ ������ ���"))
        {
            Debug.Log($"�Էµ� ��: �� = {Row}, �� = {Col}");
            Player.Instance.playerInventory.AddItem(Row, Col, new ItemInfo() { Key = 1 });
        }

        if (GUILayout.Button("���ϴ� ������ ���"))
        {
            Player.Instance.playerInventory.AddItem(Row, Col, new ItemInfo() { Key = itemKey });
        }
    }
}
