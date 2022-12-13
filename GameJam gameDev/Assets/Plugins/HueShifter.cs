using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HueShifter : MonoBehaviour
{
    public float Speed = 1;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.color = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * Speed / 2, 1), 1, 1));
    }
}
