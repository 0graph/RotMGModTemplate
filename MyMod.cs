using UnityEngine;
using MelonLoader;
using static MelonLoader.MelonLogger;
using Il2CppDecaGames.RotMG.Managers;
using Il2Cpp;

namespace BasicMelonMod
{
    public class MyMod : MelonMod
    {
        public static MyMod? instance;
        private bool isMain = false;

        private GameObject? GameControllerObj;
        private ApplicationManager? ApplicationManagerObj;
        private OIGNDMLLBGC? sceneInformation;
        private static bool _floatingTextInit = false;


        public override void OnEarlyInitializeMelon()
        {
            instance = this;
        }

        public override void OnLateUpdate()
        {
            // This function is called every frame, except after OnUpdate() is called.
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // Ensure we only run the mod once the Unity Main scene is loaded and game objects are initialized.

            isMain = sceneName == "Main";
            if (isMain)
            {
                Setup();
            }
        }
        public override void OnUpdate()
        {
            // This function is called every frame.
            // Useful for when you need to constantly update game information.
        }

        public override void OnGUI()
        {
            // This is called on every IMGUI event. Only use this for IMGUI interaction as it can run multiple times per frame.
        }

        public override void OnApplicationQuit()
        {
            // Shut down gracefully or cancel the shutdown here.
        }

        /// <summary>
        /// Shows floating text of any color above the player in-game.
        /// </summary>
        /// <param name="text">The text to show.</param>
        /// <param name="color">Color32 object for text color.</param>
        public void ShowFloatingText(String text, Color32 color)
        {
            Il2CppSystem.Nullable<Color32> newColor = new Il2CppSystem.Nullable<Color32>(color);

            DPCOFEPKKLI effectType = DPCOFEPKKLI.LevelUp;

            if (!_floatingTextInit)
            {
                for (int i = 0; i < 12; i++)
                {
                    sceneInformation?.LINCIADNPEO.IGAEPHOHOCF.ShowFloatingText(effectType, "", newColor, 0.0f, 0.0f,
                        0.0f);
                }
                _floatingTextInit = true;
            }
            // LINCIADNPEO is the Player
            // IGAEPHOHOCF is the Player ViewHandler
            sceneInformation?.LINCIADNPEO.IGAEPHOHOCF.ShowFloatingText(effectType, text, newColor, 0.0f, 0.0f, 0.0f);
        }

        /// <summary>
        /// Shows floating text of green, red or whit color above the player in-game.
        /// </summary>
        /// <param name="text">The text to show.</param>
        /// <param name="toggle">(optional) True for green text, False for red text. Default is white.</param>
        public void ShowFloatingText(String text, bool? toggle = null)
        {
            var color = toggle switch
            {
                null => new Color32(220, 220, 220, 255), // white
                true => new Color32(32, 220, 0, 255), // green
                _ => new Color32(255, 0, 25, 255) // red
            };

            ShowFloatingText(text, color);
        }

        /// <summary>
        /// Initialize variables required for the mod such as finding the GameController and sceneInformation.
        /// sceneInformation is important as it contains most objects loaded in the current scene.
        /// </summary>
        private void Setup()
        {
            GameControllerObj = GameObject.Find("GameController");
            if (GameControllerObj == null)
            {
                Msg("ERROR: Failed to find GameController object.");
                return;
            }
            Msg("SUCCESS: Found GameController Object");
            ApplicationManagerObj = GameControllerObj.GetComponent<ApplicationManager>();
            if (ApplicationManagerObj == null)
            {
                Msg("ERROR: Failed to find ApplicationManager object.");
                return;
            }
            Msg("SUCCESS: Found ApplicationManager object.");

            sceneInformation = ApplicationManagerObj._KKBAJFABEKE_k__BackingField;
            if (sceneInformation == null)
            {
                Msg("ERROR: Failed to find sceneInformation.");
                return;

            }
            Msg("SUCCESS: Found sceneInformation.");
        }
    }
}