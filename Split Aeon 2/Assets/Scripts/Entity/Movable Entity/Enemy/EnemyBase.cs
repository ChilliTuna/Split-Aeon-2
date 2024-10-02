using UnityEngine;

public abstract class EnemyBase : MovableEntityBase
{
    protected GameObject target;
    protected AttackBase attackType;

    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }

    public AttackBase AttackType
    {
        get { return attackType; }
    }

    protected abstract void Attack();
}