import {Component, EventEmitter, NgZone, OnInit} from '@angular/core';
import {HubConnection} from '@aspnet/signalr/dist/esm/HubConnection';
import {HubConnectionBuilder} from '@aspnet/signalr';
import {HttpHeaders} from '@angular/common/http';
import {tokenName} from '@angular/compiler';
import {MessageService} from '../../shared/message.service';
import {Message} from '../../Models/message';
import {UserProfileModel} from '../../Models/user-profile-model';
import {UserService} from '../../shared/user.service';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {
  messages: Array<Message> = new Array<Message>();
  friendProfile: UserProfileModel = new UserProfileModel();
  message: string;
  userName: string;
  friendName: string;
  allMessages: Message[];
  private connectionIsEstablished = false;
  // tslint:disable-next-line:variable-name
  private _hubConnection: HubConnection;
  // tslint:disable-next-line:ban-types
  connectionEstablished = new EventEmitter<Boolean>();
  constructor(private service: MessageService , private userService: UserService) {
    this.createConnection();
    this.startConnection();

  }
  ngOnInit(): void {
    this.friendName = sessionStorage.getItem('userIdForMessage');
    this.userName = sessionStorage.getItem('userId');
    this.userService.getUserProfile(this.friendName).subscribe((data: UserProfileModel) => this.friendProfile = data);
    this.getAllMessage();
    this._hubConnection.on('MessageReceived', ( userName: string, message: string, date: string) => {
      const lec: Message = new Message();
      lec.messageText = message;
      lec.senderId = userName;
      lec.date = new Date().toDateString();
      this.messages.push(lec);
    });
  }
  getAllMessage() {
    this.service.getAllMessagesByDialog(this.userName, this.friendName).subscribe((data: Message[]) => this.allMessages = data);
  }
  sendMessage() {
    this._hubConnection.invoke('NewMessage', this.friendName, this.message ).catch(err => console.error(err));
  }
  private createConnection() {
    const token = new HttpHeaders({Authorization: 'Bearer ' + sessionStorage.getItem('token')});
    this._hubConnection = new HubConnectionBuilder().withUrl('https://localhost:5001/MessageHub', {accessTokenFactory: () =>  sessionStorage.getItem('token')}).build();
  }
  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
        this._hubConnection.invoke('Enter', this.friendName).catch(err => console.error(err));
      })
      .catch(err => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(function() { this.startConnection(); }, 5000);
      });
  }
}
