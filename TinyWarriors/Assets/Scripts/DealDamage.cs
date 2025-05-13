using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            TakeDamage enemy  = other.GetComponent<TakeDamage>();
            enemy.TakeDamageFromEnemy(damage);
        }
    }
}
