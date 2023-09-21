import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-post-teams',
  templateUrl: './post-teams.component.html'
})
export class PostTeamsComponent {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post(baseUrl + 'weatherforecast', '').subscribe(result => {
      console.log(JSON.stringify(result));  
    }, error => console.error(error));
  }
}

