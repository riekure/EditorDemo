using UnityEditor;
using UnityEngine;

public class ItemEditorWindow : EditorWindow
{

	[MenuItem("Window/Demo/ItemEditorWindow")]
	static public void CreateWindow()
	{
		EditorWindow.GetWindow<ItemEditorWindow>();
	}
	GUISkin skin;
	Vector2 scrollPosition;
	ItemData itemData;
	[SerializeField] int selectedIndex;

	void OnEnable()
	{
		this.skin = AssetDatabase.LoadAssetAtPath<GUISkin>("Assets/Scripts/Editor/Editor Resources/ItemEditorGUISkin.guiskin");
		this.itemData = Resources.Load<ItemData>("ItemData").Clone();
	}

	void OnGUI()
	{
		using (new EditorGUILayout.VerticalScope(this.skin.GetStyle("Header")))
		{
			EditorGUILayout.LabelField(AssetDatabase.GetAssetPath(itemData));
			Undo.RecordObject(itemData, "Modify FileName or Caption of ItemData");
			itemData.fileName = EditorGUILayout.TextField(itemData.fileName);
			itemData.fileCaption = EditorGUILayout.TextArea(itemData.fileCaption, GUILayout.Height(EditorGUIUtility.singleLineHeight * 2f));

			using (new EditorGUILayout.HorizontalScope())
			{
				if (GUILayout.Button("アイテムを追加"))
				{
					Undo.RecordObject(itemData, "Add Item");
					int itemLength = this.itemData.items.Length;
					System.Array.Resize(ref this.itemData.items, itemLength + 1);
					this.itemData.items[itemLength] = new ItemData.Item()
					{
						name = "名前を入力してください",
						caption = "説明文",
					};
				}
				GUILayout.FlexibleSpace();

				if (GUILayout.Button("元に戻す"))
				{
					this.itemData = Resources.Load<ItemData>("ItemData").Clone();
					EditorGUIUtility.editingTextField = false;
				}
				if (GUILayout.Button("保存"))
				{
					var data = Resources.Load<ItemData>("ItemData");
					EditorUtility.CopySerialized(this.itemData, data);
					EditorUtility.SetDirty(data);
					AssetDatabase.SaveAssets();
				}
			}
		}

		using (new EditorGUILayout.HorizontalScope())
		{
			using (var scroll = new EditorGUILayout.ScrollViewScope(scrollPosition, GUILayout.MinWidth(320f)))
			{
				scrollPosition = scroll.scrollPosition;

				for (int i = 0; i < this.itemData.items.Length; ++i)
				{
					var data = this.itemData.items[i];
					using (new EditorGUILayout.HorizontalScope())
					{
						EditorGUILayout.LabelField(data.id.ToString(), GUILayout.MaxWidth(50f));
						EditorGUILayout.LabelField(data.name, GUILayout.MaxWidth(200f));
						if (GUILayout.Button("編集", GUILayout.MaxWidth(50f)))
						{
							Undo.RecordObject(this, "Select Item");
							this.selectedIndex = i;
						}
					}
				}
			}

			using (new EditorGUILayout.VerticalScope(this.skin.GetStyle("Inspector")))
			{
				if (0 <= this.selectedIndex && this.selectedIndex < this.itemData.items.Length)
				{
					Undo.RecordObject(itemData, "Modify ItemData at " + this.selectedIndex);
					var selectedItem = this.itemData.items[this.selectedIndex];
					selectedItem.id = EditorGUILayout.IntField("ID", selectedItem.id);
					selectedItem.name = EditorGUILayout.TextField("アイテム名", selectedItem.name);
					selectedItem.type = (ItemType)EditorGUILayout.EnumPopup("アイテムタイプ", selectedItem.type);
					selectedItem.caption = EditorGUILayout.TextArea(selectedItem.caption, GUILayout.Height(EditorGUIUtility.singleLineHeight * 4f));
				}
				GUILayout.FlexibleSpace();
			}
		}
	}
}