using UnityEngine;

public class ConvertToRegullarMesh : MonoBehaviour
{
    [ContextMenu("Convert to reg mesh")]
    private void Convert()
    {
        SkinnedMeshRenderer _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer _meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter _meshFilter = gameObject.AddComponent<MeshFilter>();

        _meshFilter.sharedMesh = _skinnedMeshRenderer.sharedMesh;
        _meshRenderer.sharedMaterial = _skinnedMeshRenderer.sharedMaterial;

        DestroyImmediate(_skinnedMeshRenderer);
        DestroyImmediate(this);
    }

}
