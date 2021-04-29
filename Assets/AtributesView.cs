using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributesView : MonoBehaviour
{
    private Atributes atributes;
    [SerializeField] private Texture textureBack;
    [SerializeField] private Texture textureFront;
    [SerializeField] private Renderer _GOrebnderer;


    private void Start()
    {
        atributes = GetComponent<Atributes>();
    }

    void OnGUI()
    {
        _GOrebnderer.material.color = RGBSlider(new Rect(10, 10, 200, 20), _GOrebnderer.material.color);
        DrawHealth(new Rect(100, 100, 100, 30), atributes.Health);
    }

    void DrawHealth(Rect rect, float value)
    {
        GUI.DrawTexture(rect, textureBack, ScaleMode.StretchToFill);
        var frontRect = new Rect(rect.x, rect.y, rect.width * value, rect.height);
        GUI.DrawTexture(frontRect, textureFront, ScaleMode.ScaleAndCrop);
    }

    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");
        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alfa");
        return rgb;
    }

    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f, sliderMaxValue);
        return sliderValue;
    }
}