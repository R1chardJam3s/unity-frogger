using UnityEngine;

public interface IEntity
{
    Transform transform { get; }
    //Rigidbody2D rb { get; }

    Animator animator { get;  }

    void MoveTo(Vector3 start, Vector3 end);
}