import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
 values: any;
  constructor(private http: Http) { }

  ngOnInit() {
    this.getValues();
  }
getValues(){
  this.http.get('http://localhost:49248/weatherforecast').subscribe(response => {
    this.values = response.json();
    console.log(response);
  });
}
}
