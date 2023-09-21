import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: ContentDisplayModelItem[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ContentDisplayModelItem[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts.push(result[0]);
      this.forecasts.push(result[1]);
      console.log(JSON.stringify(result));
      console.log(this.forecasts);
        for (var k in this.forecasts[0]) {
          console.log("values");
          console.log(k);
        }
     
    }, error => console.error(error));
  }
}

interface ContentDisplayModelItem {
  FieldName: string;
  FieldValue: string;
  FundName: string;
  Environment: string ;
  CollectionName: string; 


}
