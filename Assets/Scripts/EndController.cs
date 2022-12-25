using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public GameObject canpas;
    public GameObject Panel2;
    // Start is called before the first frame update
    void Start()
    {
        Panel2.SetActive(false);
        EndSequence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EndSequence()
    {
        switch (GameManager.ERank)
        {
            case GameManager.EndRank.S:
                StartCoroutine("SetS");
                break;
            case GameManager.EndRank.A:
                StartCoroutine("SetA");
                break;
            case GameManager.EndRank.B:
                StartCoroutine("SetB");
                break;
            case GameManager.EndRank.C:
                StartCoroutine("SetC");
                break;
        }
    }


    IEnumerator Y_RETURN()
    {
        yield return null;
        yield return new WaitUntil(() => Input.anyKeyDown);
        text1.text = "";
        text2.text = "";
        text3.text = "";
        text4.text = "";
    }


    IEnumerator SetS()
    {
        text1.text = "「これで！！ラストぉぉぉ！！」";
        text2.text = "気合とともに最後の1匹を倒す。";
        text3.text = "「うそ…こんなに早く退治してしまうなんて…」";
        text4.text = "振り返るとミクが信じられないといった顔でこっちを見ていた。";
        yield return Y_RETURN();
        text1.text = "「よし、じゃぁこれで元の世界に戻してくれるな？」";
        text2.text = "ミク「も…！もちろんだよ！」";
        text3.text = "ミクが元気よく返事を返すと同時、俺の体が輝き始めた。";
        text4.text = "はー、疲れた。俺は仰向けに四肢を地面に投げ出す。";
        yield return Y_RETURN();
        text1.text = "するとミクが俺の横に座り、俺の頭を膝の上に乗せた。";
        text2.text = "ミク「あなたのおかげで世界は救われたよ。本当に…ありがとう」";
        text3.text = "「まぁ世界もそうだけど、ミクも救えてよかったよ」";
        text4.text = "ミク「！！！！」";
        yield return Y_RETURN();
        text1.text = "俺のそんなつぶやきにミクは顔を真っ赤にする。";
        text2.text = "ミク「そ…そんなこと言ったって他にお礼なんて出せないんだからね！」";
        text3.text = "「返事がツンデレになってんぞ」";
        text4.text = "お前もしかしてそれが素か。";
        yield return Y_RETURN();
        text1.text = "俺のその言葉と同時、俺の体が光に包まれた。";
        text2.text = "薄れゆく意識の中、俺は微笑みをたたえたミクの姿をずっと見ていた";
        yield return Y_RETURN();
        text1.text = "「ん…ここは…？」";
        text2.text = "俺はゆっくりと目を覚ます。体を起こすとそこは俺の部屋だった。";
        text3.text = "「ゲームを作りながらそのまま寝ちゃったのか」";
        text4.text = "まさかの夢落ちであった。";
        yield return Y_RETURN();
        text1.text = "カーテンを開ける。空はもうすっかり明るくなっていた。";
        text2.text = "「そういえば先輩にデバグを頼んでいたんだった！準備しないと！」";
        text3.text = "ふと視線を目の前に落とした。";
        text4.text = "「――――――――！」";
        yield return Y_RETURN();
        text1.text = "カーテンを開ける。空はもうすっかり明るくなっていた。";
        text2.text = "「そういえば先輩にデバグを頼んでいたんだった！準備しないと！」";
        text3.text = "ふと視線を目の前に落とした。";
        text4.text = "「――――――――！」";
        yield return Y_RETURN();
        Panel2.SetActive(true);
        text1.text = "画面に表示されていた姿に俺は笑みをこぼす。";
        text2.text = "「さぁ、今日も一日頑張りますか！」";
        text3.text = "俺はそう言って準備に取り掛かった。";
        text4.text = "（――――――――ありがとう）";
        yield return Y_RETURN();
        text1.text = "評価：";
        text2.text = "　　【Sランク】";
        text3.text = "文句なしのSランク！おめでとうございます。";
        text4.text = "ここまで遊んでもらえて作者もにっこりしてます。";
        yield return Y_RETURN();

        SceneManager.LoadScene("TitleScene");


    }
    IEnumerator SetA()
    {
        text1.text = "「はぁ…はぁ…全部倒したよ」";
        text2.text = "最後の1匹を倒した俺はそう言いながらミクの方に振り返った。";
        text3.text = "彼女は嬉しそうに俺に微笑みかけた。";
        text4.text = "ミク「ありがとう。これで世界は救われたよ」";
        yield return Y_RETURN();
        text1.text = "「よし、じゃぁこれで元の世界に戻してくれるな？」";
        text2.text = "ミク「もちろんだよ！」";
        text3.text = "ミクが元気よく返事を返すと同時、俺の体が輝き始めた。";
        text4.text = "「あ、あと俺のお嫁さんになる約束は！？」";
        yield return Y_RETURN();
        text1.text = "俺がそう言うと、ミクは悲しそうに微笑んだ。";
        text2.text = "ミク「それは…無理かな」";
        text3.text = "言うと同時ミクの体が光の粒子になって消え始めた。";
        text4.text = "「！？ミク！それ！！」";
        yield return Y_RETURN();
        text1.text = "ミク「世界は救われたけど、私の体はダメだったみたい」";
        text2.text = "「そんな……」";
        text3.text = "ミク「そんな顔しないで。私はこの世界が救われた、それだけで";
        text4.text = "　　満足だから。だから――――ありがとう」";
        yield return Y_RETURN();
        text1.text = "ミクのその言葉と同時、俺の体が光に包まれた。";
        text2.text = "薄れゆく意識の中、俺は微笑みをたたえたまま光となって";
        text3.text = "消えるミクの姿を見ていた……";
        yield return Y_RETURN();
        text1.text = "「ん…ここは…？」";
        text2.text = "俺はゆっくりと目を覚ます。体を起こすとそこは俺の部屋だった。";
        text3.text = "「ゲームを作りながらそのまま寝ちゃったのか」";
        text4.text = "まさかの夢落ちであった。";
        yield return Y_RETURN();
        text1.text = "カーテンを開ける。空はもうすっかり明るくなっていた。";
        text2.text = "「そういえば先輩にデバグを頼んでいたんだった！準備しないと！」";
        text3.text = "「――――助けてあげたかったなぁ」";
        text4.text = "ふとつぶやいた俺の声は朝日に溶けて消えた。";
        yield return Y_RETURN();
        text1.text = "評価：";
        text2.text = "　　【Aランク】";
        text3.text = "世界は守れましたが時間がかかりすぎてミクが消えてしまいました。";
        text4.text = "あなたなら彼女を救えるはずです。頑張ってください。";
        yield return Y_RETURN();
        SceneManager.LoadScene("TitleScene");
    }
    IEnumerator SetB()
    {
        text1.text = "「はぁ…はぁ…ようやく全部倒した」";
        text2.text = "思ったよりも時間がかかってしまった。";
        text3.text = "周りを見渡すともう世界はほとんど虫たちに";
        text4.text = "食べつくされていた。";
        yield return Y_RETURN();
        text1.text = "「ミクは…いないのか？」";
        text2.text = "もしかして、消えてしまったのか…？";
        text3.text = "「え…？これどうやって元の世界に戻ればいいんだ…？」";
        text4.text = "俺はそう思いながらただずっと立ち尽くしていた。";
        yield return Y_RETURN();
        text2.text = "バシャーン！！";
        yield return Y_RETURN();
        text1.text = "瞬間、俺は目を覚ました。";
        text2.text = "目を開けると目の前にはバケツを持った先輩。";
        text3.text = "「え…？先輩なんで？？？」";
        text4.text = "先輩「お前がゲームのデバグ手伝ってくれって呼んだんだろうが」";
        yield return Y_RETURN();
        text1.text = "先輩「それで寝コケてるとかいいご身分だな。んー？？」";
        text2.text = "「ｽ･･･ｽﾐﾏｾﾝﾃﾞｼﾀ」";
        text3.text = "「よろしい。それで、デバグやってほしいゲームってどれよ」";
        text4.text = "言われて俺は、先輩と作っていたゲームのデバグ作業をやり始めた。";
        yield return Y_RETURN();
        text1.text = "評価：";
        text2.text = "　　【Bランク】";
        text3.text = "世界は守れましたが時間がかかりすぎてミクが消えてしまったようです。";
        text4.text = "次はもっとうまくやれるはず。彼女を助けてください";
        yield return Y_RETURN();
        SceneManager.LoadScene("TitleScene");
    }
    IEnumerator SetC()
    {
        text1.text = "「はぁ…はぁ…ようやく全部倒した」";
        text2.text = "思ったよりも時間がかかってしまった。";
        text3.text = "周りを見渡すともう世界はほとんど虫たちに";
        text4.text = "食べつくされていた。";
        yield return Y_RETURN();
        text1.text = "「ミクは…いないのか？」";
        text2.text = "もしかして、消えてしまったのか…？";
        text3.text = "「え…？これどうやって元の世界に戻ればいいんだ…？」";
        text4.text = "俺はそう思いながらただずっと立ち尽くしていた。";
        yield return Y_RETURN();
        text1.text = "評価：";
        text2.text = "　　【Cランク】";
        text3.text = "時間がかかりすぎて世界が終わってしまったようです。";
        text4.text = "次はもっとうまくやれるはず。彼女を助けてください";
        yield return Y_RETURN();
        SceneManager.LoadScene("TitleScene");
    }
}
