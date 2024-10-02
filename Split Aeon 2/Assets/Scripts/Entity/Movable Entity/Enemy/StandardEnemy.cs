public class StandardEnemy : EnemyBase
{
    public StandardEnemy()
    {
        attackType = new SimpleAttack();
    }

    protected override void Attack()
    {
        attackType.Attack();
    }
}