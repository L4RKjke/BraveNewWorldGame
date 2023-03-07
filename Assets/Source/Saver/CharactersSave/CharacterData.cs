using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public int Class;
    public int[] SkillsID = new int[3];
    public float[] SkeenColor = new float[4];
    public float[] HairColor = new float[4];
    public int EarID;
    public int HairID;
    public int HeadID;
    public int EyesID;
    public int EyesBrowsID;
    public int MouthID;
    public int BodyID;
    public int ArmLID;
    public int HandLID;
    public int FingersID;
    public int ArmRID;
    public int HandRID;
    public int LegLID;
    public int LegRID;
    public string Name;
    public int Attack;
    public int Defense;
    public int Health;
    public int Magic;
    public int Exp;
    public bool IsSold = false;

    public void Solded()
    {
        IsSold = true;
    }

    public void SetClass(int number)
    {
        Class = number;
    }

    public void AddSkillId(int idSkill, int numberSkill)
    {
        SkillsID[numberSkill] = idSkill;
    }

    public void SetColor(Color skeen,Color Hair)
    {
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

    public void SetStats(int attack, int defense, int health, int magic)
    {
        Attack = attack;
        Defense = defense;
        Health = health;
        Magic = magic;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetExp(int exp)
    {
        Exp = exp;
    }
}
