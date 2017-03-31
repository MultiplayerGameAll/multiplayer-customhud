using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomDiscovery : NetworkDiscovery {

	public delegate void OnConnectEvent(string host);

	private OnConnectEvent CallBackConnectFunction; 

	private string dataPattern;

	private bool connected;

	void Start(){
		showGUI = false;
		this.Initialize();
		this.dataPattern = "123456";
		this.broadcastData = this.dataPattern;
	}

	public override void OnReceivedBroadcast(string fromAddress, string data)
    {
         Debug.Log("Server Found " + fromAddress + " data " + data);
		 if(data.StartsWith(dataPattern ) && !connected){
			Debug.Log("connecting");
			CallBackConnectFunction(fromAddress);
			connected = true;
		 }
    }

	public void connect(OnConnectEvent function){
		this.StartAsClient();
		this.CallBackConnectFunction = function;
	}
}
