# EditorDemo

- Unityエディター拡張を勉強するためのリポジトリ  
  - https://www.amazon.co.jp/dp/4862465072

## Unityバージョン

- Unity 2020.3.25f1

### Assets/Scripts/Editor/ItemEditorWindow.cs

![image](https://user-images.githubusercontent.com/10719941/147882448-05d743c2-af5c-4d19-bb31-5c12471ce6e3.png)

### Assets/Scripts/Editor/PopupWindow.cs

![image](https://user-images.githubusercontent.com/10719941/147882523-c24f5dcf-0b3d-4dd0-80cb-396ac34f2848.png)

### Assets/Scripts/Editor/EditorHierarchy.cs

- Hierarchy ビューに Add Component ボタンを追加

![image](https://user-images.githubusercontent.com/10719941/147882577-006694b6-4dc2-47b9-94d1-e1b4c621e289.png)

### Assets/Scripts/Editor/EditorSceneView.cs

- シーンビューに Sync, Cube, Sphere ボタンを追加

![image](https://user-images.githubusercontent.com/10719941/147882619-b09f538a-8baa-4264-80c2-0793c48602f9.png)

### Assets/Scripts/Editor/EditorInspector.cs

- オブジェクト選択中のシーンビューの表示を拡張

![image](https://user-images.githubusercontent.com/10719941/147883288-73813033-fb21-4f70-8c55-4d633b9f6694.png)

### Assets/Scripts/Editor/RuntimeOnDrawGizmos.cs

- シーンビューでオブジェクトを選択したとき、IDを表示
- 
![image](https://user-images.githubusercontent.com/10719941/147883361-c140bc02-f3c5-4a3b-b525-406dc03163f2.png)

### Assets/Scripts/Editor/EditorToolOriginal.cs

- ツールバーに Original Tool(Movable Y-Axis) を追加

![image](https://user-images.githubusercontent.com/10719941/147883433-092ee59f-0531-46d8-8dc2-48e38c8ed6e0.png)

### Assets/Scripts/Editor/EditorProjectWindow.cs

- Project ビューに Copy Path ボタンを追加

![image](https://user-images.githubusercontent.com/10719941/147883527-e1e7ea5d-984d-4e83-9fe0-de9467844d5c.png)

### Assets/Scripts/Editor/EditorPreferences.cs

- Preferences に Original/General を追加

![image](https://user-images.githubusercontent.com/10719941/147883557-53b32694-4228-4bc7-9868-b4dc4374cb23.png)

### Assets/Scripts/Editor/EditorProjectSettings.cs

- Project Settings に Original/General を追加

![image](https://user-images.githubusercontent.com/10719941/147883613-7ed20be7-5ef8-44cf-b453-4f32faf074c2.png)

### Assets/Scripts/Editor/ItemEditorPropertyDrawer.cs

- 設定可能な変数に対して設定表示の拡張を行う

##### Before

![image](https://user-images.githubusercontent.com/10719941/147884028-147580d9-648a-45c7-9ce3-a8e561e52e3d.png)

##### After

![image](https://user-images.githubusercontent.com/10719941/147883989-e0a05899-4889-47c2-ac2a-d65ecfeb0ee1.png)

### Assets/Scripts/MenuComponent.cs

![image](https://user-images.githubusercontent.com/10719941/147884533-953cbb91-faa0-4eeb-9292-761ffad6b5c7.png)

##### 右クリック

![image](https://user-images.githubusercontent.com/10719941/147884464-8a9c963b-cc5e-446a-acdc-aed62023bd1b.png)
