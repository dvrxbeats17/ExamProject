using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth { get; private set; }
    public Stat Damage;
    public Stat Armor;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= Armor.GetValue();
        damage = Mathf.Clamp(damage, 0, MaxHealth);

        CurrentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + " damage");

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died");
    }

}
