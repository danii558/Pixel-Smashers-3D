using UnityEngine;

public class TriangelEnemy : Enemy
{
    public int _slide;
    private void OnTriggerEnter(Collider other)
    {
        #region rotation enemy
        if (other.CompareTag("1_Point"))
        {
            transform.Rotate(0, -7, 0);
        }

        if (other.CompareTag("2_Point"))
        {
            transform.Rotate(0, -11.8f, 0);
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

            _slide = Random.Range(1, 3);

            switch(_slide)
            {
                case 1:
                    transform.position = new Vector3(11.7f, 1, 0);
                    break;

                case 2:
                    transform.position = new Vector3(1, 1, 0);
                    break;

                case 3:
                    transform.position = new Vector3(6.288f, 1, 0);
                    break;
            }
        }
            
    }
}
