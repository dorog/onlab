using UnityEngine;

public class TurnRightCmd : CharacterMovingCommand
{
    public TurnRightCmd(int id) : base(id) {
        Sprite = Resources.Load<Sprite>(SharedData.rightIcon);
    }

    public override void Effect()
    {
        mapGen.CharacterTurnRight();
    }
}
