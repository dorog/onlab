
public class CharacterMovingCommand : Command
{
    public MapGenerator mapGen;

    public CharacterMovingCommand(int _PanelSlot)
    {
        ID = SharedData.realCommandID;
        PanelSlot = _PanelSlot;
        mapGen = MapGenerator.GetMapGenerator();
    }
}
