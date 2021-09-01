import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IPost} from './post';
import {IComment} from './comment';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl = 'https://jsonplaceholder.typicode.com/';

  constructor(
    private readonly http: HttpClient
  ) {
  }

  getPosts(): Observable<IPost[]> {
    const url = this.baseUrl + 'posts';
    return this.http.get<IPost[]>(url);
  }

  getCommentsByPost(postId: number): Observable<IComment[]> {
    const url = this.baseUrl + 'posts/' + postId + '/comments';
    return this.http.get<IComment[]>(url);
  }
}
