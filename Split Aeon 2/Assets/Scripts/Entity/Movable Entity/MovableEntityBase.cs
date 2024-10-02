using UnityEngine;

public abstract class MovableEntityBase : EntityBase
{
    [SerializeField]
    protected float moveSpeed = 1;

    public virtual float MoveSpeed
    {
        get { return moveSpeed; }
    }

    public virtual void Move(Vector3 target)
    {
        Vector3 moveNormalised = (target - gameObject.transform.position).normalized;
        if (moveNormalised.magnitude < target.magnitude)
        {
            gameObject.transform.position = moveNormalised * moveSpeed;
        }
        else
        {
            gameObject.transform.position = target;
        }
    }
}