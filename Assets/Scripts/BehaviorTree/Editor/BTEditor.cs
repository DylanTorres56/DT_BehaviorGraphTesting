using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BTEditor : EditorWindow
{
    BTView bTView;
    InspectorView inspectorView; 
    
    [MenuItem("BTEditor/Editor...")]
    public static void OpenWindow()
    {
        BTEditor wnd = GetWindow<BTEditor>();
        wnd.titleContent = new GUIContent("BTEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/BehaviorTree/Editor/BTEditor.uss");
        visualTree.CloneTree(root);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/BehaviorTree/Editor/BTEditor.uss");
        root.styleSheets.Add(styleSheet);

        bTView = root.Q<BTView>();
        inspectorView = root.Q<InspectorView>();

        OnSelectionChange();
    }

    private void OnSelectionChange()
    {
        BehaviorTree tree = Selection.activeObject as BehaviorTree;
        if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID())) 
        {
            bTView.PopulateView(tree);
        }
    }

    void OnNodeSelectionChanged(NodeView node) 
    {
        inspectorView.UpdateSelection(node);
    }
}