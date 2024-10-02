public enum AttackMethods
{
    Melee,
    Range
}

public abstract class AttackBase
{
    protected float baseDamage;

    protected AttackMethods attackMethod;

    public float BaseDamage
    {
        get { return baseDamage; }
    }

    public AttackMethods AttackMethod
    {
        get { return attackMethod; }
    }

    public abstract void Attack();
}