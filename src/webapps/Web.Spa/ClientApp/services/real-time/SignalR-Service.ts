import * as signalR from "@microsoft/signalr";
import { LogLevel } from "@microsoft/signalr";
import ISignalRService from './ISignalR-Service';

/**
 * @class SignalRService Arbitrary service for handling realtime-communication with SignalR hubs.
 */
export default class SignalRService implements ISignalRService {

    // Connection to SignalR hub
    private signalRInstance: signalR.HubConnection;
    eventName: string;

    /**
     * Default constructor of a SignalRService.
     * @param serviceUrl Url of SignalR hub.
     * @param eventName Name of event that will be triggered from SignalR hub.
     */
    constructor(serviceUrl: string, eventName: string) {
        this.signalRInstance = new signalR.HubConnectionBuilder()
        .withUrl(serviceUrl)
        .configureLogging(LogLevel.Trace)
        .build();

        this.eventName = eventName;
    }

    /**
     * @function connection Getter of signalR instance field.
     */
    getSignalInstance = () => {
        return this.signalRInstance;
    }

    /**
     * @function startFail Event handler that is trigger in case of unsuccessfull connection to the SignalR hub.
     */
    startFail = () => {
        console.log("Connection failed.");
    }
    
    /**
     * @function startSuccess Event handler that is trigger in case of successfull connection to the SignalR hub.
     */
    startSuccess = () => {
        console.log("Connected.");
        //this.notify();

        this.signalRInstance.invoke("notifyWatching", "Patrik", "Duch").then((res) => {
            debugger;
        })
    }

    /**
     * @function notify notify server we're watching.
     * @param eventName Name of event that will be triggered.
     */
    notify = () => {
        this.signalRInstance.send(this.eventName);
    }
}