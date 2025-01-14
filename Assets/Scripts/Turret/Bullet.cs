using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private float _speed;

    // Метод для передачи цели и скорости пули
    public void OnTarget(Transform target, float speed)
    {
        _target = target;
        _speed = speed;

        if (_target == null)
        {
            Debug.LogWarning("Target is null");
        }

        if (_speed == 0)
        {
            Debug.LogWarning("Speed is zero");
        }
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject); // Уничтожаем пулю, если цель пропала
            return;
        }

        // Двигаем пулю к цели
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);

        // Поворачиваем пулю к цели
        transform.LookAt(_target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(12);
            }

            Destroy(gameObject);
        }
    }
}
