using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TextWithBackPlaneGenerator : MonoBehaviour
{
	public void Approve()
    {
        text.text = CompileRichText(data);
        backPlane.sizeDelta = new Vector2(CalculateLengthOfMessage(data, text.font, text.fontSize) + 8, backPlane.sizeDelta.y);
	}

    public static int CalculateLengthOfMessage(RichTextElement[] message, Font font, int fontSize)
    {
        int totalLength = 0;
        
        CharacterInfo characterInfo = new CharacterInfo();

        foreach (var str in message)
        {
            font.RequestCharactersInTexture(new String(str.text.Distinct().ToArray()), str.size, str.style);
            foreach (char c in str.text)
            {
                if (str.size == -1)
                {
                    font.GetCharacterInfo(c, out characterInfo, fontSize, str.style);
                }
                else
                {
                    font.GetCharacterInfo(c, out characterInfo, str.size, str.style);
                }
                totalLength += characterInfo.advance;
            }
        }
        return totalLength;
    }

    public static string CompileRichText(RichTextElement[] data)
    {
        var current = new System.Text.StringBuilder();
        foreach (var str in data)
        {

            switch (str.style)
            {
                case FontStyle.Bold:
                    current.Append("<b>");
                    break;
                case FontStyle.Italic:
                    current.Append("<i>");
                    break;
                case FontStyle.BoldAndItalic:
                    current.Append("<b><i>");
                    break;
            }
            if (str.size != -1) current.Append("<size=" + str.size.ToString() + ">");
            if (str.colour != "") current.Append("<color=" + str.colour + ">");

            current.Append(str.text);

            if (str.size != -1) current.Append("</size>");
            if (str.colour != "") current.Append("/<color>");
            switch (str.style)
            {
                case FontStyle.Bold:
                    current.Append("</b>");
                    break;
                case FontStyle.Italic:
                    current.Append("</i>");
                    break;
                case FontStyle.BoldAndItalic:
                    current.Append("</b></i>");
                    break;
            }
        }
        return current.ToString();
    }

    public RichTextElement[] data;
    public Text text;
    public RectTransform backPlane;
}

[Serializable]
public struct RichTextElement
{
    public RichTextElement(string text, int size, string colour, FontStyle style)
    {
        this.text = text;
        this.size = size;
        this.colour = colour;
        this.style = style;
    }

    public string text;
    public int size;
    public string colour;
    public FontStyle style;
}