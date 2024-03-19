using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        transform.rotation = rotation;

        transform.Translate(_speed * Time.deltaTime * direction);
    }
}
