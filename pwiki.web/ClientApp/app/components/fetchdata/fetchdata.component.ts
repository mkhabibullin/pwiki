import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public notes: Note[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        console.log(baseUrl);
        http.get(baseUrl + 'notes').subscribe(result => {
            this.notes = result.json() as Note[];
        }, error => console.error(error));
    }
}

interface Note {
    id: string;
    title: number;
    text: number;
}
