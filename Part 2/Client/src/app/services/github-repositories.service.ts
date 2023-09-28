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
  private searchUrl = environment.searchApi;
  private bookmarkUrl = environment.bookmarkApi;
  private setItem = environment.setItem;
  private getItems = environment.getItems;


  constructor(private http: HttpClient) { }

  searchAsync(searchKeyword: string): Observable<Rootobject> {
    const url = `${this.apiUrl}${this.searchUrl}${searchKeyword}`;
    return this.http.get<Rootobject>(url);
  }

  sendEmail(email: string, item: Item): Observable<any> {
    const url = `${this.apiUrl}${this.emailUrl}${email}`;
    return this.http.post<any>(url, item);
  }

  setBookmarkItem(item: Item): Observable<any> {
    const url = `${this.apiUrl}${this.bookmarkUrl}${this.setItem}`;
    return this.http.post(url, item);
  }

  getBookmarkedItems(): Observable<Item[]> {
    const url = `${this.apiUrl}${this.bookmarkUrl}${this.getItems}`;
    return this.http.get<Item[]>(url);
  }

  removeBookmarkItem(itemId: number): Observable<Item[]> {
    const url = `https://localhost:7164/api/Bookmark/RemoveItem/${itemId}`;
    return this.http.delete<Item[]>(url);
  }
}
