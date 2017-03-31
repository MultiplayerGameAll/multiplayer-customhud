using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkManager))]
public class CustomNetworkManager : MonoBehaviour {

	private NetworkManager manager;

	[SerializeField]
	private CustomDiscovery discovery;

	void Awake()
	{
		manager = GetComponent<NetworkManager>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if (!NetworkClient.active && !NetworkServer.active && manager.matchMaker == null)
		{
			int xpos = 10 ;
			int ypos = 40;
			int spacing = 24;
			if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Server")){
				manager.StartHost();
				discovery.StartAsServer();
			}
			ypos += spacing;
			if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Client")){
				discovery.connect(onConnect);
			}
		}
	}

	public void onConnect(string host){
		manager.networkAddress = host; //endereco do servidor
		manager.StartClient();
	}
}
