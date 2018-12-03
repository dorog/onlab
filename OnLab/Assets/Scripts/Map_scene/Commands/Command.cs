using UnityEngine;

public class Command {
    public int Type { get; set; }
    public int PanelSlot { get; set; }
    public Sprite Img { get; set; }
    protected StartActions sa;

    public Command()
    {
        Type = SharedData.emptyCommandID;
    }

    public virtual void Effect() { }
}
