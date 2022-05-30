using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Level
{
    [Range(1, 11)]
    public int partCount = 11;

    [Range(0, 11)]
    public int deathPartCount = 1;

}

[CreateAssetMenu(fileName = "New Stage")]
public class Stages : ScriptableObject
{
    public Color stageLevelPartColor = Color.white;
    public List<Level> levels = new List<Level>();
}
