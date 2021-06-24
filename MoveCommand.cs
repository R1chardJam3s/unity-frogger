using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector3 _destination;
    private Vector3 _originalPosition;

    public MoveCommand(IEntity entity, Vector3 des) : base(entity)
    {
        _destination = des;
    }

    public override void Execute()
    {
        _originalPosition = _entity.transform.position;
        _entity.MoveTo(_originalPosition, _destination);

        /*
         * these lines of code in the new system for animation
        rb.position = Vector3.MoveTowards(rb.position, movePoint.position, speed * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical")) * speed);
        */
        //entity.rb.position = Vector3.MoveTowards(_entity.rb.position, ((Vector3)_entity.rb.position + _direction), _distance);

    }

    public override void Undo()
    {
        //_entity.MoveTo(_entity.transform.position, _originalPosition);
    }
}
