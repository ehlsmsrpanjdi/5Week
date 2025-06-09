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

    int Row = 0;
    int Col = 0;
    int itemKey = 0;


    private void OnGUI()
    {
        GUILayout.Label("이건 커스텀 에디터 창입니다!", EditorStyles.boldLabel);

        GUILayout.Label("정수 값 입력", EditorStyles.boldLabel);

        Row = EditorGUILayout.IntField("행", Row);
        Col = EditorGUILayout.IntField("열", Col);

        itemKey = EditorGUILayout.IntField("탬키", itemKey);

        if (GUILayout.Button("테스트 아이템 얻기"))
        {
            Debug.Log($"입력된 값: 행 = {Row}, 열 = {Col}");
            Player.Instance.playerInventory.AddItem(Row, Col, new ItemInfo() { Key = 1 });
        }

        if (GUILayout.Button("원하는 아이템 얻기"))
        {
            Player.Instance.playerInventory.AddItem(Row, Col, new ItemInfo() { Key = itemKey });
        }
    }
}
