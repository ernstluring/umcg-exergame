using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathsDatabase : ScriptableObject {

	[System.Serializable]
	public struct Friesland{
		public string gebouwen, bomen, props;
	}

	[System.Serializable]
	public struct Groningen {
		public string gebouwen, bomen, props;
	}

	[System.Serializable]
	public struct Drenthe {
		public string gebouwen, bomen, props;
	}

	public Friesland friesland;
	public Groningen groningen;
	public Drenthe drenthe;
}
