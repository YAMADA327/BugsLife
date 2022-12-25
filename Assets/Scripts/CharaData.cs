using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaData : MonoBehaviour
{
    private const int charaPx = 32;
    private const int charaPx_half = 16;
    private const int disp_px = 320;
    private const int disp_py = -40;
    private int charaLv;
    public int CharaLv { get; set; }
    private int charaExp;
    public int CharaExp { get; set; }
    private int[] expArry;  
    private int charaHp;
    public int CharaHp { get; set; }
    private int charaMaxHp;
    public int CharaMaxHp { get; set; }
    private int charaAtk;
    public int CharaAtk { get; set; }

    private int charaDef;
    public int CharaDef { get; set; }
    private int charaWepon;
    public int CharaWepon { get; set; }
    private int charaArmor;
    public int CharaArmor { get; set; }
    private string weponName;
    public string WeponName { get; set; }
    private string armorName;
    public string ArmorName { get; set; }
    private int charaX;
    public int CharaX { get; set; }
    private int charaY;
    public int CharaY { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CharaInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharaInit()
    {
        CharaLv = 1;
        CharaExp = 0;
        CharaMaxHp = CharaHp = 30;
        CharaAtk = 3;
        CharaDef = 0;
        CharaWepon = 0;
        CharaArmor = 0;
        WeponName = "なし";
        ArmorName　= "なし";
        expArry = new int[]
        {0,5,25,60,110,180,250,350,999};


        CharaX = 7;
        CharaY = 6;
        CharaMove();

    }
    public void CharaMove(int nx,int ny)
    {

        Vector3 p = transform.position;

        p.x = CharaX * charaPx + charaPx_half + nx + disp_px;
        p.y = CharaY * charaPx + charaPx_half + ny + disp_py;
        p.z = -2;
        transform.position = p;
    }
    public void CharaMove(){
                
        Vector3 p = transform.position;

        p.x = CharaX * charaPx + charaPx_half + disp_px;
        p.y = CharaY * charaPx + charaPx_half + disp_py;
        p.z = -2;
        transform.position = p;
    }

    public int GetAttack()
    {
        int atk = CharaAtk + CharaWepon;
        return atk;
    }
    public int GetDef()
    {
        int def = CharaDef + CharaArmor;
        return def;
    }
    public bool GetExp(int exp)
    {
        bool LvUP;
        CharaExp = CharaExp + exp;
        if(CharaExp < expArry[CharaLv])
        {
            LvUP = false;
        }
        else
        {
            LvUP = true;
            CharaLv = CharaLv + 1;
            CharaHp = CharaMaxHp = CharaMaxHp + 5;
            CharaAtk = CharaAtk + 2;
            CharaDef = CharaDef + 2;
        }
        return LvUP;
    }

    public bool GetDamage(int damage)
    {
        bool isDead = false;
        CharaHp = CharaHp - damage;
        if(CharaHp <= 0)
        {
            CharaHp = 0;
            isDead = true;
        }
        return isDead;
    }
    public int GetNLv()
    {
        int exp = expArry[CharaLv] - CharaExp;
        return exp;
    }
}
