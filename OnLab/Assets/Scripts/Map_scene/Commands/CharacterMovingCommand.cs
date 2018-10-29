
public class CharacterMovingCommand : Command
{
    public MapGenerator mapGen;
    public StartActions sa;

    public CharacterMovingCommand(int _PanelSlot)
    {
        ID = SharedData.realCommandID;
        PanelSlot = _PanelSlot;
        mapGen = MapGenerator.GetMapGenerator();
        sa = StartActions.GetStartActions();
    }

    public override void Effect()
    {
        sa.ResetFvInARow();
    }
}
