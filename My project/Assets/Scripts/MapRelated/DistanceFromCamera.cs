using UnityEngine;
using UnityEditor;

public class DistanceFromCamera : EditorWindow
{

    private GUIStyle style;

    [MenuItem("Tools/Distance window")]
    [System.Obsolete]
    private static void Init()
    {
        DistanceFromCamera window = GetWindow<DistanceFromCamera>();
        SceneView.onSceneGUIDelegate += window.OnSceneGUI;
        window.Setup();
    }

    private void Setup()
    {
        style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 16;
        style.alignment = TextAnchor.MiddleCenter;
    }

    [System.Obsolete]
    private void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        string distanceString = "N/A";
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            GameObject[] selectedObjects = Selection.gameObjects;
            if (selectedObjects.Length == 1)
            {
                GameObject selectedObject = selectedObjects[0];
                float distance = (selectedObject.transform.position - mainCamera.transform.position).magnitude;
                distanceString = distance.ToString();
            }
        }
        Handles.Label(Selection.gameObjects[0].transform.position, distanceString, style);
    }

}