using System.Collections.Generic;
using UnityEngine;

public class HeroAppearanceCreater : ScriptableObject
{
    [SerializeField] private List<Color> _skeenColor;
    [SerializeField] private List<Color> _hairColor;
    [SerializeField] private List<Sprite> _ear;
    [SerializeField] private List<Sprite> _hair;
    [SerializeField] private List<Sprite> _body;
    [SerializeField] private List<Sprite> _head;
    [SerializeField] private List<Sprite> _eyes;
    [SerializeField] private List<Sprite> _eyesbrows;
    [SerializeField] private List<Sprite> _mouth;
    [SerializeField] private List<Sprite> _armL;
    [SerializeField] private List<Sprite> _handL;
    [SerializeField] private List<Sprite> _fingersL;
    [SerializeField] private List<Sprite> _armR;
    [SerializeField] private List<Sprite> _handR;
    [SerializeField] private List<Sprite> _legL;
    [SerializeField] private List<Sprite> _legR;

    public void CreateAppereance(Appearance appearance, CharacterData characterData, bool isRandom = true)
    {
        if (isRandom)
        {
            Color hairColor = _hairColor[Random.Range(0, _hairColor.Count)];
            Color skeenColor = _skeenColor[Random.Range(0, _skeenColor.Count)];
            characterData.SetColor(skeenColor, hairColor);

            CreateRandomHead(appearance, characterData, hairColor, skeenColor);
            CreateRandomBody(appearance, characterData, skeenColor);
        }
        else
        {
            Color skeenColor = new Color(characterData.SkeenColor[0], characterData.SkeenColor[1], characterData.SkeenColor[2], characterData.SkeenColor[3]);
            SetHead(appearance, characterData, skeenColor);
            SetBody(appearance, characterData, skeenColor);
        }
    }

    private void SetBody(Appearance appearance, CharacterData characterData, Color skeenColor)
    {
        Sprite body = _body[characterData.BodyID];
        Sprite armL = _armL[characterData.ArmLID];
        Sprite handL = _handL[characterData.HandLID];
        Sprite fingers = _fingersL[characterData.FingersID];
        Sprite armR = _armR[characterData.ArmRID];
        Sprite handR = _handR[characterData.HandRID];
        Sprite legL = _legL[characterData.LegLID];
        Sprite legR = _legR[characterData.LegRID];

        appearance.SetBody(skeenColor, body, armL, handL, fingers, armR, handR, legL, legR);
    }

    private void SetHead(Appearance appearance, CharacterData characterData, Color skeenColor)
    {
        Color hairColor = new Color(characterData.HairColor[0], characterData.HairColor[1], characterData.HairColor[2], characterData.HairColor[3]);

        Sprite ear = _ear[characterData.EarID];
        Sprite hair = _hair[characterData.HairID];
        Sprite head = _head[characterData.HeadID];
        Sprite eyes = _eyes[characterData.EyesID];
        Sprite eyesbrows = null;
        Sprite mouth = _mouth[characterData.MouthID];

        if(characterData.EyesBrowsID != -1)
        {
            eyesbrows = _eyesbrows[characterData.EyesBrowsID];
        }

        appearance.SetHead(hairColor, skeenColor, ear, hair, head, eyes, eyesbrows, mouth);
    }

    private void CreateRandomHead(Appearance appearance, CharacterData characterData , Color hairColor, Color skeenColor)
    {
        int earID = Random.Range(0, _ear.Count);
        int hairID = Random.Range(0, _hair.Count);
        int headID = Random.Range(0, _head.Count);
        int eyesID = Random.Range(0, _eyes.Count);
        int eyesbrowsID = -1;
        int mouthID = Random.Range(0, _mouth.Count);

        Sprite ear = _ear[earID];
        Sprite hair = _hair[hairID];
        Sprite head = _head[headID];
        Sprite eyes = _eyes[eyesID];
        Sprite eyesbrows = null;
        Sprite mouth = _mouth[mouthID];

        if (_eyesbrows.Count > 0)
        {
            eyesbrowsID = Random.Range(0, _eyesbrows.Count);
            eyesbrows = _eyesbrows[eyesbrowsID];
        }

        characterData.SetHead(earID,hairID,headID,eyesID,eyesbrowsID,mouthID);
        appearance.SetHead(hairColor, skeenColor, ear, hair, head, eyes, eyesbrows, mouth);
    }

    private void CreateRandomBody(Appearance appearance, CharacterData characterData, Color skeenColor)
    {
        int bodyID = Random.Range(0, _body.Count);
        int armLID = Random.Range(0, _armL.Count);
        int handLID = Random.Range(0, _handL.Count);
        int fingersID = Random.Range(0, _fingersL.Count);
        int armRID = Random.Range(0, _armR.Count);
        int handRID = Random.Range(0, _handR.Count);
        int legLID = Random.Range(0, _legL.Count);
        int legRID = Random.Range(0, _legR.Count);

        Sprite body = _body[bodyID];
        Sprite armL = _armL[armLID];
        Sprite handL = _handL[handLID];
        Sprite fingers = _fingersL[fingersID];
        Sprite armR = _armR[armRID];
        Sprite handR = _handR[handRID];
        Sprite legL = _legL[legLID];
        Sprite legR = _legR[legRID];

        characterData.SetBody(bodyID,armLID,handLID,fingersID,armRID,handRID,legLID,legRID);
        appearance.SetBody(skeenColor, body, armL, handL, fingers, armR, handR, legL, legR);
    }
}
