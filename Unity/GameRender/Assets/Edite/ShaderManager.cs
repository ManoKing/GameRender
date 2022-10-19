using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShaderManager : MonoBehaviour
{
    [MenuItem("Tools/Shader/替换Default Shader")]
    public static void ResetShader()
    {
        var matGuids = AssetDatabase.FindAssets("t:Material", new string[] { "Assets" });
        for (var idx = 0; idx < matGuids.Length; ++idx)
        {
            var guid = matGuids[idx];
            EditorUtility.DisplayProgressBar(string.Format("批处理中...{0}/{1}", idx + 1, matGuids.Length), "替换shader", (idx + 1.0f) / matGuids.Length);
            var mat = AssetDatabase.LoadAssetAtPath<Material>(AssetDatabase.GUIDToAssetPath(guid));
            mat.shader = Shader.Find(mat.shader.name);
            new SerializedObject(mat).ApplyModifiedProperties();
        }

        AssetDatabase.SaveAssets();
        EditorUtility.ClearProgressBar();

        Debug.Log("replace all system shader is done!");
    }
}
