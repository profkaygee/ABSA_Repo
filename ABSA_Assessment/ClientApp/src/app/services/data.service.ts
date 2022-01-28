import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Phonebook } from "../classes/phonebook";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";
import { Entry } from "../classes/entry";
import { configuration } from "../configurations/configuration";

@Injectable({ providedIn: "root" })
export class DataService {
  private REST_API_SERVER = configuration.apiUrl;

  constructor(private httpClient: HttpClient) { }

  AddPhonebook(phonebook: Phonebook) {
    const url = this.REST_API_SERVER + "Phonebook/Books";
    const headers = {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    };

    return this.httpClient.post(url, JSON.stringify(phonebook), headers).pipe(map((response: any) => {
      return response;
    }));
  }

  SelectPhonebook(): Observable<any> {
    const url = this.REST_API_SERVER + "Phonebook";

    return this.httpClient.get(url).pipe(map((response: any) => {
      return response;
    }));
  }

  AddPhonebookEntry(entry: Entry) {
    const url = this.REST_API_SERVER + "Entries";
    const headers = {
      headers: new HttpHeaders({ "Content-Type": "application/json" })
    };

    return this.httpClient.post(url, JSON.stringify(entry), headers).pipe(map((response: any) => {
      return response;
    }));
  }

  SelectPhonebookEntries(phonebookId): Observable<any> {
    const url = this.REST_API_SERVER + "Entries/" + phonebookId;

    return this.httpClient.get(url).pipe(map((response: any) => {
      debugger;
      return response;
    }));
  }

  SearchPhrase(phrase): Observable<any> {
    const url = this.REST_API_SERVER + "Entries/search/" + phrase;

    return this.httpClient.get(url).pipe(map((response: any) => {
      debugger;
      return response;
    }));
  }
}
