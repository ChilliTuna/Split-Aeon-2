using UnityEngine;

public abstract class EntityBase : MonoBehaviour
{
    public delegate void EntityHit(HitDetails hitDetails);
    public static event EntityHit OnHit;

    [SerializeField]
    protected float maxHealth = 10;

    [SerializeField]
    protected float health = 10;
    
    protected bool isAlive = true;

    public virtual float MaxHealth
    {
        get { return maxHealth; }
    }

    public virtual float Health
    {
        get { return health; }
    }

    public virtual bool IsAlive
    {
        get { return isAlive; }
    }

    public EntityBase()
    {
        OnHit += HandleHit;
    }

    public void HandleHit(HitDetails hitDetails)
    {
        ChangeHealth(hitDetails.damage);
    }

    public virtual void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
    }

    public virtual void Revive()
    {
        isAlive = true;
        gameObject.SetActive(true);
    }

    public virtual void ChangeHealth(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }
}