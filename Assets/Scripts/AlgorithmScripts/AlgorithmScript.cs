using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;
using TMPro;
using UnityEngine.UIElements;
using System.Linq;

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
    public AlgorithmHolder algorithmHolder;

    private List<GameObject> boxes = new List<GameObject>();
    private List<string> algorithmCategories = new List<string>();
    private Dictionary<string, List<QuoteData>> algorithmCategoriesData;
    private Dictionary<string, Sprite> imageDictionary;
    private bool isDynamicSpawning = false;

    void Start()
    {
        LoadImages();
        PrepareAlgorithmCategoryList();
        PrepareDataDictionary(); 
        CheckwhichShouldRun();
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
        algorithmCategories.Add("esteem"); //former blue + esteem
        algorithmCategories.Add("anixety");  //former red + anixety
        algorithmCategories.Add("grind");  //former yellow

        for (int i = 0; i < 4; i++)  // 4 sets of 3 more to get to 15 in total
        {
            algorithmCategories.Add("grind");
            algorithmCategories.Add("anixety");
            algorithmCategories.Add("esteem");
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
            { "esteem", new List<QuoteData> {
                new QuoteData { quote = "Can’t believe how far our hard work together has gotten us. I cannot wait to build a family with you in our dream house. Hopefully we grow old here and I will wake up to you getting more beautiful each day. I love you so much baby", imageLocation = "YoungCoupleNewHouse" },
                new QuoteData { quote = "If there is something to be thankful for in this life, it’s having friends that want to go on adventure together! These past 11 days with all of you have been amazing! Thank god we are all in decent shape tho, but now my knees need a rest haha", imageLocation = "GroupHikingFront" },
                new QuoteData { quote = "An hour and 48 kilometers later, and you got yourself a refreshed man hungry for some chicken breast, brown rice and spinach. Discipline is key.", imageLocation = "SportsWatchFlex" },
                new QuoteData { quote = "At Camber de Cheau restaurant having a lovely meal with the woman of my dreams. We always make sure to have date nights at least three times a week, and this time Marie got to choose. The tiramisu was almost as lovely as you, my love.", imageLocation = "CoupleAtFancyRestaurant" },
                new QuoteData { quote = "I love having these people around me. Always there for me and always ready to party some. BEST PARTY EVER, ADAM", imageLocation = "FratParty" }
            }},
            { "anixety", new List<QuoteData> {
                new QuoteData { quote = "A cutting-edge AI system went rogue in a high-profile tech company, exposing confidential data of individuals and governments. Experts warn this could be the start of a new era of digital insecurity.", imageLocation = "AI_leaksPrivateData" },
                new QuoteData { quote = "NASA confirmed that an undetected asteroid fragment narrowly missed Earth, passing within 200 miles of the surface. Astronomers warn that next time, humanity may not be so lucky", imageLocation = "AsteroidEarth" },
                new QuoteData { quote = "Scientists express alarm as record-breaking temperatures in the Arctic lead to a dramatic release of methane, a potent greenhouse gas. Environmentalists say this may trigger irreversible climate tipping points.", imageLocation = "ClimateDisasterSiberia" },
                //new QuoteData { quote = "A chemical plant explosion in central Europe has released a deadly cloud of toxic gas, forcing the evacuation of over 3 million residents. Emergency services struggle to contain the crisis as fatalities continue to climb.", imageLocation = "ConferenceWoman" },
                new QuoteData { quote = "Marine biologists report a catastrophic decline in coral reef systems worldwide, warning that the ecosystem collapse could lead to mass extinctions of marine life within the next 20 years.", imageLocation = "CoralReef" }
            }},
            { "grind", new List<QuoteData> {
                new QuoteData { quote = "Balance is an excuse made by people too weak and too comfortable not being successful. Just got my 5am workout in, followed by an hour of stock-trading that earned me enough to buy a new company car. Want to learn how to live your life more independently and become who you were meant to be?\nGo to my page and follow my stock-trading course that will earn YOU the right to become the successful individual you know you can be.", imageLocation = "ManMirrorGymSelfie" },
                new QuoteData { quote = "Had a great talk on the PumpedUp podcast regarding the surge in weak mentality and motivation among young people, and especially young men. Lack of confidence and no discerness against today’s women contribute to the creation of weak men not able to lead us steadily into a productive future.\nThe masculine perspective is that life is war. It’s a war for the female you want. It’s a war for the car you want. It’s a war for the money you want. It’s a war for status. Masculine life is war, and young men today are not prepared for it", imageLocation = "PodcastChad" },
                new QuoteData { quote = "Speaking at the Smart Housing conference today regarding my award-winning design of a smart house capable of being integrated in rural areas\nOften I find myself amazed at the lack of motivation and problem-solving skills present in today’s women in society. \nToday’s women should empower themselves and let their light shine on their own path, enlightening their potential and becoming the successful woman they were meant to be. \nOnly give energy to things that will lift you up, and not others.", imageLocation = "ConferenceWoman" },
                new QuoteData { quote = "Couldn’t be happier for my new job at Electibon (thanks for the hat haha)! When choosing jobs it was important for me to know if it would let me grow to be the productive self I was meant to be. Wanting to come in for work earlier and also wanting to leave later than everyone else is something I have always done in search of becoming the person I need to be in my career\nPushing yourself forwards is required if you expect colleagues and partners to take you seriously. When your hard-working colleague receives the promotion instead of you, ask yourself if you have worked AS hard.", imageLocation = "NewjobWoman" },
                new QuoteData { quote = "Your ability to put away work when home after work, is directly correlated with the chance of failing in life. Don’t let nobody drag you down to their level of mediocrity, be grand. You cannot disappoint yourself any longer\nWant an easy step-by-step guide to get yourself where you want to be? Take a look in my bio", imageLocation = "StockTradeGrinding" }
            }}
        };
    }

    private void CheckwhichShouldRun()
    {
        if (isDynamicSpawning == false)
        {
            StartCoroutine(SpawnWindows());
        }
        else if (isDynamicSpawning == true)
        {
            StartCoroutine(SpawnDynamically());
        }
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

IEnumerator SpawnDynamically()
{
    if (algorithmHolder == null)
    {
        Debug.LogError("AlgorithmHolder reference is missing!");
        yield break;
    }

    RectTransform canvasRect = gameCanvas.GetComponent<RectTransform>();
    float canvasHeight = canvasRect.rect.height;
    float pileOffset = -canvasHeight - 100; // Start below the canvas

    // Retrieve scores and find the highest and lowest categories
    Dictionary<string, float> scores = algorithmHolder.FinalScore();
    var sortedScores = scores.OrderByDescending(kv => kv.Value).ToList();
    string highestCategory = sortedScores[0].Key;
    string lowestCategory = sortedScores[sortedScores.Count - 1].Key;

    int baseSpawnsPerCategory = numberOfWindows / scores.Count;

    Dictionary<string, int> spawnCounts = scores.ToDictionary(kv => kv.Key, kv => baseSpawnsPerCategory);
    spawnCounts[highestCategory] += 1; // Add +1 for the highest category
    if (spawnCounts[lowestCategory] > 0)
        spawnCounts[lowestCategory] -= 1; // Subtract -1 for the lowest category

    List<string> spawnList = new List<string>();
    foreach (var kv in spawnCounts)
    {
        spawnList.AddRange(Enumerable.Repeat(kv.Key, kv.Value));
    }

    spawnList = spawnList.OrderBy(x => Random.value).Take(numberOfWindows).ToList();

    for (int i = 0; i < spawnList.Count; i++)
    {
        GameObject gameObject = Instantiate(algorithmWindow, feedPanel);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        if (i == 0)
        {
            rectTransform.anchoredPosition = Vector2.zero; // Centered on the canvas
        }
        else if (i == 1)
        {
            rectTransform.anchoredPosition = new Vector2(0, -canvasHeight); // Just below the canvas
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(0, pileOffset); // Below the visible area
            pileOffset -= 50; // Stack effect for further boxes
        }

        // Configure the box for its category
        string category = spawnList[i];
        ConfigureBox(gameObject, category);

        // Add interaction
        Button button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(() =>
        {
            int index = boxes.IndexOf(gameObject);
            if (index >= 0)
            {
                CatapultBox(index);
            }
        });

        boxes.Add(gameObject);
        yield return null;
    }

    isDynamicSpawning = false;
}


public void TriggerDynamicSpawn()
{
    if (isDynamicSpawning == false)
    {
        StopCoroutine(SpawnWindows());
    }
    
    isDynamicSpawning = true;
    // Destroy existing boxes and clear the list
    foreach (GameObject box in boxes)
    {
        if (box != null) Destroy(box);
    }
    boxes.Clear();

    StartCoroutine(SpawnDynamically());
}

    void ConfigureBox(GameObject box, string category)
    {
        TextMeshProUGUI boxText = box.transform.Find("PostText")?.GetComponent<TextMeshProUGUI>();
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