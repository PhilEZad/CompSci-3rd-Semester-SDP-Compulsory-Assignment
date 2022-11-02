import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/services/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
boxName: any;
writeBoxName: any;

constructor(private http: HttpService)
  {
      
  }

  async ngOnInit() {

    boxName: string = "";

    const boxes = await this.http.getBoxes();
    console.log(boxes);
  }

  writeBoxName() {
    console.log(this.boxName);
  }

}
