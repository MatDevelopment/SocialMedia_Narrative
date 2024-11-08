using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Button = UnityEngine.UI.Button;
using TMPro;

public class ScrollingAlgorithm : MonoBehaviour
{
    [System.Serializable]
    public struct QuoteData
    {
        public string quote;
        public string imageLocation;
    }
    public GameObject algorithmWindow;
    public Canvas gameCanvas;
    public int numberOfWindows = 15;
    private float offScreenOffset = -700;
    private float catapultSpeed = 750f;
    public float scrollCooldown = 0.5f;
    private float lastScrollTime = -1f;

    private List<GameObject> boxes = new List<GameObject>();
    private List<Color> colors = new List<Color>();
    private Dictionary<Color, List<QuoteData>> colorData;
    private Dictionary<string, Sprite> imageDictionary;

    // Start is called before the first frame update
    void Start()
    {
        LoadImages();
        PrepareColorList();
        PrepareDataDictionary();
        StartCoroutine(SpawnWindows());
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Time.time > lastScrollTime + scrollCooldown)
        {
            lastScrollTime = Time.time;
            SimulateClick();
        }
    }

    void LoadImages()
    {
        imageDictionary = new Dictionary<string, Sprite>();

        Sprite[] sprites = Resources.LoadAll<Sprite>("QuoteImages");
        foreach (Sprite sprite in sprites)
        {
            imageDictionary[sprite.name] = sprite;
        }
    }

    void PrepareColorList()
    {
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.yellow);

        for (int i = 0; i < 4; i++)  // 4 sets of 3 more to get to 15 in total
        {
            colors.Add(Color.yellow);
            colors.Add(Color.red);
            colors.Add(Color.blue);
        }

        for (int i = 3; i < colors.Count; i++)
        {
            Color temp = colors[i];
            int randomIndex = Random.Range(i, colors.Count);
            colors[i] = colors[randomIndex];
            colors[randomIndex] = temp;
        }
    }

    void PrepareDataDictionary()
    {
        colorData = new Dictionary<Color, List<QuoteData>>()
        {
            { Color.blue, new List<QuoteData> {
                new QuoteData { quote = "I know I should take a break, but I can’t seem to relax. My mind is constantly jumping from one thing to the next. Does anyone else feel like they can never fully switch off?", imageLocation = "anxiety_1" },
                new QuoteData { quote = "Some days I feel like I’m doing okay, and other days it’s just… a lot. Like, I can’t breathe right. Anyone else trying to keep it all together but struggling to do so?", imageLocation = "anxiety_2" },
                new QuoteData { quote = "You ever have those moments where you feel like everything's moving so fast and you're just... trying to keep up? It’s like everyone else is already where they need to be", imageLocation = "anxiety_3" },
                new QuoteData { quote = "The more I think about it, the more I realize that maybe I don't actually know how to relax. I always feel like there’s something I should be doing", imageLocation = "anxiety_4" },
                new QuoteData { quote = "I love how everyone seems so sure of themselves online. It's weird, right? How they just... handle everything. I sometimes feel like I’m always one step behind", imageLocation = "anxiety_5" }
            }},
            { Color.yellow, new List<QuoteData> {
                new QuoteData { quote = "I saw a tweet saying, 'You don’t get weekends off if you want to win.' Can’t let up if you want to succeed, right?", imageLocation = "grind_1" },
                new QuoteData { quote = "You know, it's not about luck or talent. It’s about working nonstop. I’ve learned that sleep is overrated", imageLocation = "grind_2" },
                new QuoteData { quote = "Woke up at 5 AM again today. People say that's when the real hustlers are working. I can already feel the difference. This is the grind", imageLocation = "grind_3" },
                new QuoteData { quote = "Saw some people complaining about how hard their week was. Honestly, though, if you really want to achieve something big, you’ve got to push through. There’s no room for weakness", imageLocation = "grind_4" },
                new QuoteData { quote = "Another early morning, another grind. But you know, the hustle never stops. You can’t expect anything if you don’t push yourself to the absolute limit", imageLocation = "grind_5" }
            }},
            { Color.red, new List<QuoteData> {
                new QuoteData { quote = "Woke up feeling great after a week of hard work at the gym. It’s amazing what consistency can do for you. Who else is on a fitness journey?", imageLocation = "body_image_1" },
                new QuoteData { quote = "Found a new skincare routine that’s totally transformed my skin. Feels so good to be able to go out without makeup now! Anyone else tried something that totally changed the game?", imageLocation = "body_image_2" },
                new QuoteData { quote = "Just finished my workout. The progress is slow, but at least it’s progress, right? One step closer", imageLocation = "body_image_3" },
                new QuoteData { quote = "Tried a new recipe today. They say if you want to get serious, you need to treat food like fuel. But it’s hard not to compare when I see what others are eating", imageLocation = "body_image_4" },
                new QuoteData { quote = "I’ve been really into taking care of myself lately. Everyone says self-care is important, but I wonder how long it takes before you start really seeing the results", imageLocation = "body_image_5" }
            }}
        };
    }

    IEnumerator SpawnWindows()
    {
        RectTransform canvasRect = gameCanvas.GetComponent<RectTransform>();

        for (int i = 0; i < numberOfWindows; i++)
        {
            Debug.Log($"Spawning window {i + 1}/{numberOfWindows}"); // Debug log to check spawning

            // Instantiate the window
            GameObject gameObject = Instantiate(algorithmWindow, gameCanvas.transform);
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

            // Position first box in the center, others below the canvas
            if (i == 0)
            {
                rectTransform.anchoredPosition = Vector2.zero;
            }
            else
            {
                rectTransform.anchoredPosition = new Vector2(0, offScreenOffset);
                offScreenOffset = offScreenOffset + -700;
            }

            Image boxImage = gameObject.GetComponent<Image>();
            Color algorithmColor = colors[i];
            boxImage.color = algorithmColor;

            TextMeshProUGUI boxText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            Image quoteImage = gameObject.transform.Find("QuoteImage").GetComponent<Image>();

            if (colorData.ContainsKey(algorithmColor))
            {
                List<QuoteData> possibleData = colorData[algorithmColor];
                QuoteData selectedData = possibleData[Random.Range(0, possibleData.Count)];

                boxText.text = selectedData.quote;

                // Look up the image in the image dictionary
                if (imageDictionary.TryGetValue(selectedData.imageLocation, out Sprite foundImage))
                {
                    quoteImage.sprite = foundImage;
                }
                else
                {
                    Debug.LogWarning($"Image with key {selectedData.imageLocation} not found in image dictionary.");
                }
            }

            Button button = gameObject.AddComponent<Button>();
            int currentIndex = i; // Capture current index in loop scope
            button.onClick.AddListener(() => CatapultBox(currentIndex));

            boxes.Add(gameObject);
            yield return null;
        }
    }

    void CatapultBox(int index)
    {
        if (index >= boxes.Count) return;

        // Animate the clicked box upwards off-screen
        StartCoroutine(CatapultAnimation(boxes[index]));

        // Slide the next box in line to the center position, if available
        if (index + 1 < boxes.Count)
        {
            StartCoroutine(SlideToCenter(boxes[index + 1]));
        }
    }

    // Coroutine to move the box upwards off the screen
    IEnumerator CatapultAnimation(GameObject box)
    {
        RectTransform rectTransform = box.GetComponent<RectTransform>();
        float targetY = gameCanvas.GetComponent<RectTransform>().rect.height / 2 + 300; // Move it far off-screen

        while (rectTransform.anchoredPosition.y < targetY)
        {
            rectTransform.anchoredPosition += Vector2.up * catapultSpeed * Time.deltaTime;
            yield return null;
        }

        // Destroy box once it's fully off-screen
        Destroy(box);
    }

    // Coroutine to slide the next box smoothly to the center of the canvas
    IEnumerator SlideToCenter(GameObject box)
    {
        RectTransform rectTransform = box.GetComponent<RectTransform>();
        Vector2 startPosition = rectTransform.anchoredPosition;
        Vector2 targetPosition = Vector2.zero; // Center position

        while (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 1f)
        {
            rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, targetPosition, catapultSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure it ends exactly in the center
        rectTransform.anchoredPosition = targetPosition;
    }

    void SimulateClick()
    {
        // Find the currently centered box (the first active box in the list)
        for (int i = 0; i < boxes.Count; i++)
        {
            if (boxes[i] != null && boxes[i].activeSelf)
            {
                // Trigger the catapult effect as if it were clicked
                CatapultBox(i);
                break;
            }
        }
    }
}