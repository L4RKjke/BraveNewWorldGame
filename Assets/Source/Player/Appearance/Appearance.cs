using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _earRight; //
    [SerializeField] private SpriteRenderer _hair; //
    [SerializeField] private SpriteRenderer _body; //
    [SerializeField] private SpriteRenderer _head; //
    [SerializeField] private SpriteRenderer _eyes; //
    [SerializeField] private SpriteRenderer _eyesbrows; //
    [SerializeField] private SpriteRenderer _mouth; //
    [SerializeField] private SpriteRenderer _armL; //
    [SerializeField] private SpriteRenderer _handL; //
    [SerializeField] private SpriteRenderer _fingersL; //
    [SerializeField] private SpriteRenderer _armR; // 
    [SerializeField] private SpriteRenderer _handR; //
    [SerializeField] private SpriteRenderer _legL; //
    [SerializeField] private SpriteRenderer _legR; //

    [SerializeField] private Sprite _standartArmor;
    [SerializeField] private Sprite _standartWeapon;

    public Sprite StandartArmor => _standartArmor;
    public Sprite StandartWeapon => _standartWeapon;

    public void SetHead(Color hairColor, Color skeenColor, Sprite ear, Sprite hair, Sprite head, Sprite eyes, Sprite eyesbrows, Sprite mouth)
    {
        _earRight.color = skeenColor;
        _earRight.sprite = ear;
        _hair.sprite = hair;
        _hair.color = hairColor;
        _head.color = skeenColor;
        _head.sprite = head;
        _eyes.sprite = eyes;
        _eyesbrows.sprite = eyesbrows;
        _mouth.sprite = mouth;
    }

    public void SetBody(Color skeenColor, Sprite body, Sprite armL, Sprite handL, Sprite fingers, Sprite armR, Sprite handR, Sprite legL, Sprite legR)
    {
        _body.color = skeenColor;
        _body.sprite = body;
        _armL.color = skeenColor;
        _armL.sprite = armL;
        _handL.color = skeenColor;
        _handL.sprite = handL;
        _fingersL.color = skeenColor;
        _fingersL.sprite = fingers;
        _armR.color = skeenColor;
        _armR.sprite = armR;
        _handR.color = skeenColor;
        _handR.sprite = handR;
        _legL.color = skeenColor;
        _legL.sprite = legL;
        _legR.color = skeenColor;
        _legR.sprite = legR;
    }

    public void ChangeHelmItem(bool isWear)
    {
        _hair.enabled = !isWear;
    }
}
