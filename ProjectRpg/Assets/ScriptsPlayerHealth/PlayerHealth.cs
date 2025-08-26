using UnityEngine;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float blinkDuration = 0.8f;
    public float blinkInterval = 0.1f;

    private float _maxHealth;
    private Renderer _renderer;
    private bool _isInvincible = false;
    private bool _isBlinking = false;

    void Start()
    {
        _maxHealth = health;
        _renderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int amount)
    {
        if (_isInvincible) return;

        health -= amount;
        StartBlink();

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Player died");
        gameObject.SetActive(false);
    }

    public void StartBlink()
    {
        if (!_isBlinking)
            StartCoroutine(BlinkEffect(blinkDuration, blinkInterval));
    }

    IEnumerator BlinkEffect(float duration, float interval)
    {
        _isBlinking = true;
        _isInvincible = true;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            _renderer.enabled = false;
            yield return new WaitForSeconds(interval);
            elapsedTime += interval;

            _renderer.enabled = true;
            yield return new WaitForSeconds(interval);
            elapsedTime += interval;
        }

        _isInvincible = false;
        _isBlinking = false;
    }
}
