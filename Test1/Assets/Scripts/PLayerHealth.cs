using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayerHealth : MonoBehaviour
{
    public int health;
    public int currentHealth;

    public Animator anim;
    public HelthBar healthBar;

    public void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage1)
    {
        currentHealth -= damage1;
        
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 60)
        {
            anim.SetBool("Hp1", true);
        }
        if (currentHealth <= 30)
        {
            anim.SetBool("Hp1", false);
            anim.SetBool("Hp2", true);
        }
        if (currentHealth <= 0)
        {
            anim.SetBool("Hp2", false);
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}