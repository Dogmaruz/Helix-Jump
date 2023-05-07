using UnityEngine;
using UnityEngine.UI;

public class FlipMaterial : MonoBehaviour
{
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Material[] _materials;

    private void Awake()
    {
        Flip();
    }

    // Рандомная смена цвета фона и материалов.
    public void Flip()
    {
        _backgroundImage.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        }
    }
}
