using UnityEngine;

namespace PlayerPreferencesPackage { 
	public static class PlayerPreferences {
		
		// keys for player preferences 
		public static readonly string CONTROLS_CHOICE_ONE_KEY = "controlChoiceOneKey";
		public static readonly string CONTROLS_CHOICE_TWO_KEY = "controlChoiceTwoKey";
		public static readonly string CONTROLS_MUSIC_ON_KEY   = "controlsMusicOneKey";
		public static readonly string CONTROLS_MUSIC_OFF_KEY  = "controlsMusicOffKey";

		// values for player preferences
		public static readonly string CONTROLS_CHOICE_ONE_VAL = "controlChoiceOneVal";
		public static readonly string CONTROLS_CHOICE_TWO_VAL = "controlChoiceTwoVal";
		public static readonly string CONTROLS_MUSIC_ON_VAL   = "controlsMusicOneKeyVal";
		public static readonly string CONTROLS_MUSIC_OFF_VAL  = "controlsMusicOffKeyVal";

		// default values for preferences settings
		public static string CONTROLS_DEFAULT_VALUE   = "";

		// logger message
		private static string LOGER_CHOICE_VALIDATION_ERROR = "Bad value passed {0}";

		// set initial state on object awake
		public static void setControlsDefaultValues() {
			PlayerPrefs.SetString (CONTROLS_CHOICE_ONE_KEY, CONTROLS_DEFAULT_VALUE);
			PlayerPrefs.SetString (CONTROLS_CHOICE_TWO_KEY, CONTROLS_DEFAULT_VALUE);
			PlayerPrefs.SetString (CONTROLS_MUSIC_ON_KEY, CONTROLS_DEFAULT_VALUE);
			PlayerPrefs.SetString (CONTROLS_MUSIC_OFF_KEY, CONTROLS_DEFAULT_VALUE);
		}

		// set value for controls choice one value
		public static void setControlsChoiceOneVal (string choice) {
			if (validateSetterChoiceVal (choice)) {
				PlayerPrefs.SetString (CONTROLS_CHOICE_ONE_KEY, choice);
			}
		}

		// set value for controls choice two value
		public static void setControlsChoiceTwoVal (string choice) {
			if (validateSetterChoiceVal (choice)) {
				PlayerPrefs.SetString (CONTROLS_CHOICE_TWO_KEY, choice);
			}
		}

		// set value for controls music on
		public static void setControlsMusicOn (string choice) {
			if (validateSetterChoiceVal (choice)) {
				PlayerPrefs.SetString (CONTROLS_MUSIC_ON_KEY, choice);
			}
		}

		// set value for controls music off
		public static void setControlsMusicOff (string choice) {
			if (validateSetterChoiceVal (choice)) {
				PlayerPrefs.SetString (CONTROLS_MUSIC_OFF_KEY, choice);
			}
		}

		// check if controls choice one is enabled
		public static bool isPlayerGameControlPreferenceChoiceOneEnabled() {
			return PlayerPrefs.GetString (CONTROLS_CHOICE_ONE_KEY) == CONTROLS_CHOICE_ONE_VAL;
		}

		// check if controls choice two enabled
		public static bool isPlayerGameControlPreferenceChoiceTwoEnabled() {
			return PlayerPrefs.GetString (CONTROLS_CHOICE_TWO_KEY) == CONTROLS_CHOICE_TWO_VAL;
		}

		// check if music on
		public static bool isPlayerGameSoundPreferenceOn() {
			return PlayerPrefs.GetString (CONTROLS_MUSIC_ON_KEY) == CONTROLS_MUSIC_ON_VAL;
		}

		// check if music off
		public static bool isPlayerGameSoundPreferenceOff() {
			return PlayerPrefs.GetString (CONTROLS_MUSIC_OFF_KEY) == CONTROLS_MUSIC_OFF_VAL;
		}

		// validate setter values
		private static bool validateSetterChoiceVal(string choice) {
			bool validateVal  = choice == CONTROLS_CHOICE_ONE_VAL ||
							    choice == CONTROLS_CHOICE_TWO_VAL ||
							    choice == CONTROLS_MUSIC_ON_VAL   ||
								choice == CONTROLS_MUSIC_OFF_VAL  ||
								choice == CONTROLS_DEFAULT_VALUE;	
			// log error if choice is invalid
			if (!validateVal) {
				Debug.LogError (string.Format(LOGER_CHOICE_VALIDATION_ERROR, choice));
			}

			return validateVal;			
		}

		// check if all states are empty
		private static bool isStatesEmpty() {
			return !isPlayerGameControlPreferenceChoiceOneEnabled () &&
				   !isPlayerGameControlPreferenceChoiceTwoEnabled () &&
				   !isPlayerGameSoundPreferenceOn () &&
				   !isPlayerGameSoundPreferenceOff ();
		}

	}
}
