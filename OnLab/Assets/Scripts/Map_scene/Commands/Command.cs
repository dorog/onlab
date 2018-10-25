using UnityEngine;

public class Command {
    public int ID { get; set; }
    public int PanelSlot { get; set; }
    public Sprite Sprite { get; set; }

    public Command()
    {
        ID = SharedData.emptyCommandID;
    }

    public virtual void Effect() { }
}
