using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;
using TMPro;
using UnityEngine.UIElements;

public class AlgorithmScript : MonoBehaviour
{
    [System.Serializable]
    public struct QuoteData
    {
        public string quote;
        public string imageLocation;
    }
    public GameObject algorithmWindow;
    public Canvas gameCanvas;
    public Transform feedPanel;
    public int numberOfWindows = 15;
    private float catapultSpeed = 750f;
    public float scrollCooldown = 0.5f;
    private float lastScrollTime = -1f;
    private bool currentlyMoving = false;
    public float centerThreshold = 10f;

    private List<GameObject> boxes = new List<GameObject>();
    private List<string> algorithmCategories = new List<string>();
    private Dictionary<string, List<QuoteData>> algorithmCategoriesData;
    private Dictionary<string, Sprite> imageDictionary;
    private AlgorithmScore algorithmScore;

    void Start()
    {
        LoadImages();
        PrepareAlgorithmCategoryList();
        PrepareDataDictionary();
        StartCoroutine(SpawnWindows());
    }


    private void FixedUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Time.time > lastScrollTime + scrollCooldown)
        {
            lastScrollTime = Time.time;
            SimulateClick();
        }
    }

    void LoadImages()
    {
        imageDictionary = new Dictionary<string, Sprite>();

        Sprite[] sprites = Resources.LoadAll<Sprite>("PostPictures");
        foreach (Sprite sprite in sprites)
        {
            imageDictionary[sprite.name] = sprite;
        }
    }

    void PrepareAlgorithmCategoryList()
    {
        algorithmCategories.Add("stress"); //former blue + esteem
        algorithmCategories.Add("anger");  //former red + anixety
        algorithmCategories.Add("grind");  //former yellow

        for (int i = 0; i < 4; i++)  // 4 sets of 3 more to get to 15 in total
        {
            algorithmCategories.Add("grind");
            algorithmCategories.Add("anger");
            algorithmCategories.Add("stress");
        }

        for (int i = 3; i < algorithmCategories.Count; i++)
        {
            string temp = algorithmCategories[i];
            int randomIndex = Random.Range(i, algorithmCategories.Count);
            algorithmCategories[i] = algorithmCategories[randomIndex];
            algorithmCategories[randomIndex] = temp;
        }
    }

    void PrepareDataDictionary()
    {
        algorithmCategoriesData = new Dictionary<string, List<QuoteData>>()
        {
            { "stress", new List<QuoteData> {
                new QuoteData { quote = "I know I should take a break, but I can’t seem to relax. My mind is constantly jumping from one thing to the next. Does anyone else feel like they can never fully switch off?", imageLocation = "AI_leaksPrivateData" },
                new QuoteData { quote = "Some days I feel like I’m doing okay, and other days it’s just… a lot. Like, I can’t breathe right. Anyone else trying to keep it all together but struggling to do so?", imageLocation = "AsteroidEarth" },
                new QuoteData { quote = "You ever have those moments where you feel like everything's moving so fast and you're just... trying to keep up? It’s like everyone else is already where they need to be", imageLocation = "ClimateDisasterSiberia" },
                new QuoteData { quote = "The more I think about it, the more I realize that maybe I don't actually know how to relax. I always feel like there’s something I should be doing", imageLocation = "ConferenceWoman" },
                new QuoteData { quote = "I love how everyone seems so sure of themselves online. It's weird, right? How they just... handle everything. I sometimes feel like I’m always one step behind", imageLocation = "CoralReef" }
            }},
            { "grind", new List<QuoteData> {
                new QuoteData { quote = "I saw a tweet saying, 'You don’t get weekends off if you want to win.' Can’t let up if you want to succeed, right?", imageLocation = "CoupleAtFancyRestaurant" },
                new QuoteData { quote = "You know, it's not about luck or talent. It’s about working nonstop. I’ve learned that sleep is overrated", imageLocation = "FratParty" },
                new QuoteData { quote = "Woke up at 5 AM again today. People say that's when the real hustlers are working. I can already feel the difference. This is the grind", imageLocation = "GroupHikingBackTurned" },
                new QuoteData { quote = "Saw some people complaining about how hard their week was. Honestly, though, if you really want to achieve something big, you’ve got to push through. There’s no room for weakness", imageLocation = "GroupHikingFront" },
                new QuoteData { quote = "Another early morning, another grind. But you know, the hustle never stops. You can’t expect anything if you don’t push yourself to the absolute limit", imageLocation = "ManMirrorGymSelfie" }
            }},
            { "anger", new List<QuoteData> {
                new QuoteData { quote = "Woke up feeling great after a week of hard work at the gym. It’s amazing what consistency can do for you. Who else is on a fitness journey?", imageLocation = "NewjobWoman" },
                new QuoteData { quote = "Found a new skincare routine that’s totally transformed my skin. Feels so good to be able to go out without makeup now! Anyone else tried something that totally changed the game?", imageLocation = "PodcastChad" },
                new QuoteData { quote = "Just finished my workout. The progress is slow, but at least it’s progress, right? One step closer", imageLocation = "WomanGymSelfie" },
                new QuoteData { quote = "Tried a new recipe today. They say if you want to get serious, you need to treat food like fuel. But it’s hard not to compare when I see what others are eating", imageLocation = "SportsWatchFlex" },
                new QuoteData { quote = "I’ve been really into taking care of myself lately. Everyone says self-care is important, but I wonder how long it takes before you start really seeing the results", imageLocation = "StockTradeGrinding" }
            }}
        };
    }

    IEnumerator SpawnWindows()
    {
        RectTransform canvasRect = gameCanvas.GetComponent<RectTransform>();
        float canvasHeight = canvasRect.rect.height; // The height of the canvas area
        float pileOffset = -canvasHeight - 100; // Initial pile offset below the canvas

        for (int i = 0; i < numberOfWindows; i++)
        {
            GameObject gameObject = Instantiate(algorithmWindow, feedPanel);
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

            if (i == 0)
            {
                rectTransform.anchoredPosition = Vector2.zero; 
            }
            else if (i == 1)
            {
                rectTransform.anchoredPosition = new Vector2(0, -canvasHeight); // Just below the canvas
            }
            else
            {
                rectTransform.anchoredPosition = new Vector2(0, pileOffset); // Stacked in a pile
                pileOffset -= 50; // Adjust for a stacked effect
            }

            string category = algorithmCategories[i % algorithmCategories.Count];
            ConfigureBox(gameObject, category);

            Button button = gameObject.AddComponent<Button>();
            int currentIndex = i;
            button.onClick.AddListener(() => CatapultBox(currentIndex));

            boxes.Add(gameObject);
            yield return null;
        }
    }

    void ConfigureBox(GameObject box, string category)
    {
        TextMeshProUGUI boxText = box.transform.Find("DescriptionText")?.GetComponent<TextMeshProUGUI>();
        Image quoteImage = box.transform.Find("QuoteImage").GetComponent<Image>();

        if (algorithmCategoriesData.ContainsKey(category))
        {
            List<QuoteData> possibleData = algorithmCategoriesData[category];
            QuoteData selectedData = possibleData[Random.Range(0, possibleData.Count)];

            boxText.text = selectedData.quote;

            if (imageDictionary.TryGetValue(selectedData.imageLocation, out Sprite foundImage))
                quoteImage.sprite = foundImage;
            else
                Debug.LogWarning($"Image with key {selectedData.imageLocation} not found in image dictionary.");
        }

        box.name = category;
    }

    void CatapultBox(int index)
    {
        if (index >= boxes.Count || currentlyMoving) return;

        GameObject currentBox = boxes[index];
        GameObject nextBox = (index + 1 < boxes.Count) ? boxes[index + 1] : null;
        GameObject pileBox = (index + 2 < boxes.Count) ? boxes[index + 2] : null;

        StartCoroutine(CatapultAndSlide(currentBox, nextBox, pileBox));
    }

    IEnumerator CatapultAndSlide(GameObject currentBox, GameObject nextBox, GameObject pileBox)
    {
        currentlyMoving = true;  

        RectTransform currentRect = currentBox.GetComponent<RectTransform>();
        RectTransform nextRect = nextBox?.GetComponent<RectTransform>();
        RectTransform pileRect = pileBox?.GetComponent<RectTransform>();

        RectTransform canvasRect = gameCanvas.GetComponent<RectTransform>();
        float canvasHeight = canvasRect.rect.height;

        float targetYOut = canvasHeight / 2 + 500; 
        Vector2 nextTargetPosition = Vector2.zero; 
        Vector2 pileTargetPosition = new Vector2(0, -canvasHeight);

        float transitionSpeed = catapultSpeed;

        while (true)
        {
            bool currentBoxDone = true, nextBoxDone = true, pileBoxDone = true;

            if (currentRect.anchoredPosition.y < targetYOut)
            {
                currentRect.anchoredPosition += Vector2.up * transitionSpeed * Time.deltaTime;
                currentBoxDone = false;
            }

            if (nextRect != null && Vector2.Distance(nextRect.anchoredPosition, nextTargetPosition) > 1f)
            {
                nextRect.anchoredPosition = Vector2.MoveTowards(nextRect.anchoredPosition, nextTargetPosition, transitionSpeed * Time.deltaTime);
                nextBoxDone = false;
            }

            if (pileRect != null && Vector2.Distance(pileRect.anchoredPosition, pileTargetPosition) > 1f)
            {
                pileRect.anchoredPosition = Vector2.MoveTowards(pileRect.anchoredPosition, pileTargetPosition, transitionSpeed * Time.deltaTime);
                pileBoxDone = false;
            }

            if (currentBoxDone && nextBoxDone && pileBoxDone) break;

            yield return null;
        }

        // Ensure positions are correct
        if (currentRect.anchoredPosition.y < targetYOut)
            currentRect.anchoredPosition = new Vector2(currentRect.anchoredPosition.x, targetYOut);
        if (nextRect != null)
            nextRect.anchoredPosition = nextTargetPosition;
        if (pileRect != null)
            pileRect.anchoredPosition = pileTargetPosition;

        string category = currentBox.name;
        Destroy(currentBox);

        GameObject newBox = Instantiate(algorithmWindow, feedPanel);
        RectTransform newBoxRect = newBox.GetComponent<RectTransform>();
        newBoxRect.anchoredPosition = new Vector2(0, -canvasHeight - 100);

        ConfigureBox(newBox, category);
        Button button = newBox.AddComponent<Button>();
        button.onClick.AddListener(() =>
        {
            int newBoxIndex = boxes.IndexOf(newBox);
            if (newBoxIndex >= 0)
                CatapultBox(newBoxIndex);
        });

        boxes.Add(newBox);
        currentlyMoving = false;
    }

    void SimulateClick()
    {
        foreach (GameObject box in boxes)
        {
            if (box == null || !box.activeSelf) continue;

            AlgorithmScore scoreHolder = box.GetComponent<AlgorithmScore>();
            if (scoreHolder != null && IsBoxCentered(scoreHolder))
            {
                scoreHolder.OnBoxClicked();

                int index = boxes.IndexOf(box);
                if (index >= 0)
                    CatapultBox(index);
                break;
            }
        }
    }

    private bool IsBoxCentered(AlgorithmScore scoreHolder)
    {
        RectTransform rectTransform = scoreHolder.GetComponent<RectTransform>();
        if (rectTransform == null) return false;

        // Check if the box is within the center threshold
        Vector2 anchoredPosition = rectTransform.anchoredPosition;
        return Mathf.Abs(anchoredPosition.x) <= centerThreshold &&
               Mathf.Abs(anchoredPosition.y) <= centerThreshold;
    }

    public void ShowFeed()
    {
        DialogueState.GetInstance().currentDialogue = "feed";
    }
}