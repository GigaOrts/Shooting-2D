using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue;

    private bool IsAlive => _value > 0;

    private void OnEnable()
    {
        Restore();
    }

    public void TakeDamage(float amount)
    {
        _value -= amount;

        if(IsAlive == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void Restore()
    {
        _value = _maxValue;
    }
}
