using UnityEngine;
using System.Collections.Generic;


namespace Editor_mat
{
[CreateAssetMenu(fileName = "Material_Pool_Fix", menuName = "ScriptableObjects/MaterialsPoolFix", order = 2)]

public class ScriptableMaterialFix : ScriptableObject

{
    public List<Original_Material> MaterialPool = new List<Original_Material>();
    
}


}