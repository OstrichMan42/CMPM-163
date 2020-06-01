using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemGenerator : MonoBehaviour
{
    /*
    private string axiom = "F-G-G";
    private string lSystemString;
    private float length = 1;
    private float angle = -120;
    */

    private string axiom = "F";
    private string lSystemString;
    private float length = 1;
    private float angle = 25;
    

    private Dictionary<char, string> rules = new Dictionary<char, string>();
    private Stack<TransformInfo> transformStack = new Stack<TransformInfo>();
    private bool isGenerating = false;

    // Start is called before the first frame update
    void Start()
    {
        rules.Add('F', "FF+[+F-F-F]-[-F+F+F]");

        //rules.Add('G', "GG");
        //rules.Add('F', "F-G+F+G-F");

        lSystemString = axiom;

        StartCoroutine(GenerateLSystem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateLSystem()
    {
        int count = 0;

        while (count < 5)
        {
            if (!isGenerating)
            {
                isGenerating = true;
                StartCoroutine(Generate());
                count++;
                length /= 2;

                //transform.Translate(Vector3.up * 0.25f);

            } else{
                yield return null;
            }
        }
    }

    IEnumerator Generate()
    {
        string newString = "";

        char[] lSystemChar = lSystemString.ToCharArray();

        for (int i = 0; i < lSystemString.Length; i++)
        {
            char currentCharacter = lSystemString[i];
            if (rules.ContainsKey(currentCharacter))
            {
                newString += rules[currentCharacter];
            } else
            {
                newString += currentCharacter;
            }
        }

        lSystemString = newString;
        Debug.Log(lSystemString);

        lSystemChar = lSystemString.ToCharArray();

        for (int i = 0; i < lSystemString.Length; i++)
        {
            char currentCharacter = lSystemString[i];
            if (currentCharacter == 'F' || currentCharacter == 'G')
            {
                // Move forward
                float moved = 0f;
                while (moved < length)
                {
                    Vector3 initialPosition = transform.position;

                    if (Time.deltaTime * 2 > length - moved) transform.Translate(Vector3.forward * (length - moved));
                    else transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                    moved += Time.deltaTime * 2;
                    Debug.DrawLine(initialPosition, transform.position, Color.white, 10000f, false);
                    yield return null;
                }
            }
            else if (currentCharacter == '+')
            {
                transform.Rotate(Vector3.up * angle);
            }
            else if (currentCharacter == '-')
            {
                transform.Rotate(Vector3.up * -angle);
            }
            else if (currentCharacter == '[')
            {
                TransformInfo ti = new TransformInfo();
                ti.position = transform.position;
                ti.rotation = transform.rotation;
                transformStack.Push(ti);
            }
            else if (currentCharacter == ']')
            {
                TransformInfo ti = transformStack.Pop();
                transform.position = ti.position;
                transform.rotation = ti.rotation;
            }
         
        }
        isGenerating = false;
    }
}