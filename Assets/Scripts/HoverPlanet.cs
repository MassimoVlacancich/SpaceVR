using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Collider))]
public class HoverPlanet : MonoBehaviour
{

    public Text planetName;
    Behaviour haloComponent;
    float planetSpeed;

    // Loading Bar
    public Transform loadingBar;
    [SerializeField] private float loadingBarCurrentAmount;
    [SerializeField] private float loadingBarSpeed;
	public bool closeAppOnEnter = false;
	public bool availableInV2 = false;
    bool loadBar;

	// Change scene
	[SerializeField] public string sceneToLoad;

    void Start()
    {
        planetName.text = "";
        loadingBar.parent.gameObject.SetActive(false);
		//Camera.main.transform.Rotate(new Vector3(180, 0, 0));
    }

    void Update()
    {
        if (loadBar)
        {
            // Loading Bar up
            if (loadingBarCurrentAmount < 100)
            {
                loadingBarCurrentAmount += loadingBarSpeed * Time.deltaTime;
            }
            loadingBar.GetComponent<Image>().fillAmount = loadingBarCurrentAmount / 100;
            if (loadingBarCurrentAmount > 99)
            {
				if (closeAppOnEnter == false) {
					
					planetName.color = Color.red;

					if (availableInV2 == false) {
						planetName.text = this.gameObject.name + " Ready to teleport";
						SceneManager.LoadScene (sceneToLoad);
					} else {
						planetName.text = this.gameObject.name + "available from version 2 - soon on the store";
					}
				} 
				else {
					planetName.text = " Quitting application";
					Application.Quit();
				}

            }

        }
    }

    void LateUpdate()
    {
        GvrViewer.Instance.UpdateState();
        if (GvrViewer.Instance.BackButtonPressed)
        {
            Application.Quit();
        }
    }

    public void SetGazedAt(bool gazedAt)
    {
        if (gazedAt)
        {
            planetName.color = Color.white;
            planetName.text = this.gameObject.name;
            loadingBar.parent.gameObject.SetActive(true);
            loadBar = true;
        }
        else
        {
            planetName.text = "";
            loadingBar.GetComponent<Image>().fillAmount = 0;
            loadingBar.parent.gameObject.SetActive(false);
            loadBar = false;
            loadingBarCurrentAmount = 0;
            Debug.Log("amount = " + loadingBarCurrentAmount);
        }
    }

    #region IGvrGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        SetGazedAt(true);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        SetGazedAt(false);
    }

    #endregion
}