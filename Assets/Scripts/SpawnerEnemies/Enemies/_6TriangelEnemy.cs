using UnityEngine;

public class _6TriangelEnemy : Enemy
{
    public int _slide;
    public GameObject[] _prefabsFigures;
    public int _randomEnemy;
    public GameObject _test;
    [Header("Position Object: ")]
    public int _position;
    private Vector3 _position1;
    private Vector3 _position2;
    private Vector3 _position3;

    private void Awake()
    {
        // Set position
        _position1 = new Vector3(10.18f, 1.25f, 10.674f);
        _position2 = new Vector3(2.397f, 1.25f, 10.29f);
        _position3 = new Vector3(6.288f, 1.25f, 10.56f);

        // Random 
        _position = Random.Range(1, 3);
        _randomEnemy = Random.Range(0, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        #region rotation enemy
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

        #endregion
        if (other.tag == "Bullet")
        {
            _health -= 1;

            switch(_position)
            {
                case 1:
                    Instantiate(_prefabsFigures[_randomEnemy], _position1, _test.transform.rotation);
                    break;

                case 2:
                    Instantiate(_prefabsFigures[_randomEnemy], _position2, _test.transform.rotation);
                    break;

                case 3:
                    Instantiate(_prefabsFigures[_randomEnemy], _position3, _test.transform.rotation);
                    break;
            }
        }
        
    }
}
