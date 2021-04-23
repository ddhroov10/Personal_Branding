using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfoExtendedManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject welcomePanel;

    [SerializeField]
    private GameObject secPanel;

    //[SerializeField]
    //private Button dismissButton;

    //[SerializeField]
    //private Button LinkedinButton;

    [SerializeField]
    private Text imageTrackedText;

    private ARTrackedImageManager m_TrackedImageManager;

    public string NamePrefab { get; private set; }

    void Awake()
    {
        //dismissButton.onClick.AddListener(Dismiss);
        //LinkedinButton.onClick.AddListener(Dismiss);
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void Dismiss() => secPanel.SetActive(false);

    private void Open()
    {
        Application.OpenURL("https://www.linkedin.com/in/dhroov-goel-48b6401aa/");
    }
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // Display the name of the tracked image in the canvas
            imageTrackedText.text = trackedImage.referenceImage.name;

            trackedImage.transform.Rotate(0, 90, 0);

            // Give the initial image a reasonable default scale
            trackedImage.transform.localScale =
                new Vector3(-(trackedImage.referenceImage.size.x + 0.05f), 0.005f, -trackedImage.referenceImage.size.y);


        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            // Display the name of the tracked image in the canvas
            //imageTrackedText.text = trackedImage.referenceImage.name;
            imageTrackedText.fontSize = 40;

            if (trackedImage.referenceImage.name == "Front_ID_Card")
            {
                imageTrackedText.text = "";
            }


            // Give the initial image a reasonable default scale
            trackedImage.transform.localScale =
                new Vector3(-(trackedImage.referenceImage.size.x + 0.05f), 0.005f, -trackedImage.referenceImage.size.y);
        }

    }
}