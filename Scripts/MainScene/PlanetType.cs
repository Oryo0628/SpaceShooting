using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetType : MonoBehaviour
{
    public enum PlanetMoveType{
        Top,
        Left, 
        Right
    }

    public PlanetMoveType Type;

    public void SetType(PlanetMoveType type)
    {
        Type = type;
    }
}
