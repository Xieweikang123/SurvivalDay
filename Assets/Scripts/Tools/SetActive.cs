using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetActive  {

    [MenuItem("GameObject/显示所有子物体和父物体 &2", priority = -1)]
    public static void SetActiveOrInactive()
    {
        GameObject selectionObj = Selection.activeGameObject;

        selectionObj.SetActive(!selectionObj.activeSelf);
    }
}
