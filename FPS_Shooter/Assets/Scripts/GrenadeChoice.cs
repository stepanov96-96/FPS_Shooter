using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrenadeChoice : MonoBehaviour
{
    public static GrenadeChoice Instance;

    public static int[] addGrenade = new int[3] { 0, 1, 2 };

    public static int currentItem = 0;

    public static int damageGrenade;

    [SerializeField]
    private TextMeshProUGUI[] VariablesGrenade;

    [SerializeField]
    private TextMeshProUGUI MainTextGrenade;

    [SerializeField]
    private Image Background;



    private void Awake()
    {
        currentItem = 0;
        damageGrenade = 0;

        for (int i = 0; i < addGrenade.Length; i++)
        {
            addGrenade[i] = 0;
        }

        Instance = this;
    }

    private void Start()
    {
        CurrentGrenade();
    }

    private void Update()
    {
        SwithGrenade();
    }

    public void SwithGrenade()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentItem++;
            if (currentItem >= 3)
                currentItem = 0;
            CurrentGrenade();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentItem--;
            if (currentItem <= -1)
                currentItem = 2;
            CurrentGrenade();
        }


    }

    public void NumberGrenade()
    {
        VariablesGrenade[0].text = "" + addGrenade[0];

        VariablesGrenade[1].text = "" + addGrenade[1];

        VariablesGrenade[2].text = "" + addGrenade[2];

        CurrentGrenade();
    }

    void CurrentGrenade()
    {

        switch (currentItem)
        {
            case 0:
                MainTextGrenade.text = "" + addGrenade[0];
                Background.color = new Color(0.05098039f, 0.3647059f, 0.5843138f, 0.7019608f);
                damageGrenade = 20;
                break;

            case 1:
                MainTextGrenade.text = "" + addGrenade[1];
                Background.color = new Color(0.1686275f, 0.7254902f, 0.2509804f, 0.7019608f);
                damageGrenade = 40;
                break;

            case 2:
                MainTextGrenade.text = "" + addGrenade[2];
                Background.color = new Color(0.8313726f, 0.2352941f, 0.08235294f, 0.7019608f);
                damageGrenade = 60;
                break;

            default:
                return;
                break;
        }

    }
}
