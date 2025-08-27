using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private float _pushForce = 5f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (other.transform.position - transform.position);
                direction.y = 0f;
                direction = direction.normalized;

                rb.AddForce(direction * _pushForce, ForceMode.Impulse);
            }

            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(_damageAmount);
            }
        }
    }
}
