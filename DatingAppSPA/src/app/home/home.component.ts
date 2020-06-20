import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
registerMode = false;
  constructor(private http: HttpClient) { }
  values: any;
  ngOnInit() {
    this.getValues();
  }
  RegisterToggle(){
    this.registerMode = true;
  }
  getValues(){
    this.http.get('http://localhost:49248/weatherforecast').subscribe(response => {
      this.values = response;
    },
    error => {
       console.log(error);
    });
  }
  cancelRegisterMode(registerMode: boolean){
    this.registerMode = registerMode;
  }
}
