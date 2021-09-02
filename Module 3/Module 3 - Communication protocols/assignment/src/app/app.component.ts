import {Component} from '@angular/core';
import {DataService} from './data.service';
import {IPost} from './post';
import {IComment} from './comment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  posts: IPost[] = [];
  comments: IComment[] = [];
  firstClicked = false;
  secondClicked = false;

  constructor(
    private readonly dataService: DataService
  ) {
  }

  setPosts(): void {
    this.dataService.getPosts().subscribe(posts => {
      this.posts = posts.filter(p => p.id % 2 === 0);
    });
    this.firstClicked = true;
    this.secondClicked = false;
  }

  setComments(): void {
    this.dataService.getPosts().subscribe(posts => {
      this.posts = posts.slice(0, 3);
      this.posts.forEach(p => {
        this.dataService.getCommentsByPost(p.id).subscribe(comments => {
          this.comments = this.comments.concat(comments);
        });
      });
    });
    this.firstClicked = false;
    this.secondClicked = true;
  }
}
