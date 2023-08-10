using UnityEngine;
using MelonLoader;
using static MelonLoader.MelonLogger;
using BasicMelonMod;
using Il2CppDecaGames.RotMG.Managers;
using Il2Cpp;
using System.Drawing;

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

        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            //Only runs mod once main scene is loaded and game objects are initialized
            isMain = sceneName == "Main";
            if (isMain)
            {
                setup();
            }
        }
        public override void OnUpdate()
        {
            //Called Every Frame
            //Useful for when you need to constantly update game information
        }

        public override void OnGUI()
        {

        }

        public override void OnApplicationQuit()
        {
            // Clean up any resources or subscriptions here
        }

        //gets the sceneInformation which contains the information that is currently loaded
        private void setup()
        {
            GameControllerObj = GameObject.Find("GameController");
            if (GameControllerObj == null)
            {
                MelonLogger.Msg("ERROR: Failed To find GameController Object");
                return;
            }
            MelonLogger.Msg("SUCCESS: Found GameController Object");
            ApplicationManagerObj = GameControllerObj.GetComponent<ApplicationManager>();
            if (ApplicationManagerObj == null)
            {
                MelonLogger.Msg("ERROR: Failed TO find ApplicationManager Object");
                return;
            }
            MelonLogger.Msg("SUCCESS: Found ApplicationManager Object");

            sceneInformation = ApplicationManagerObj._KKBAJFABEKE_k__BackingField;
            if (sceneInformation == null)
            {
                MelonLogger.Msg("ERROR: Failed TO find scene Information");
                return;

            }
            MelonLogger.Msg("SUCCESS: Found SceneInformation");
        }

        public void NewFloatingText(System.String text, bool? toggle = null)
        {
            Color32 white = new Color32(220, 220, 220, 255);
            var white_nullable = new Il2CppSystem.Nullable<UnityEngine.Color32>(white);
            Il2Cpp.DPCOFEPKKLI effectType = Il2Cpp.DPCOFEPKKLI.Notification;

            if (!_floatingTextInit) //nned to populate floating text pool
            {
                for (int i = 0; i < 12; i++) { sceneInformation.LINCIADNPEO.IGAEPHOHOCF.ShowFloatingText(effectType, "", white_nullable, 0.0f, 0.0f, 0.0f); }
                _floatingTextInit = true;
            }
            //LINCIADNPEO is the Player
            //IGAEPHOHOCF is the Player ViewHandler
            sceneInformation.LINCIADNPEO.IGAEPHOHOCF.ShowFloatingText(effectType, text, white_nullable, 0.0f, 0.0f, 0.0f);
        }
    }
}