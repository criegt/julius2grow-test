import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PaginatedPosts } from '../models/paginated-posts';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  async getAll(pageIndex: number, pageSize: number, searchTerms: string): Promise<PaginatedPosts> {
    let params = `pageIndex=${pageIndex}&pageSize=${pageSize}&searchTerms=${searchTerms}`;
    let response = await this.http
      .get<PaginatedPosts>(`https://localhost:5001/api/v1/Posts?${params}`)
      .toPromise();

    return response;
  }

  async add(title: string, content: string, image: any): Promise<any> {
    const formData = new FormData();
    formData.append('title', title);
    formData.append('content', content);
    formData.append('image', image);

    return await this.http
      .post('https://localhost:5001/api/v1/Posts', formData)
      .toPromise();
  }

  async remove(postId: number): Promise<any> {
    return await this.http
      .delete(`https://localhost:5001/api/v1/Posts/${postId}`)
      .toPromise();
  }
}
