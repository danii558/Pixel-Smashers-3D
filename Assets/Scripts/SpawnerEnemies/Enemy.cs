using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerClickHandler 
{
    public float _health;
    public float _speed;
    //private Vector3 _test;

    //private void Awake()
    //{
    //    _test = transform.position;
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        FindFirstObjectByType<Turret>().OnRotationTurretOnEnemy(transform);
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -13.32) { Destroy(gameObject); }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * _speed / 100;
    }

    #region rotation enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("1_Point"))
        {
            transform.Rotate(0, -7, 0);
        }

        if (other.CompareTag("2_Point"))
        {
            transform.Rotate(0, -10.8f, 0);
        }

        if (other.CompareTag("3_Point"))
        {
            transform.Rotate(0, 6, 0);
        }

        if (other.CompareTag("4_Point"))
        {
            transform.Rotate(0, 12.0f, 0);
        }
    }
    #endregion
}
