using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class TwichUser : MonoBehaviour
{



    public int abilityNumber;



    List<string> twichName = new List<string>() {"게임잘해욧", "맥주","냉수먹고싶다", "어머", "경찰서","엄복동할머니",
        "야스오펜타장인", "양말건물주", "adfwewersdfsd",  "트수10년차", "하꼬방장인", "할아버지", "틀", "박물관템플릿2개훔친수연","섹시가이봉산탈춤","코가섹시한나",
    "sfskfskfskf", "비공개", "물병세우기장인", "육수", "ask맨", "배먹어배", "500원꽁트", "누군지알지?", "자동저장", "소스트림","경기게임마이스터고","센세","밖에서 10초기다린사람",
    "가고싶은여행","말박이","포니포니","헤으","ctrlAwls","NameSak","Assaion","라면먹고싶다","나만고양이없어","안경빨뽀로로", "유니티잘하고싶어ㅠㅠ","한번만뽑아주세요","낭낭하게",
    "게임마이스터고재학중","핡짝","발표하고싶은 사람","조원과제극혐","레벨당이승훈","공산단","3번타자","내가누구야>","언리얼로갈아탐","냠냠","난귀여워","포토샵장인","2312912321",
    "개꿀스 맛스", "남캠경찰관","벼농사","레벨올림","조원쓰 조원쓰","기획으로5억","뿔만지고싶다.","레이저","akjsdfhsdklfsdf","외붕이","흑우","트기장여포","미_어캣","라가불린",
     "동글동글도넛","김호모사피엔스","유니콘","비버이빨틀니","금이빨로씹을게","케인","ponyTail", "Rainbows", "1231dsfs", "0505sim" , "revolution","은빛1단지 아파트",
    "PepciCoCa", "MintChoko482482", "121", "KimChiman"}; //1

    List<string> Chatingv = new List<string>() { "무슨 게임하나요?", "냉수일지도", "ㅋㅋㅋㅋㅋㅋ", "00랑 합방어떰?",
        "도배도배도배도배도배도배도배도배도배도배도배", "밴처리된 메시지입니다","딴 게임하면 안됨?","라라ㅏㄹ", "ㄴㄴ", "ㄱㄱ","ㅇㅇ","?","?","?","아코건맞지;;", "논란일자코담",
    "오늘도 그게임하실?","아니","아","심심하다","ㅋㅋ","ㅋㅋㅋㅋㅋㅋㅋㅋㅋ","그건맞지","ㅁㅈㅁㅈ","라면먹방","라리라리루", "벌칙으로 이거어떰?","아이고난 아이고난!", "리액션달달~",
        "수연이라는 사람인데 키설정을 잘못했데", "아주그냥 뭉탱이로 있다가 유리게슝 아이그냥", "수연연님 시청자합방해요", "배먹어배","흐헤헤", "유튜브그지빵구쟁이들 안냥안냥~",
     "팔로우해놔야지~", "유튜브로 왔습니다~", "왕 재미겠당","애교한번만...", "무빙","오늘뭐하셨나요?", "밥뭐먹음?", "일상이야기좀 풀어줘요", "팩트밴","12시라 못보겠네요ㅠㅠ", "왜늦었어 왜늦었어",
    "오옹 나이스~"};
    List<string> viewers = new List<string>() { "뉴비 어서어서오고~ 뉴비 어서오고~", "규칙 안적나요?", "후원링크좀 적어!!!", "매니저신청이요~" ,"아 그거 그렇게 하는거 아닌데",
    "합방안함?", "풋풋하구만~","크면 이제 날잊겠지...","과몰입밴","채팅창이 좀 더럽네요","롤어떰ㄱㄱ","시참하자 시참하자","벌써 이렇게 컷네","라면라면","오늘도 그거하나요?", 
    "그래서 이분 누구임? ", "좀 재밌으신 분이네", "구독해놔야겠다 ", "다음에는 언제방송하나요?", "방송시작시간이 어케됨?", "다음에도 이게임할거임?", "방송설정하는 법 알려드립니다 귓말 주세요"
    ,"처음인거 같은데 방송진행 잘하시네 좀있으면 크실듯", "팔로우팔로우", "제 채팅좀 봐주세요"};
    List<string> voice = new List<string>() { "목소리무엇? 목소리 무엇?", "캬 목소리 달달하고","ASMR좀","목소리원툴스트리머","왜갑자기 목소리좋아짐?","성우하실생각?",
    "목관리어케하나요ㅠㅠ","목소리가 마치 오페라를 연상시키네요", "어디서 트레이닝받음?"," 안녕하세요 애니회사 경기게임입니다. 다름이 아니라 성우섭외를 위해 찾아왔습니다 이메일확인가능할까요?"
    ,"나지금 라디오로 틀고있음ㅎㅎ", "잠온다 아~","동화책 읽어주세요! 동화책 읽어주세요!", "목소리듣고 구독했습니다", "와 목소리쩐다", "노래해요 노래해요","누구노래방송중인데 뜨는거 어떰?", 
    "라디오방송해줘 라디오방송해줘", "귀가 녹네요"};
    List<string> humor = new List<string>() { "zzzzzzzzz", "아 재미지넼", "잡담왜캐잘하심","토크!토크!","저스트채팅합시닥ㄱ","어디서개그맨준비함?","나 이분 웃음소리호탕해서좋음",
    "오리가 얼면 언덕엌ㅋ", "아재요..", "ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ", " 거기서 그드립을ㅋㅋ", "이분좀 웃긴듯?", "저도 당황했음ㅋㅋ 진짜 황당하고 말이안나오더라",
    "잡담말고 게임안하심?", "극","락","극","락" ,"냐냐냐", "재밌으니 더성장하실듯", "이야기 잘풀어내네", "이야기 더해줘 이야기 더해줘", "오늘은 게임말고 저챗만 합시다.",
    "오예~ 저챗이다!", "엄마랑 함께 밥먹고있는데 님개그때문에 웃다가 밥상뒤엎으셨잖아!!!" , "물먹다가 뿜음", "저챗하실땐 음식안먹어야겠다.", "너무재밌는wwwwwww", "웃길뻔한wwwwwww"};
    List<string> Game = new List<string>() {"게임겁나잘하네ㄷㄷ","게임왜케잘하심?","게임원툴스트리머","대회나가보시는거 ㄷ어떠심?","ㄷㄷㄷㄷㄷㄷ","저보단 못하시네요","그거 그렇게 하는 거 아닌데 ㅋ",
    "프로도 쌉바를듯ㄷ","그건아님","기둥 뒤에 공간 있어요","난이더 하드로인데 겁나잘하시네","클리어확률 0.1%였던걸로 기억하는 데 그걸 5판만에?","너무잘하는거아닌가>?","난또목소리원툴인줄알았지;;",
    "KDA 3/0/2ㄷㄷ","게임으로 세게재패설ㄷㄷ", "프로나보다 못한단선언ㄷㄷ", "게임잘할려면 어캐하나요?","이거헤줘 이거해줘", "게임나보다 잘하네...3달이나 했는데...",
        "님플레이덕분에 제암이 다나았습니다.", "게임으로 병치료 ㄷㄷ", "게임은 약이다."};


    [SerializeField]
    private Transform Content;
    [SerializeField]
    private TextMeshProUGUI chating = null;
    [SerializeField]
    private TextMeshProUGUI chatingContent = null;

    int chatingSpeed = 1; //채팅 올라오는 속도
    int NicknameColor = 0; //유저 닉네임 색깔

    float defaultTime = 1f;
    float spawnTime = 0;
    bool bCommon;
    bool bVoice;
    bool bHumor;
    bool bGame;
    public void RandomColor()
    {
        Color color_title = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
        //string color_title_code = ColorUtility.ToHtmlStringRGBA(color_title);
        chating.color = color_title;
    }

    public void Show()
    {
        transform.SetParent(Content.transform);
        gameObject.SetActive(true);

    }



    public void UpdateShow()
    {

        if (GameManager.Instance.CurrentUser.humans < 0)
            return;

        int randomUser = Random.Range(0, twichName.Count);
        chating.text = (twichName[randomUser] + " : ");
        twichName.RemoveAt(randomUser);


        int randomChatingNumber = Random.Range(0, 5); // 0 , 1 , 2, 3

        if (randomChatingNumber == 1)
        {
            bCommon = RandomChance.GetThisChanceResult(50);
            if (!bCommon)
                randomChatingNumber = Random.Range(0, 4);
            int randomCommonChating = Random.Range(0, Chatingv.Count); //일반채팅
            chatingContent.text = (Chatingv[randomCommonChating]);
            Chatingv.RemoveAt(randomCommonChating);
     
            Debug.Log("Chatingv");

        }
        else if (randomChatingNumber == 2)
        {
            bool bVoice = RandomChance.GetThisChanceResult(GameManager.Instance.CurrentUser.Voicepercentage);
            if (!bVoice)
                randomChatingNumber = Random.Range(0, 4);
            int randomVoiceChating = Random.Range(0, voice.Count); //목소리채팅
            chatingContent.text = (voice[randomVoiceChating]);

            Debug.Log("voice");

        }
        else if (randomChatingNumber == 3)
        {
            bool bHumor = RandomChance.GetThisChanceResult(GameManager.Instance.CurrentUser.Humorpercentage);
            if (!bHumor)
                randomChatingNumber = Random.Range(0, 4);
            int randomHumorChating = Random.Range(0, humor.Count); //유머채팅
            chatingContent.text = (humor[randomHumorChating]);

            humor.RemoveAt(randomHumorChating);

            Debug.Log("humor");

        }
        else if (randomChatingNumber == 4)
        {

            bool bGame = RandomChance.GetThisChanceResult(GameManager.Instance.CurrentUser.Gamepercentage);
            if (!bGame)
                randomChatingNumber = Random.Range(0, 4);
            int randomGameChating = Random.Range(0, Game.Count); //게임채팅
            chatingContent.text = (Game[randomGameChating]);
            Game.RemoveAt(randomGameChating);
    
            Debug.Log("Game");
            
         }
        else if(randomChatingNumber == 5 && GameManager.Instance.CurrentUser.humans < 1000)
        {
            int randomNewbiChating = Random.Range(0, viewers.Count);
            chatingContent.text = (viewers[randomNewbiChating]);
            viewers.RemoveAt(randomNewbiChating);
        }

        if(!bCommon && !bVoice && !bHumor && !bGame)
        {
            int randomCommonChating = Random.Range(0, Chatingv.Count); //일반채팅
            chatingContent.text = (Chatingv[randomCommonChating]);
            Chatingv.RemoveAt(randomCommonChating);
        }
    }




}


  



