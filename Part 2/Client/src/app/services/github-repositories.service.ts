import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rootobject } from '../models/Rootobject';
import { Item } from '../models/Item';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class GithubRepositoriesService {

  private apiUrl = environment.baseUrl;
  private emailUrl = environment.emailApi;
  private searchApi = environment.searchApi;

  constructor(private http: HttpClient) { }

  searchAsync(searchKeyword: string): Observable<Rootobject> {
    const url = `${this.apiUrl}${this.searchApi}${searchKeyword}`;
    return this.http.get<Rootobject>(url);
  }

  sendEmail(email: string, item: Item): Observable<any> {
    const url = `${this.apiUrl}${this.emailUrl}${email}`;
    return this.http.post<any>(url, item);
  }

  // setBookmarkItem(item: Item): Observable<any> {
  //   const url = `https://localhost:7164/api/Bookmark/SetItem`;
  //   return this.http.post<any>(url, item);
  // }

  // getBookmarkedItems(): Observable<Array<Item>> {
  //   const url = `https://localhost:7164/api/Bookmark/GetItems`;
  //   return this.http.get<Array<Item>>(url);
  // }

  setBookmarkItem(item: Item): Observable<any> {
    return this.http.post(`https://localhost:7164/api/Bookmark/SetItem`, item);
  }

  // Send a GET request to get bookmarked items
  getBookmarkedItems(): Observable<Item[]> {
    return this.http.get<Item[]>(`https://localhost:7164/api/Bookmark/GetItems`);
  }
}
