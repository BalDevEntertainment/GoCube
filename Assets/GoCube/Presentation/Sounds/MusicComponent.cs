using UnityEngine;
using UnityEngine.UI;

namespace GoCube.Presentation.Sounds {
    public class MusicComponent : MonoBehaviour {

        public Sprite OnSprite;
        public Sprite OffSprite;
        public AudioSource MusicAudioSource;

        private void Start() {
            GetComponentInChildren<Toggle>().onValueChanged.AddListener(MusicChanged);
            InitMusic();
        }

        private void InitMusic() {
            var musicStatus = PlayerPrefs.GetString("music");
            MusicChanged(!HasMusicPersisted(musicStatus) || bool.Parse(musicStatus));
        }

        private bool HasMusicPersisted(string musicStatus) {
            return musicStatus != "";
        }

        private void MusicChanged(bool on) {
            MusicAudioSource.volume = on ? 1 : 0;
            GetComponentInChildren<Toggle>().image.sprite = on ? OnSprite : OffSprite;
            PlayerPrefs.SetString("music", on ? "true" : "false");
        }
    }
}
