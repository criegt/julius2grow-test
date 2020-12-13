import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { PaginatedPosts } from 'src/app/models/paginated-posts';
import { Post } from 'src/app/models/post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-list-posts',
  templateUrl: './list-posts.component.html',
  styleUrls: ['./list-posts.component.scss']
})
export class ListPostsComponent implements OnInit {
  paginatedPosts: PaginatedPosts;
  searchTerms: string = '';
  pageIndex: number = 0;

  constructor(private postService: PostService,
    private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.getPosts();
  }

  private async getPosts() {
    this.postService.getAll(this.pageIndex, 10, this.searchTerms)
      .then(p => {
        this.paginatedPosts = p;
        console.log(p);
        this.cdr.detectChanges();
      });
  }

  async onPostRemoved(post: Post){
    await this.getPosts();
  }

  async onPostAdded(obj: any){
    await this.getPosts();
  }

  async search(){
    await this.getPosts();
  }

  async previousPage(){
    this.pageIndex = this.paginatedPosts.pageIndex - 1;
    await this.getPosts();
  }

  async nextPage(){
    this.pageIndex = this.paginatedPosts.pageIndex + 1;
    await this.getPosts();
  }
}
