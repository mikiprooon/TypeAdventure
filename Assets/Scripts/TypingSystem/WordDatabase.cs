using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDatabase : MonoBehaviour
{
    // ふつうレベルでの問題集
    private List<(string qText, string aText, string mText)> _normalWordList = new List<(string, string, string)>{
        ("問題", "mondai", "もんだい"),
        ("解答", "kaitou", "かいとう"),
        ("読み方", "yomikata", "よみかた"),
        ("最高", "saikou", "さいこう"),
        ("最底", "saitei", "さいてい"),
        ("横浜", "yokohama", "よこはま"),
        ("学校", "gakkou", "がっこう")

    };

    public (string, string, string) GetNormalRandomWord(){
        int index = Random.Range(0, _normalWordList.Count);
        return _normalWordList[index];
    }
}

