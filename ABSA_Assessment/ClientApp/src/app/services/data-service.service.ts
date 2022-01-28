import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Entry } from '../classes/entry';
import { Phonebook } from '../classes/phonebook';
import { configuration } from '../configurations/configuration';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService {
  private REST_API_SERVER = configuration.apiUrl;

  constructor(private httpClient : HttpClient) { }

  AddPhonebook(phonebook : Phonebook) {
    const url = this.REST_API_SERVER + "Phonebook";
    const headers = {
      headers: new HttpHeaders({"Content-Type": "application/json"})
    };

    return this.httpClient.post(url, JSON.stringify(phonebook), headers).pipe(map((response : any) => {
      return response;
    }));
  }

  SelectPhonebook(): Observable<any> {
    const url = this.REST_API_SERVER + "Phonebook" ;

    return this.httpClient.get(url).pipe(map((response : any) => {
      return response;
    }));
  }

  AddPhonebookEntry(entry : Entry) {
    const url = this.REST_API_SERVER + "Entries";
    const headers = {
      headers: new HttpHeaders({"Content-Type": "application/json"})
    };

    return this.httpClient.post(url, JSON.stringify(entry),headers).pipe(map((response : any) => {
      return response;
    }));
  }

  SelectPhonebookEntries(phonebookId: string): Observable<any> {
    const url = this.REST_API_SERVER + "Entries/" + phonebookId;

    return this.httpClient.get(url).pipe(map((response : any) => {
      return response;
    }));
  }

  SearchPhrase(phrase: string): Observable<any> {
    const url = this.REST_API_SERVER + "Entries/Search/" + phrase;

    return this.httpClient.get(url).pipe(map((response : any) => {
      return response;
    }));
  }
}
