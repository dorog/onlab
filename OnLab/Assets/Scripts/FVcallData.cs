using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FVcallData {

    public int fvNumber { get; set; }
    public int aimNumber { get; set; }
    public FVcallData(int fvNumber, int aimNumber)
    {
        this.fvNumber = fvNumber;
        this.aimNumber = aimNumber;
    }
}
