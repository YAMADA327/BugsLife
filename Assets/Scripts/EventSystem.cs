using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EventSystem : MonoBehaviour
{
    private int[]  evFlg;
    public Text TB1;
    public Text TB2;
    public Text TB3;
    public GameObject EP;
    public enum PlayMode {PLAY_SEQ,EV_SEQ};
    public enum ActMode {STAY_SEQ,UPMOVE_SEQ, DOWNMOVE_SEQ, LEFTMOVE_SEQ, RIGHTMOVE_SEQ};
    public PlayMode PM;
    public ActMode AM;


    // Start is called before the first frame update
    void Start()
    {
        PM = PlayMode.PLAY_SEQ;
        AM = ActMode.STAY_SEQ;
        evFlg = new int[10];
        for(int i = 0; i < 0; i++)
        {
            evFlg[i] = 0;
        }
        TB1.text = "";
        TB2.text = "";
        TB3.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckEvent(int Mcnt ,CharaData CD)
    {
        if(evFlg[0] == 0)
        {
            StartCoroutine("ev1");
        }else if(evFlg[1] == 0 && Mcnt == 1){
            StartCoroutine("ev2");
        }
        else if (evFlg[2] == 0 && Mcnt == 2)
        {
            StartCoroutine("ev3");
        }
        else if (evFlg[3] == 0 && Mcnt == 3)
        {
            StartCoroutine("ev4");
            CD.CharaHp = CD.CharaMaxHp;
        }
        else if (evFlg[4] == 0 && Mcnt == 4)
        {
            StartCoroutine("ev5");
        }
        else if (evFlg[5] == 0 && Mcnt == 5)
        {
            StartCoroutine("ev6");
        }
        else if (evFlg[6] == 0 && CD.CharaX ==1 && CD.CharaY == 1)
        {
            StartCoroutine("ev7");
            CD.CharaArmor = 4;
            CD.ArmorName = "【パジャマ】";
        }
        else if (evFlg[7] == 0 && CD.CharaX == 12 && CD.CharaY == 2)
        {
            StartCoroutine("ev8");
            CD.CharaWepon = 5;
            CD.WeponName = "【ハエたたき】";
        }
        else if (evFlg[8] == 0 && CD.CharaX == 7 && CD.CharaY == 5)
        {
            StartCoroutine("ev9");
            CD.CharaHp = CD.CharaMaxHp;

        }
        else if (evFlg[9] == 0 && CD.CharaX == 7 && CD.CharaY == 11)
        {
            StartCoroutine("ev10");
            CD.CharaHp = CD.CharaMaxHp;
        }
    }


    public void SetEv(int num)
    {
        evFlg[num] = 1;
    }

    IEnumerator Y_RETURN()
    {
        yield return null;
        yield return new WaitUntil(() => Input.anyKeyDown);
        TB1.text = "";
        TB2.text = "";
        TB3.text = "";
    }

    private IEnumerator ev1()
    {
        PM = PlayMode.EV_SEQ;
        SetEv(0);
        TB1.text = "――――あれ、ここはどこだろう";
        TB2.text = "あっちに人がいる。話しかけてみよう。";
        EP.SetActive(true);
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev2()
    {
        PM = PlayMode.EV_SEQ;
        SetEv(1);
        EP.SetActive(true);
        TB1.text = "ミク「こんにちわー。私ミクっていうの。」";
        TB2.text = "ミク「私、あなたにお願いがあるの。」";
        yield return Y_RETURN();
        TB1.text = "「お願い？」";
        TB2.text = "「というか、ここどこ？」";
        yield return Y_RETURN();
        TB1.text = "ミク「ここはあなたが作った世界ダヨ」";
        TB2.text = "ミク「実はあなたにこの世界を救ってほしいの」";
        yield return Y_RETURN();
        TB1.text = "「世界を救う？えらく唐突じゃない？」";
        TB2.text = "ミク「これはあなたにしかできないことなの」";
        TB3.text = "ミク「この世界に巣くった虫たちを退治してほしいの」";
        yield return Y_RETURN();
        TB1.text = "ミク「倒してくれたらお礼に元の世界に返してあげる！」";
        TB2.text = "「それは退治しないと元の世界に返してあげないという";
        TB3.text = "　ただの脅迫では……？？」";
        yield return Y_RETURN();
        TB1.text = "ミク「じゃぁじゃぁ！お礼に１つなんでも聞いてあげる」";
        TB2.text = "「……え？」";
        TB3.text = "今なんでもって言った？？";
        yield return Y_RETURN();
        TB1.text = "「じゃぁ俺のお嫁さんになってくだｓ…」";
        TB2.text = "ミク「そう言うところが童貞なんだゾ☆」";
        TB3.text = "辛辣ーーーーーーーー！！！！！";
        yield return Y_RETURN();
        TB1.text = "ということで世界を救うことになった。";
        TB2.text = "虫を退治して回ろう！";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev3()
    {
        Debug.Log("ev3");
        PM = PlayMode.EV_SEQ;
        SetEv(2);
        EP.SetActive(true);
        TB1.text = "ミク「最初はモスキートから退治するのがいいと思う」";
        TB2.text = "ミク「ｘ：１、Ｙ：１の場所にいいものがあるヨ」";
        TB3.text = "ミク「時間がないの…早く、できるだけ早くお願いします」";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev4()
    {
        Debug.Log("ev4");
        PM = PlayMode.EV_SEQ;
        SetEv(3);
        EP.SetActive(true);
        TB1.text = "ミク「応援してるネ。がんばって」";
        TB2.text = "HPが回復した！！";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev5()
    {
        Debug.Log("ev5");
        PM = PlayMode.EV_SEQ;
        SetEv(4);
        EP.SetActive(true);
        TB1.text = "ミク「え？しくこくない？時間がないんだよ？？」";
        TB2.text = "ゲスを見るような見られた！ゾクゾクした！！";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev6()
    {
        Debug.Log("ev6");
        PM = PlayMode.EV_SEQ;
        SetEv(5);
        EP.SetActive(true);
        TB2.text = "ミク「――――うん。わかった。やりたくないんだね」";
        yield return Y_RETURN();
        TB2.text = "ミク「　　　　　　　さ　よ　う　な　ら」";
        yield return Y_RETURN();
        TB2.text = "ミクから999のダメージを受けた！死んでしまった！！";
        yield return Y_RETURN();
        EP.SetActive(false);
        StartCoroutine("GameOver");
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev7()
    {
        Debug.Log("ev7");
        PM = PlayMode.EV_SEQ;
        SetEv(6);
        EP.SetActive(true);
        TB2.text = "パジャマを見つけた！さっそく着てみた！！";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev8()
    {
        Debug.Log("ev8");
        PM = PlayMode.EV_SEQ;
        SetEv(7);
        EP.SetActive(true);
        TB2.text = "ハエたたきを見つけた！さっそく持ってみた！！";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev9()
    {
        Debug.Log("ev9");
        PM = PlayMode.EV_SEQ;
        SetEv(8);
        EP.SetActive(true);
        TB2.text = "エナドリを見つけた！ＨＰが回復した！！";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }
    private IEnumerator ev10()
    {
        Debug.Log("ev10");
        PM = PlayMode.EV_SEQ;
        SetEv(9);
        EP.SetActive(true);
        TB2.text = "エナドリを見つけた！ＨＰが回復した！！";
        yield return Y_RETURN();
        EP.SetActive(false);
        PM = PlayMode.PLAY_SEQ;
    }

    public void GORTN()
    {
        StartCoroutine("GameOver");
    }

    private IEnumerator GameOver()
    {
        PM = PlayMode.EV_SEQ;
        TB2.text = "残念！死んでしまった！！";
        EP.SetActive(true);
        yield return Y_RETURN();
        TB2.text = "    G A M E O V E A R";
        EP.SetActive(true);
        yield return Y_RETURN();
        EP.SetActive(false);
        SceneManager.LoadScene("TitleScene");
    }

    public void setSTAY()
    {
        AM = ActMode.STAY_SEQ;
    }

    public void setUP()
    {
        AM = ActMode.UPMOVE_SEQ;
    }

    public void setLEFT()
    {
        AM = ActMode.LEFTMOVE_SEQ;
    }

    public void setLIGHT()
    {
        AM = ActMode.RIGHTMOVE_SEQ;
    }

    public void setDOWN()
    {
        AM = ActMode.DOWNMOVE_SEQ;
    }

}
