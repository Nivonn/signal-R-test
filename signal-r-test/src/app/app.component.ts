import { Component, OnDestroy, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

export class TelemetryParameterUtcDto {
  packetId: number | undefined;
  parameterId: string | undefined;
  parameterUtc: string| undefined;
  parameterValue: number| undefined;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit,OnDestroy {

  hubConnection:HubConnection | undefined;

  ngOnInit(): void {

    const url = "http://localhost:5023/";
    this.hubConnection = new HubConnectionBuilder()
    .withUrl(url + "demoHub")
    .build();  

    this.hubConnection.on('UpdateParam',(dto: TelemetryParameterUtcDto) => {console.log(dto)});
  
    this.hubConnection.start();
  }

  ngOnDestroy(): void {
    this.hubConnection?.off('UpdateParam',(dto: TelemetryParameterUtcDto) => {console.log(dto)});
    this.hubConnection?.stop();
  }
}
