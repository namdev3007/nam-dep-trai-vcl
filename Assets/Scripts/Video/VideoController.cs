using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playButton;
    public Button pauseButton;
    public Slider progressSlider;

    private bool isUserInteracting = false;

    void Start()
    {
        playButton.onClick.AddListener(PlayVideo);
        pauseButton.onClick.AddListener(PauseVideo);

        progressSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Thêm component để xử lý sự kiện kéo thả
        EventTrigger trigger = progressSlider.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entryBegin = new EventTrigger.Entry();
        entryBegin.eventID = EventTriggerType.PointerDown;
        entryBegin.callback.AddListener((data) => { OnSliderBeginDrag((PointerEventData)data); });
        trigger.triggers.Add(entryBegin);

        EventTrigger.Entry entryEnd = new EventTrigger.Entry();
        entryEnd.eventID = EventTriggerType.PointerUp;
        entryEnd.callback.AddListener((data) => { OnSliderEndDrag((PointerEventData)data); });
        trigger.triggers.Add(entryEnd);
    }

    void Update()
    {
        if (!isUserInteracting && videoPlayer.frameCount > 0)
        {
            progressSlider.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }

    void PlayVideo()
    {
        videoPlayer.Play();
    }

    void PauseVideo()
    {
        videoPlayer.Pause();
    }

    void OnSliderValueChanged(float value)
    {
        if (isUserInteracting && videoPlayer.frameCount > 0)
        {
            long frame = (long)(value * videoPlayer.frameCount);
            videoPlayer.frame = frame;
        }
    }

    public void OnSliderBeginDrag(PointerEventData eventData)
    {
        isUserInteracting = true;
    }

    public void OnSliderEndDrag(PointerEventData eventData)
    {
        isUserInteracting = false;
    }
}   