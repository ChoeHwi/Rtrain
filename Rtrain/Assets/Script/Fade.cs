using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float alpha;
    public float speed = 0.015f;
    float red, green, blue, tRed, tGreen, tBlue;
    public bool Click;
    [SerializeField] GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        Image image = GetComponent<Image>();
        red = image.color.r;
        green = image.color.g;
        blue = image.color.b;
        alpha = image.color.a;
        Text textColor = text.GetComponent<Text>();
        tRed = textColor.color.r;
        tGreen = textColor.color.g;
        tBlue = textColor.color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (Click)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alpha);
            text.GetComponent<Text>().color = new Color(tRed, tGreen, tBlue, alpha);
            alpha -= speed;
        }
        if (alpha < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void FadeAway()
    {
        Click = true;
    }
}