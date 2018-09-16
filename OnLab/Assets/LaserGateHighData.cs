using UnityEngine;

public class LaserGateHighData : HighData {

    public int offedHigh = 2;

	public override int HeightCalculate()
    {
        int activeSwitches = transform.GetComponent<LaserGate>().activeSwitches;
        if (activeSwitches == 0)
        {
            return offedHigh;
        }
        return baseHigh;
    }
}
