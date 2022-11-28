using System.Collections.Generic;
using System.IO;
using System.Linq;
using Editor;
using Editor_mat;
using UnityEditor;
using UnityEngine;

public class materyaldegistirici : EditorWindow

{

    private GameObject m_ParentRef;
    private SerializedObject m_SerializedObject;
    private ScriptableMaterialFix m_MateryalHavuzu;
    private static Transform[] AllObject;
    private Material degisen_mat;

    private Vector2 m_Scroll = Vector2.zero;

    [MenuItem("Araclar/Materyal Degistirici")]
    public static void ShowWindow()
    {
        materyaldegistirici window =
            (materyaldegistirici) GetWindow(typeof(materyaldegistirici), false, "Materyal Degistirici");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        m_ParentRef = EditorGUILayout.ObjectField("Parent Object", m_ParentRef, typeof(GameObject)) as GameObject;
        if (m_ParentRef != null)
            AllObject = m_ParentRef.GetComponentsInChildren<Transform>();

        EditorGUILayout.Space();

        m_MateryalHavuzu =
            (ScriptableMaterialFix) EditorGUILayout.ObjectField("Materyaller", m_MateryalHavuzu,
                typeof(ScriptableMaterialFix));

        EditorGUILayout.Space();
        if (GUILayout.Button("Materyalleri Degistime Fonksiyonu", GUILayout.Height(50), GUILayout.MinWidth(160)))
        {
            MateryalleriDegistimeFonksiyonu();
        }

        EditorGUILayout.EndVertical();







    }



    private void MateryalleriDegistimeFonksiyonu()
    {

        foreach (var tr in AllObject)
        {
         
            if (tr.TryGetComponent(out Renderer Renderer) == true)
            {
                bool isOK = false;
                var list = new List<Material>();
                for (var d = 0; d < Renderer.sharedMaterials.Length; d++)
                {
                    
                    list.Add(Renderer.sharedMaterials[d]);
                }

               


                for (int i = 0; i < list.Count; i++)
                {
                  





                    for (int havuz_elemani = 0; havuz_elemani < m_MateryalHavuzu.MaterialPool.Count; havuz_elemani++)
                    {
                        foreach (var f_hataliMateryal in m_MateryalHavuzu.MaterialPool[havuz_elemani].HataliMaterials)
                        {
                            if (list[i] == f_hataliMateryal)
                            {
                                list[i] = m_MateryalHavuzu.MaterialPool[havuz_elemani].OrjinalMateryal;
                                
                                Debug.Log("obj ismi : "+tr.name+ " - degisem materyal : " +f_hataliMateryal.name +" - orjinal materyal :"+  m_MateryalHavuzu.MaterialPool[havuz_elemani].OrjinalMateryal );
                            }


                        }
                    }


                }

                Renderer.sharedMaterials = list.ToArray();











            }










        }
    }
}
    
    
    
    
    
    
    
