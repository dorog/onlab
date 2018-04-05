using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command {

    public int ID { get; set; }
    public int PanelSlot { get; set; }
    public Sprite sprite { get; set; }
    public Command(int id)
    {
        this.ID = id;
        //this.sprite = Resources.Load<Sprite>("ItemSprites/item");
        PanelSlot = -1;
    }
    public Command()
    {
        this.ID = -1;
    }

    public void Effect() { }
}
