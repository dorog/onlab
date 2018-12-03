
public class CharacterMovingCommand : Command
{
    protected MapGenerator mapGen;

    public CharacterMovingCommand(int _PanelSlot)
    {
        Type = SharedData.realCommandID;
        PanelSlot = _PanelSlot;
        mapGen = MapGenerator.GetMapGenerator();
        sa = StartActions.GetStartActions();
    }

    public override void Effect()
    {
        sa.ResetFvInARow();
    }
}
