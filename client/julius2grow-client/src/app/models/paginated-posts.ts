import { Post } from "./post";

export interface PaginatedPosts {
  pageIndex: number;
  totalPages: 1;
  posts: Post[];
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}
