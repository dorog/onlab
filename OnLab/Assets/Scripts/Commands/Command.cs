using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command {

    public GameObject character;
    public int ID { get; set; }
    public int PanelSlot { get; set; }
    public Sprite sprite { get; set; }
    public bool newcmd { get; set; }

    public Command(int id)
    {
        this.ID = id;
        PanelSlot = -1;
        newcmd = true;
        character = GameObject.Find(Configuration.characterName);
    }
    public Command()
    {
        this.ID = -1;
    }

    public Command(int id, int panelSlot)
    {
        this.ID = id;
        PanelSlot = panelSlot;
    }

    public virtual void Effect() {
        //Debug.Log("realOne");
        return;
    }

    public virtual void Identity(int i, int aimnumber)
    {
        Debug.Log("cmd "+ i + " " +aimnumber);
    }
}
