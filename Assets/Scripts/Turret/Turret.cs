using UnityEngine;

public class Turret : MonoBehaviour
{
    public AudioClip _mClip;
    public AudioSource _muzzleFX;

    [Header("Cooldown Turret")]
    private float _nextFire = 1f;
    public float _cooldDown;
    public Transform _bulletPrefab;
    public Transform _spawnBullet;
    public float _speedBullet;

    public void OnRotationTurretOnEnemy(Transform enemy)
    {
        // Rotation turrent on enemy
        transform.LookAt(enemy);

        // Create bullet
        Transform bulletInstance = Instantiate(_bulletPrefab, _spawnBullet.position, _spawnBullet.rotation);
        //AudioManager.instance.PlaySFX("shoot");
        // Check Component Bullet
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.OnTarget(enemy, _speedBullet);
        }
        else
        {
            Debug.LogError("Bullet component not found on prefab!");
        }
    }
}
