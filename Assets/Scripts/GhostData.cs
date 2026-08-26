using UnityEngine;

public class GhostData : MonoBehaviour
{
    // Haamujen ominaisuudet
    public bool isRobot;
    public bool isHumanoid;
    public bool hasRedEyes;
    public bool isFloating;
    public bool speaksOnlyWhenNeeded;


    // Tarkistaa onko yokai
    public bool IsYokai()
    {
        if (isRobot) return true;

        if (hasRedEyes) return true;

        if (speaksOnlyWhenNeeded) return true;  

        return false;
    }
}
