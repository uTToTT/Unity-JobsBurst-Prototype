using UnityEngine;

public class MonoCube : MonoBehaviour
{
    [SerializeField] private float _speed;

    public bool IsShouldRotate;

    private void Update()
    {
        if (IsShouldRotate)
        {
            transform.Rotate(Vector3.up * _speed * Time.deltaTime);
        }
    }
}
