using UnityEditor;
using UnityEngine;

public class ItemEditorWindow : EditorWindow
{

    [MenuItem("Window/Demo/ItemEditorWindow")]
    static public void CreateWindow()
    {
        EditorWindow.GetWindow<ItemEditorWindow>();
    }
    Vector2 scrollPosition;
    string fileTitle = "File Title";
    string fileCaption = "File Caption";

    void OnGUI()
    {
        EditorGUILayout.LabelField("100000");
        EditorGUILayout.LabelField("アイテム名");
        GUILayout.Button("編集");

        // 水平に並べる
        using (new EditorGUILayout.HorizontalScope())
        {
            EditorGUILayout.LabelField("100000");
            EditorGUILayout.LabelField("アイテム名");
            GUILayout.Button("編集");
        }

        // スクロール
        using (var scroll = new EditorGUILayout.ScrollViewScope(this.scrollPosition))
        {
            this.scrollPosition = scroll.scrollPosition;

            for (int i = 0; i < 100; i++)
            {
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField("100000", GUILayout.MaxWidth(50f));
                    EditorGUILayout.LabelField("アイテム名", GUILayout.MaxWidth(200f));
                    GUILayout.Button("編集", GUILayout.MaxWidth(50f));
                }
            }
        }

        // VerticalScopeで領域管理
        using (new EditorGUILayout.VerticalScope())
        {
            EditorGUILayout.LabelField("Map1Item.json");
            fileTitle = EditorGUILayout.TextField(fileTitle);
            fileCaption = EditorGUILayout.TextArea(fileCaption, GUILayout.Height(EditorGUIUtility.singleLineHeight * 2f));

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Button("アイテムを追加");
                GUILayout.Button("もとに戻す");
                GUILayout.Button("保存");
            }

            // 省略
        }
    }
}