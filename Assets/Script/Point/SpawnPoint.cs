using TMPro;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] TextMeshPro textMesh;
    [SerializeField] int teamTag;

    void Start()
    {
        textMesh.text = teamTag.ToString();
    }
    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
