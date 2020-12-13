import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import * as moment from 'moment';
import { Post } from 'src/app/models/post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-post-item',
  templateUrl: './post-item.component.html',
  styleUrls: ['./post-item.component.scss']
})
export class PostItemComponent implements OnInit {

  @Input()
  post: Post;

  @Output()
  removed: EventEmitter<Post> = new EventEmitter();

  constructor(private postService: PostService) { }

  ngOnInit(): void {
  }

  onClick() {
    this.postService.remove(this.post.id)
      .then(v => this.removed.emit(this.post));
  }

  getFormattedDate(){
    return moment(this.post.createdAt).fromNow();
  }
}
