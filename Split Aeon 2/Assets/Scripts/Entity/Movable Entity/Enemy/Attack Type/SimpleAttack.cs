public class SimpleAttack : AttackBase
{
    public SimpleAttack()
    {
        baseDamage = 1f;
        attackMethod = AttackMethods.Melee;
    }

    public override void Attack()
    {
    }
}