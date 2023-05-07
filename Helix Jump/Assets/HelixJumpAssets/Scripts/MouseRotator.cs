using UnityEngine;

public class MouseRotator : MonoBehaviour
{
    [SerializeField] private string _InputAxis;
    [SerializeField] private float  _sensitive;
  
    // ѕоворачивает ось этажей по заданной оси.
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis(_InputAxis) * _sensitive, 0);
        }
    }
}
