using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FpsGameManager : MonoBehaviour
{

    [SerializeField] GameObject gameOverUi;
    [SerializeField] Button btnexit;
    [SerializeField] Text Score;
    [SerializeField]  public GameBalancing FpsgambeBalancing;
    [SerializeField] private float courentTime;

    [SerializeField] Slider slider;
    [SerializeField] GameObject mellow;

    [SerializeField] public float mellowsInScene;
    
    [SerializeField] public float timeElapsed = 0f;

    [SerializeField] float radius = 0.5f;
    [SerializeField] LayerMask lm;
    [SerializeField] public Transform bottomReference;
    [Range(0.1f, 1f)]
    [SerializeField] public float velocityTarget = 0.1f;
    [SerializeField] public float velocityIncreseVelocityPerSecond = 0.00375f;
    [SerializeField] public float timeIncrese = 0f;
    public static FpsGameManager Instance;
    public bool flag = false;
    public int scorei = 0;
    public void DecrementMellowsInScene()
    {
        mellowsInScene--;
    }

    public void Death()
    {
        UiBgSoundManager.Instance.PlayDefeat();
        btnexit.enabled = false;
        gameOverUi.SetActive(true);
        //Camera.main.GetComponent<AudioSource>().Stop();
        Time.timeScale = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Start()
    {

        Time.timeScale = 1;
        courentTime = FpsgambeBalancing.maxTime;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        UiBgSoundManager.Instance.PlayBgFps();
    }

    public void AddTime()
    {
        scorei++;
        Score.text = "Score: " + scorei;
        float aux = courentTime + FpsgambeBalancing.incrementTimeValue;
        courentTime = Mathf.Clamp(aux, 0f, FpsgambeBalancing.maxTime);
        
    }
    public void DecrementTime()
    {
        float aux = courentTime - FpsgambeBalancing.incrementTimeValue;
        courentTime = Mathf.Clamp(aux, 0, FpsgambeBalancing.maxTime);
    }
    
    void Update()
    {
       // Debug.Log(Time.timeScale);
        timeElapsed += Time.deltaTime;
        if (timeElapsed > FpsgambeBalancing.timeSpawn && mellowsInScene < FpsgambeBalancing.maxmellowsInScene)
        {
            bool conflict = true;
            
            Vector3 position = new Vector3(Random.Range(-2f, 2f), Random.Range(bottomReference.position.y+0.3f, 6f), 4.5f);
            conflict = Physics.OverlapSphere(position, radius, lm).Length > 0;
            if (!conflict)
            {
               mellowsInScene++;
               Instantiate(mellow, position, Quaternion.identity);
                timeElapsed = 0f;
            }
        }
        timeIncrese += Time.deltaTime;
        if (timeIncrese > 1f)
        {
            timeIncrese = 0f;
            velocityTarget += velocityIncreseVelocityPerSecond;
        }
        courentTime -= Time.deltaTime;
        slider.value = courentTime / FpsgambeBalancing.maxTime;
        if (courentTime <= 0 && !flag)
        {
            flag = true;
            Death();
        }
    }
}
