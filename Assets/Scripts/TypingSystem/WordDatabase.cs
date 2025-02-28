using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDatabase : MonoBehaviour
{
    // かんたんレベルのEnemy
    private List<(string qText, string aText, string mText)> _easyWordList = new List<(string, string, string)>{
        ("あ", "a", "あ"),
        ("い", "i", "い"),
        ("う", "u", "う"),
        ("え", "e", "え"),
        ("お", "o", "お"),
        ("か", "ka", "か"),
        ("き", "ki", "き"),
        ("く", "ku", "く"),
        ("け", "ke", "け"),
        ("こ", "ko", "こ"),
        ("さ", "sa", "さ"),
        ("し", "si", "し"),
        ("す", "su", "す"),
        ("せ", "se", "せ"),
        ("そ", "so", "そ"),
        ("た", "ta", "た"),
        ("ち", "ti", "ち"),
        ("つ", "tu", "つ"),
        ("て", "te", "て"),
        ("と", "to", "と"),
        ("な", "na", "な"),
        ("に", "ni", "に"),
        ("ぬ", "nu", "ぬ"),
        ("ね", "ne", "ね"),
        ("の", "no", "の"),
        ("は", "ha", "は"),
        ("ひ", "hi", "ひ"),
        ("ふ", "hu", "ふ"),
        ("へ", "he", "へ"),
        ("ほ", "ho", "ほ"),
        ("ま", "ma", "ま"),
        ("み", "mi", "み"),
        ("む", "mu", "む"),
        ("め", "me", "め"),
        ("も", "mo", "も"),
        ("や", "ya", "や"),
        ("ゆ", "yu", "ゆ"),
        ("よ", "yo", "よ"),
        ("ら", "ra", "ら"),
        ("り", "ri", "り"),
        ("る", "ru", "る"),
        ("れ", "re", "れ"),
        ("ろ", "ro", "ろ"),
        ("わ", "wa", "わ"),
        ("を", "wo", "を"),
        ("ん", "nn", "ん"),
        ("が", "ga", "が"),
        ("ぎ", "gi", "ぎ"),
        ("ぐ", "gu", "ぐ"),
        ("げ", "ge", "げ"),
        ("ご", "go", "ご"),
        ("ざ", "za", "ざ"),
        ("じ", "zi", "じ"),
        ("ず", "zu", "ず"),
        ("ぜ", "ze", "ぜ"),
        ("ぞ", "zo", "ぞ"),
        ("だ", "da", "だ"),
        ("ぢ", "di", "ぢ"),
        ("づ", "du", "づ"),
        ("で", "de", "で"),
        ("ど", "do", "ど"),
        ("ば", "ba", "ば"),
        ("び", "bi", "び"),
        ("ぶ", "bu", "ぶ"),
        ("べ", "be", "べ"),
        ("ぼ", "bo", "ぼ"),
        ("ぱ", "pa", "ぱ"),
        ("ぴ", "pi", "ぴ"),
        ("ぷ", "pu", "ぷ"),
        ("ぺ", "pe", "ぺ"),
        ("ぽ", "po", "ぽ")
    };
    // ふつうレベルのBoss
    private List<(string qText, string aText, string mText)> _easyBossWordList = new List<(string, string, string)>{
        ("きゃ", "kya", "きゃ"),
        ("きゅ", "kyu", "きゅ"),
        ("きょ", "kyo", "きょ"),
        ("しゃ", "sya", "しゃ"),
        ("しゅ", "syu", "しゅ"),
        ("しょ", "syo", "しょ"),
        ("ちゃ", "tya", "ちゃ"),
        ("ちゅ", "tyu", "ちゅ"),
        ("ちょ", "tyo", "ちょ"),
        ("にゃ", "nya", "にゃ"),
        ("にゅ", "nyu", "にゅ"),
        ("にょ", "nyo", "にょ"),
        ("ひゃ", "hya", "ひゃ"),
        ("ひゅ", "hyu", "ひゅ"),
        ("ひょ", "hyo", "ひょ"),
        ("みゃ", "mya", "みゃ"),
        ("みゅ", "myu", "みゅ"),
        ("みょ", "myo", "みょ"),
        ("りゃ", "rya", "りゃ"),
        ("りゅ", "ryu", "りゅ"),
        ("りょ", "ryo", "りょ"),
        ("ぎゃ", "gya", "ぎゃ"),
        ("ぎゅ", "gyu", "ぎゅ"),
        ("ぎょ", "gyo", "ぎょ"),
        ("じゃ", "zya", "じゃ"),
        ("じゅ", "zyu", "じゅ"),
        ("じょ", "zyo", "じょ"),
        ("ぢゃ", "dya", "ぢゃ"),
        ("ぢゅ", "dyu", "ぢゅ"),
        ("ぢょ", "dyo", "ぢょ"),
        ("びゃ", "bya", "びゃ"),
        ("びゅ", "byu", "びゅ"),
        ("びょ", "byo", "びょ"),
        ("ぴゃ", "pya", "ぴゃ"),
        ("ぴゅ", "pyu", "ぴゅ"),
        ("ぴょ", "pyo", "ぴょ"),
        ("ぁ", "xa", "ぁ"),
        ("ぃ", "xi", "ぃ"),
        ("ぅ", "xu", "ぅ"),
        ("ぇ", "xe", "ぇ"),
        ("ぉ", "xo", "ぉ"),
        ("ゔ", "va", "ゔ"),
        ("ゔぃ", "vi", "ゔぃ"),
        ("ゔぇ", "ve", "ゔぇ"),
        ("ゔぉ", "vo", "ゔぉ")
        
    };
    // ふつうレベルのEnemy
    private List<(string qText, string aText, string mText)> _normalWordList = new List<(string, string, string)>{
        ("川","kawa","かわ"),
        ("山","yama","やま"),
        ("道","miti","みち"),
        ("里","sato","さと"),
        ("宿","yado","やど"),
        ("鳥","tori","とり"),
        ("蟹","kani","かに"),
        ("猫","neko","ねこ"),
        ("森","mori","もり"),
        ("風","kaze","かぜ"),
        ("酒","sake","さけ"),
        ("人","hito","ひと"),
        ("箱","hako","はこ"),
        ("お茶","otya","おちゃ"),
        ("君","kimi","きみ"),
        ("町","mati","まち"),
        ("谷","tani","たに"),
        ("空","sora","そら"),
        ("店","mise","みせ"),
        ("水","mizu","みず"),
        ("口","kuti","くち"),
        ("雲","kumo","くも"),
        ("船","hune","ふね"),
        ("母","haha","はは"),
        ("父","titi","ちち"),
        ("雪","yuki","ゆき"),
        ("旗","hata","はた"),
        ("羽","hane","はね"),
        ("豆","mame","まめ"),
        ("紙","kami","かみ"),
        ("草","kusa","くさ"),
        ("玉","tama","たま"),
        ("橋","hashi","はし"),
        ("田畑","tahata","たはた"),
        ("漢字","kannzi","かんじ"),
        ("辞書","zisyo","じしょ"),
        ("お菓子","okasi","おかし"),
        ("明日","asita","あした"),
        ("本","honn","ほん"),
        ("ずっと","zutto","ずっと"),
        ("昨日","kinou","きのう"),
        ("鞄","kabann","かばん"),
        ("西瓜","suika","すいか"),
        ("机","tukue","つくえ"),
        ("怖い","kowai","こわい"),
        ("香り","kaori","かおり"),
        ("丸い","marui","まるい"),
        ("日記","nikki","にっき"),
        ("美味しい","oisii","おいしい"),
        ("眠い","nemui","ねむい"),
        ("長い","nagai","ながい"),
        ("白い","siroi","しろい"),
        ("黒い","kuroi","くろい"),
        ("寒い","samui","さむい"),
        ("見える","mieru","みえる"),
        ("聞く","kiku","きく"),
        ("気候","kikou","きこう"),
        ("世界","sekai","せかい"),
        ("砂糖","satou","さとう"),
        ("眠る","nemuru","ねむる"),
        ("氷","koori","こおり"),
        ("油","abura","あぶら"),
        ("試合","siai","しあい"),
        ("可能","kanou","かのう"),
        ("進化","sinnka","しんか"),
        ("早い","hayai","はやい"),
        ("急ぐ","isogu","いそぐ"),
        ("ご飯","gohann","ごはん"),
        ("桜","sakura","さくら"),
        ("トマト","tomato","とまと"),
        ("学校","gakkou","がっこう"),
        ("家族","kazoku","かぞく"),
        ("鶴","turu","つる"),
        ("先生","sennsei","せんせい"),
        ("公園","kouenn","こうえん"),
        ("音楽","ongaku","おんがく"),
        ("手紙","tegami","てがみ"),
        ("雑草","zassou","ざっそう"),
        ("失敗","sippai","しっぱい"),
        ("人間","ninngen","にんげん"),
        ("炬燵","kotatu","こたつ"),
        ("雀","suzume","すずめ"),
        ("燕","tubame","つばめ"),
        ("翼","tubasa","つばさ"),
        ("サラダ","sarada","さらだ"),
        ("朝顔","asagao","あさがお"),
        ("紫陽花","azisai","あじさい"),
        ("季節","kisetu","きせつ"),
        ("再生","saisei","さいせい"),
        ("結婚","kekkon","けっこん"),
        ("暦","koyomi","こよみ"),
        ("布団","hutonn","ふとん"),
        ("旅行","ryokou","りょこう"),
        ("賛成","sannsei","さんせい"),
        ("反対","hanntai","はんたい"),
        ("空間","kuukann","くうかん"),
        ("案内","annnai","あんない"),
        ("安心","annsin","あんしん"),
        ("近所","kinnzyo","きんじょ"),
        ("景色","kesiki","けしき"),


    };
    // ふつうレベルのBoss
    private List<(string qText, string aText, string mText)> _normalBossWordList = new List<(string, string, string)>{
        ("建築","kenntiku","けんちく"),
        ("検診","kennsinn","けんしん"),
        ("簡単","kanntann","かんたん"),
        ("難民","nannminn","なんみん"),
        ("監禁","kannkinn","かんきん"),
        ("三角","sannkaku","さんかく"),
        ("満足","mannzoku","まんぞく"),
        ("残酷","zannkoku","ざんこく"),
        ("残高","zanndaka","ざんだか"),
        ("関心","kannsinn","かんしん"),
        ("判断","hanndann","はんだん"),
        ("看板","kannbann","かんばん"),
        ("反発","hannpatu","はんぱつ"),
        ("尊厳","sonngenn","そんげん"),
        ("人権","zinnkenn","じんけん"),
        ("洗濯","senntaku","せんたく"),
        ("専念","sennnenn","せんねん"),
        ("伝説","dennsetu","でんせつ"),
        ("転換","tennkann","てんかん"),
        ("犯人","hannninn","はんにん"),
        ("本人","honnninn","ほんにん"),
        ("翻訳","honnyaku","ほんやく"),
        ("婚約","konnyaku","こんやく"),
        ("混乱","konnrann","こんらん"),
        ("満月","manngetu","まんげつ"),
        ("輪郭","rinnkaku","りんかく"),
        ("鍵盤","kennbann","けんばん"),
        ("新刊","sinnkann","しんかん"),
        ("隠れる","kakureru","かくれる"),
        ("魚屋","sakanaya","さかなや"),
        ("口紅","kutibeni","くちべに"),
        ("雪国","yukiguni","ゆきぐに"),
        ("故郷","hurusato","ふるさと"),
        ("黄昏","tasogare","たそがれ"),
        ("紫","murasaki","むらさき"),
        ("食べ物","tabemono","たべもの"),
        ("木枯らし","kogarasi","こがらし"),
        ("鈴虫","suzumusi","すずむし"),
        ("飾り気","kazarike","かざりけ"),
        ("蠍座","sasoriza","さそりざ"),
        ("筍","takenoko","たけのこ"),
        ("空手家","karateka","からてか"),
        ("切り株","kirikabu","きりかぶ"),
        ("若者","wakamono","わかもの"),
        ("手袋","tebukuro","てぶくろ"),
        ("長靴","nagagutu","ながぐつ"),
        ("蒲公英","tannpopo","たんぽぽ"),
        ("時々","tokidoki","ときどき"),
        ("ありがとう","arigatou","ありがとう"),
        ("おめでとう","omedetou","おめでとう"),
        ("輝く","kagayaku","かがやく"),
        ("重なる","kasanaru","かさなる"),
        ("面白い","omosiroi","おもしろい"),
        ("美しい","utukusii","うつくしい"),
        ("花菱","hanabisi","はなびし"),
        ("春雨","harusame","はるさめ"),

        
    };

    private List<(string qText, string aText, string mText)> _hardWordList = new List<(string, string, string)>{
        ("学校","gakkou","がっこう"),
        ("小鳥","kotori","ことり"),
        ("卵","tamago","たまご"),
        ("鞄","kabann","かばん"),
        ("薬缶","yakann","やかん"),
        ("茸","kinoko","きのこ"),
        ("魚","sakana","さかな"),
        ("明後日","asatte","あさって"),
        ("教師","kyousi","きょうし"),
        ("修士","syuusi","しゅうし"),
        ("京都","kyouto","きょうと"),
        ("中古","tyuuko","ちゅうこ"),
        ("日光","nikkou","にっこう"),
        ("農林","nourinn","のうりん"),
        ("帝国","teikoku","ていこく"),
        ("米国","beikoku","べいこく"),
        ("天保","tenpou","てんぽう"),
        ("台風","taihuu","たいふう"),
        ("通行","tuukou","つうこう"),
        ("対談","taidann","たいだん"),
        ("大地","daiti","だいち"),
        ("代金","daikinn","だいきん"),
        ("最高","saikou","さいこう"),
        ("将棋","syougi","しょうぎ"),
        ("閉口","heikou","へいこう"),
        ("予算","yosann","よさん"),
        ("加算","kasann","かさん"),
        ("貸家","kasiya","かしや"),
        ("湖","mizuumi","みずうみ"),
        ("兄弟","kyoudai","きょうだい"),
        ("たい焼き","taiyaki","たいやき"),
        ("食事","syokuzi","しょくじ"),
        ("古池","huruike","ふるいけ"),
        ("明確","meikaku","めいかく"),
        ("努力","doryoku","どりょく"),
        ("仲介","tyuukai","ちゅうかい"),
        ("運賃","unntin","うんちん"),
        ("対面","taimenn","たいめん"),
        ("楽園","rakuenn","らくえん"),
        ("修行","syugyou","しゅぎょう"),
        ("漁業","gyogyou","ぎょぎょう"),
        ("描写","byousya","びょうしゃ"),
        ("東京","toukyou","とうきょう"),
        ("発音","hatuonn","はつおん"),
        ("発足","hossoku","ほっそく"),
        ("圧縮","assyuku","あっしゅく"),
        ("決心","kessinn","けっしん"),
        ("屈折","kussetu","くっせつ"),
        ("終点","syuutenn","しゅうてん"),
        ("活発","kappatu","かっぱつ"),
        ("失望","situbou","しつぼう"),
        ("喪失","sousitu","そうしつ"),
        ("車内","syanai","しゃない"),
        ("最高","saikou","さいこう"),
        ("最終","saisyuu","さいしゅう"),
        ("氷点","hyoutenn","ひょうてん"),
        ("提供","teikyou","ていきょう"),
        ("改札","kaisatu","かいさつ"),
        ("基準","kizyunn","きじゅん"),
        ("記述","kizyutu","きじゅつ"),
        ("前線","zennsenn","ぜんせん"),
        ("役所","yakusyo","やくしょ"),
        ("人参","ninnzinn","にんじん"),
        ("僕たち","bokutati","ぼくたち"),
        ("結局","kekkyoku","けっきょく"),
        ("文学","bunngaku","ぶんがく"),
        ("雷","kaminari","かみなり"),
        ("新聞","sinnbunn","しんぶん"),
        ("玄関","gennkann","げんかん"),
        ("家族愛","kazokuai","かぞくあい"),
        ("許可書","kyokasyo","きょかしょ"),
        ("来学期","raigakki","らいがっき"),
        ("味噌汁","misosiru","みそしる"),
        ("交通費","koutuuhi","こうつうひ"),
        ("身長","sinntyou","しんちょう"),
        ("季節風","kisetuhuu","きせつふう"),
        ("唇","kutibiru","くちびる"),
        ("眼鏡","megane","めがね"),
        ("水筒","suitou","すいとう"),
        ("近距離","kinnkyori","きんきょり"),
        ("文章","bunnsyou","ぶんしょう"),
        ("環境","kannkyou","かんきょう"),
        ("団栗","donnguri","どんぐり"),
        ("赤ちゃん","akatyann","あかちゃん"),
        ("きらきら","kirakira","きらきら"),
        ("近道","tikamiti","ちかみち"),
        ("土曜日","doyoubi","どようび"),
        ("晴れの日","harenohi","はれのひ"),
        ("はがき","hagaki","はがき"),
        ("目印","mezirusi","めじるし"),
        ("翌日","yokuzitu","よくじつ"),
        ("ぴかぴか","pikapika","ぴかぴか"),
        ("ばたばた","batabata","ばたばた"),
        ("ぎらぎら","giragira","ぎらぎら"),
        ("こそこそ","kosokoso","こそこそ"),
        ("しみじみ","simizimi","しみじみ"),
        ("はればれ","harebare","はればれ")
    
    };


    private List<(string qText, string aText, string mText)> _hardBossWordList = new List<(string, string, string)>{
        ("日本人","nihonnzinn","にほんじん"),
        ("誕生日","tannzyoubi","たんじょうび"),
        ("小学校","syougakkou","しょうがっこう"),
        ("中学校","tyuugakkou","ちゅうがっこう"),
        ("日本語","nihonngo","にほんご"),
        ("元気玉","gennkidama","げんきだま"),
        ("食事会","syokuzikai","しょくじかい"),
        ("おもちゃ箱","omotyabako","おもちゃばこ"),
        ("大阪城","oosakazyou","おおさかじょう"),
        ("かるた取り","karutatori","かるたとり"),
        ("忘れ物","wasuremono","わすれもの"),
        ("警察署","keisatusyo","けいさつしょ"),
        ("すずめ蜂","suzumebati","すずめばち"),
        ("流れ星","nagarebosi","ながれぼし"),
        ("月見そば","tukimisoba","つきみそば"),
        ("おしろい花","osiroibana","おしろいばな"),
        ("ゆでたまご","yudetamago","ゆでたまご"),
        ("実験室","zikkennsitu","じっけんしつ"),
        ("料理人","ryourininn","りょうりにん"),
        ("一休み","hitoyasumi","ひとやすみ"),
        ("春休み","haruyasumi","はるやすみ")
    };

    // 超むずかしいレベルのEnemy
    private List<(string qText, string aText, string mText)> _veryhardWordList = new List<(string, string, string)>{
        ("花束","hanataba","はなたば"),
        ("星空","hosizora","ほしぞら"),
        ("春風","harukaze","はるかぜ"),
        ("速読","sokudoku","そくどく"),
        ("焼鳥","yakitori","やきとり"),
        ("金槌","kanaduti","かなづち"),
        ("飴細工","amezaiku","あめざいく"),
        ("塵取り","tiritori","ちりとり"),
        ("青蜥蜴","aotokage","あおとかげ"),
        ("油揚げ","aburaage","あぶらあげ"),
        ("爪先","tumasaki","つまさき"),
        ("春服","haruhuku","はるふく"),
        ("夜桜","yozakura","よざくら"),
        ("大晦日","oomisoka","おおみそか"),
        ("落花生","rakkasei","らっかせい"),
        ("砂漠化","sabakuka","さばくか"),
        ("地平線","tiheisenn","ちへいせん"),
        ("血液","ketueki","けつえき"),
        ("聖歌隊","seikatai","せいかたい"),
        ("語彙力","goiryoku","ごいりょく"),
        ("句読点","kutouten","くとうてん"),
        ("文芸部","bunngeibu","ぶんげいぶ"),
        ("学級委員","gakkyuuiinn","がっきゅういいん"),
        ("遅刻魔","tikokuma","ちこくま"),
        ("白黒","sirokuro","しろくろ"),
        ("糸電話","itodennwa","いとでんわ"),
        ("落書き","rakugaki","らくがき"),
        ("早口","hayakuti","はやくち"),
        ("夜更かし","yohukasi","よふかし"),
        ("逆立ち","sakadati","さかだち"),
        ("木漏れ日","komorebi","こもれび"),
        ("車椅子","kurumaisu","くるまいす"),
        ("子守歌","komoriuta","こもりうた"),
        ("色鉛筆","iroennpitu","いろえんぴつ"),
        ("美術館","bizyutukan","びじゅつかん"),
        ("部活動","bukatudou","ぶかつどう"),
        ("算数帳","sansuutyou","さんすうちょう"),
        ("学期末","gakkimatu","がっきまつ"),
        ("夏野菜","natuyasai","なつやさい"),
        ("冬野菜","huyuyasai","ふゆやさい"),
        ("金銀銅","kinnginndou","きんぎんどう"),
        ("花筏","hanaikada","はないかだ"),
        ("区役所","kuyakusyo","くやくしょ"),
        ("食券機","syokkennki","しょっけんき"),
        ("競争馬","kyousouba","きょうそうば"),
        ("陸上部","rikuzyoubu","りくじょうぶ"),
        ("音楽会","onngakukai","おんがくかい"),
        ("新年会","sinnnennkai","しんねんかい"),
        ("球拾い","tamahiroi","たまひろい"),
        ("同窓会","dousoukai","どうそうかい"),
        ("上映中","zyoueityuu","じょうえいちゅう"),
        ("倫理観","rinnrikann","りんりかん"),
        ("署名欄","syomeirann","しょめいらん"),
        ("試験管","sikennkann","しけんかん"),
        ("洗面台","sennmenndai","せんめんだい"),
        ("洗濯機","senntakuki","せんたくき"),
        ("電気釜","dennkigama","でんきがま"),
        ("給湯器","kyuutouki","きゅうとうき"),
        ("調理台","tyouridai","ちょうりだい"),
        ("往復券","ouhukukenn","おうふくけん"),
        ("青春期","seisyunnki","せいしゅんき"),
        ("梅雨時","tuyudoki","つゆどき"),
        ("台風の眼","taihuunome","たいふうのめ"),
        ("感受性","kanzyusei","かんじゅせい"),
        ("数学科","suugakuka","すうがくか"),
        ("音読会","onndokukai","おんどくかい"),
        ("図工室","zukousitu","ずこうしつ"),
        ("天然水","tennnennsui","てんねんすい"),
        ("写真館","syasinnkann","しゃしんかん"),
        ("深呼吸","sinnkokyuu","しんこきゅう"),
        ("体操服","taisouhuku","たいそうふく"),
        ("読書会","dokusyokai","どくしょかい"),
        ("食洗機","syokusennki","しょくせんき"),
        ("検索欄","kennsakurann","けんさくらん"),
        ("東京駅","toukyoueki","とうきょうえき"),
        ("京急線","keikyuusenn","けいきゅうせん"),
        ("阪急線","hannkyuusenn","はんきゅうせん"),
        ("往来橋","ouraibasi","おうらいばし"),
        ("水族館","suizokukann","すいぞくかん"),
        ("金魚鉢","kinngyobati","きんぎょばち"),
        ("自習室","zisyuusitu","じしゅうしつ"),
        ("音楽室","ongakusitu","おんがくしつ"),
        ("図書室","tosyositu","としょしつ"),
        ("時限ベル","zigennberu","じげんべる"),
        ("招待状","syoutaizyou","しょうたいじょう"),
        ("回覧板","kairannbann","かいらんばん"),
        ("非常口","hizyouguti","ひじょうぐち"),
        ("日陰道","hikagemiti","ひかげみち"),
        ("川下り","kawakudari","かわくだり"),
        ("森林浴","sinnrinnyoku","しんりんよく"),
        ("月明かり","tukiakari","つきあかり"),
        ("迎賓館","geihinnkann","げいひんかん"),
        ("記念公園","kinennkouenn","きねんこうえん"),
        ("吹奏楽","suisougaku","すいそうがく"),
        ("金縛り","kanasibari","かなしばり"),
        ("大仏殿","daibutudenn","だいぶつでん"),
        ("神保町","zinnboutyou","じんぼうちょう"),
        ("抹茶アイス","mattyaaisu","まっちゃあいす"),
        ("日本庭園","nihonnteienn","にほんていえん"),
        ("紅葉狩り","momizigari","もみじがり"),
        ("雨天決行","utennkekkou","うてんけっこう"),
        ("桃源郷","tougennkyou","とうげんきょう"),
        ("音楽祭","onngakusai","おんがくさい")


    };
    // 超むずかしいレベルのBoss
    private List<(string qText, string aText, string mText)> _veryhardBossWordList = new List<(string, string, string)>{
        ("簡単考査","kanntannkousa","かんたんこうさ"),
        ("音楽の祭典","onngakunosaiten","おんがくのさいてん"),
        ("銀河鉄道","ginngatetudou","ぎんがてつどう"),
        ("世界巡航","sekaizyunnkou","せかいじゅんこう"),
        ("一石二鳥","issekinityou","いっせきにちょう"),
        ("画竜点睛","garyoutennsei","がりょうてんせい"),
        ("電子書籍","dennsisyoseki","でんししょせき"),
        ("過ぎ去りし日","sugisarisihi","すぎさりしひ"),
        ("福祉施設","hukusisisetu","ふくししせつ"),
        ("願望成就","gannbouzyouzyu","がんぼうじょうじゅ"),
        ("社会見学","syakaikenngaku","しゃかいけんがく"),
        ("世界征服","sekaiseihuku","せかいせいふく"),
        ("予知夢体験","yotimutaikenn","よちむたいけん"),
        ("遠隔医療","ennkakuiryou","えんかくいりょう"),
        ("未来都市論","miraitosironn","みらいとしろん"),
        ("素粒子理論","soryuusirironn","そりゅうしりろん"),
        ("強化ガラス","kyoukagarasu","きょうかがらす"),
        ("液晶画面","ekisyougamenn","えきしょうがめん"),
        ("往復はがき","ouhukuhagaki","おうふくはがき"),
        ("健康診断","kennkousindann","けんこうしんだん"),
        ("定期健診","teikikennsinn","ていきけんしん"),
        ("傷口悪化","kizugutiakka","きずぐちあっか"),
        ("救急箱","kyuukyuubako","きゅうきゅうばこ"),
        ("対義語辞典","taigigozitenn","たいぎごじてん"),
        ("再生エネルギー","saiseienerugi-","さいせいえねるぎー"),
        ("財務諸表","zaimusyohyou","ざいむしょひょう"),
        ("鑑識課員","kannsikikain","かんしきかいん"),
        ("国連本部","kokurennhonnbu","こくれんほんぶ"),
        ("ロシア連邦","rosiarennpou","ろしあれんぽう"),
        ("宇宙飛行士","utyuuhikousi","うちゅうひこうし")
    };
    

    // スペシャルレベルのEnemy
    private List<(string qText, string aText, string mText)> _specialWordList = new List<(string, string, string)>{
        ("もし", "if", "いふ"),
        ("~の間繰り返す", "while", "ほわいる"),
        ("~じゃなくて~なら", "elif", "えりふ"),
        ("そうでなければ", "else", "えるす"),
        ("~回繰り返す", "for", "ふぉー"),
        ("じゃない", "not", "のっと"),
        ("かつ", "and", "あんど"),
        ("または", "or", "おあ"),
        ("整数", "int", "いんと"),
        ("文字列", "str", "すとりんぐ"),
        ("繰り返しをやめる", "break", "ぶれーく"),
        ("カラーセンサー", "colorsensor", "からーせんさー"),
        ("フォースセンサー", "forcesensor", "ふぉーすせんさー"),
        ("距離センサー", "distancesensor", "でぃすたんすせんさー"),
        ("ハブ", "hub", "はぶ"),
        ("光", "light", "らいと"),
        ("スピーカー", "speaker", "すぴーかー"),
        ("1つのモーター", "motor", "もーたー"),
        ("2つのモーター", "motorpair", "もーたーぺあ"),
        ("正しい", "true", "とぅるー"),
        ("間違い", "false", "ふぉるす")
    };
    // スペシャルレベルのBoss
    private List<(string qText, string aText, string mText)> _specialBossWordList = new List<(string, string, string)>{
        ("もし", "if", "いふ"),
        ("~の間繰り返す", "while", "ほわいる"),
        ("~じゃなくて~なら", "elif", "えりふ"),
        ("そうでなければ", "else", "えるす"),
        ("~回繰り返す", "for", "ふぉー"),
        ("じゃない", "not", "のっと"),
        ("かつ", "and", "あんど"),
        ("または", "or", "おあ"),
        ("整数", "int", "いんと"),
        ("文字列", "str", "すとりんぐ"),
        ("繰り返しをやめる", "break", "ぶれーく"),
        ("カラーセンサー", "colorsensor", "からーせんさー"),
        ("フォースセンサー", "forcesensor", "ふぉーすせんさー"),
        ("距離センサー", "distancesensor", "でぃすたんすせんさー"),
        ("ハブ", "hub", "はぶ"),
        ("光", "light", "らいと"),
        ("スピーカー", "speaker", "すぴーかー"),
        ("1つのモーター", "motor", "もーたー"),
        ("2つのモーター", "motorpair", "もーたーぺあ"),
        ("正しい", "true", "とぅるー"),
        ("間違い", "false", "ふぉるす")
    };


    // EnemyGeneratorで呼び出し、ランダムに問題を渡す
    public (string, string, string) GetRandomWord(int level){
        if(level == 1){
            int index = Random.Range(0, _easyWordList.Count);
            return _easyWordList[index];
        }
        else if(level == 2){
            int index = Random.Range(0, _normalWordList.Count);
            return _normalWordList[index];
        }
        else if(level == 3){
            int index = Random.Range(0, _hardWordList.Count);
            return _hardWordList[index];
        }
        else if(level == 4){
            int index = Random.Range(0, _veryhardWordList.Count);
            return _veryhardWordList[index];
        }
        else if(level == 5){
            int index = Random.Range(0, _specialWordList.Count);
            return _specialWordList[index];
        }
        else{
            return ("", "", "");
        }
        
    }

    // EnemyGeneratorで呼び出し、ランダムにボスの問題を渡す
    public (string, string, string) GetBossRandomWord(int level){
        if(level == 1){
            int index = Random.Range(0, _easyBossWordList.Count);
            return _easyBossWordList[index];
        }
        else if(level == 2){
            int index = Random.Range(0, _normalBossWordList.Count);
            return _normalBossWordList[index];
        }
        else if(level == 3){
            int index = Random.Range(0, _hardBossWordList.Count);
            return _hardBossWordList[index];
        }
        else if(level == 4){
            int index = Random.Range(0, _veryhardBossWordList.Count);
            return _veryhardBossWordList[index];
        }
        else if(level == 5){
            int index = Random.Range(0, _specialBossWordList.Count);
            return _specialBossWordList[index];
        }
        else{
            return ("", "", "");
        }
        
    }
    public (string, string, string) GetSpecialRandomWord(){
        int index = Random.Range(0, _specialWordList.Count);
        return _specialWordList[index];
    }
    public (string, string, string) GetSpecialBossRandomWord(){
        int index = Random.Range(0, _specialBossWordList.Count);
        return _specialBossWordList[index];
    }
}

