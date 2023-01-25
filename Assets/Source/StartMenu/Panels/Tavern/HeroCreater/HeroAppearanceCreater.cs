using System.Collections;
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

    public void CreateAppereance(Appearance appearance)
    {
        Color hairColor = _hairColor[Random.Range(0,_hairColor.Count)];
        Color skeenColor = _skeenColor[Random.Range(0,_skeenColor.Count)];
        CreateHead(appearance, hairColor, skeenColor);
        CreateBody(appearance, skeenColor);
    }

    private void CreateHead(Appearance appearance, Color hairColor, Color skeenColor)
    {
        Sprite ear = _ear[Random.Range(0, _ear.Count)];
        Sprite hair = _hair[Random.Range(0, _hair.Count)];
        Sprite head = _head[Random.Range(0, _head.Count)];
        Sprite eyes = _eyes[Random.Range(0, _eyes.Count)];
        Sprite eyesbrows = _eyesbrows[Random.Range(0, _eyesbrows.Count)];
        Sprite mouth = _mouth[Random.Range(0, _mouth.Count)];

        appearance.SetHead(hairColor, skeenColor, ear, hair, head, eyes, eyesbrows, mouth);
    }

    private void CreateBody(Appearance appearance, Color skeenColor)
    {
        Sprite body = _body[Random.Range(0, _body.Count)];
        Sprite armL = _armL[Random.Range(0, _armL.Count)];
        Sprite handL = _handL[Random.Range(0, _handL.Count)];
        Sprite fingers = _fingersL[Random.Range(0, _fingersL.Count)];
        Sprite armR = _armR[Random.Range(0, _armR.Count)];
        Sprite handR = _handR[Random.Range(0, _handR.Count)];
        Sprite legL = _legL[Random.Range(0, _legL.Count)];
        Sprite legR = _legR[Random.Range(0, _legR.Count)];

        appearance.SetBody(skeenColor, body, armL, handL, fingers, armR, handR, legL, legR);
    }
}
