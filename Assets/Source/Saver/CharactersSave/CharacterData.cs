using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public int Class { get; private set; } 
    public float[] SkeenColor { get; private set; }
    public float[] HairColor { get; private set; }
    public int EarID { get; private set; }
    public int HairID { get; private set; }
    public int HeadID { get; private set; }
    public int EyesID { get; private set; }
    public int EyesBrowsID { get; private set; }
    public int MouthID { get; private set; }
    public int BodyID { get; private set; }
    public int ArmLID { get; private set; }
    public int HandLID { get; private set; }
    public int FingersID { get; private set; }
    public int ArmRID { get; private set; }
    public int HandRID { get; private set; }
    public int LegLID { get; private set; }
    public int LegRID { get; private set; }
    public string Name { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int Magic { get; private set; }
    public int Exp {  get; private set; } 

    public void SetClass(int number)
    {
        Class = number;
    }

    public void SetColor(Color skeen,Color Hair)
    {
        SkeenColor = new float[4];
        HairColor = new float[4];

        SkeenColor[0] = skeen.r;
        SkeenColor[1] = skeen.g;
        SkeenColor[2] = skeen.b;
        SkeenColor[3] = skeen.a;

        HairColor[0] = Hair.r;
        HairColor[1] = Hair.g;
        HairColor[2] = Hair.b;
        HairColor[3] = Hair.a;
    }

    public void SetHead(int earID, int hairID, int headID, int eyesID, int eyesBrowsID, int mouthID)
    {
        EarID = earID;
        HairID = hairID;
        HeadID = headID;
        EyesID = eyesID;
        EyesBrowsID = eyesBrowsID;
        MouthID = mouthID;
    }

    public void SetBody(int bodyID, int armLID,int handLID, int fingersID, int armRID, int handRID, int legLID, int legRID)
    {
        BodyID = bodyID;
        ArmLID = armLID;
        HandLID = handLID;
        FingersID = fingersID;
        ArmRID = armRID;
        HandRID = handRID;
        LegLID = legLID;
        LegRID = legRID;
    }

    public void SetStats(string name, int attack, int defense, int health, int magic)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
        Health = health;
        Magic = magic;
    }

    public void SetExp(int exp)
    {
        Exp = exp;
    }
}
