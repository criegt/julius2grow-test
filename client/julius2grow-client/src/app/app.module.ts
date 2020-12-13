import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './features/users/sign-in/sign-in.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignUpComponent } from './features/users/sign-up/sign-up.component';
import { ListPostsComponent } from './features/posts/list-posts/list-posts.component';
import { SignOutComponent } from './features/users/sign-out/sign-out.component';
import { httpInterceptorProviders } from './shared/interceptors/interceptors';
import { AddPostComponent } from './features/posts/add-post/add-post.component';
import { PostItemComponent } from './features/posts/post-item/post-item.component';


@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    SignUpComponent,
    ListPostsComponent,
    SignOutComponent,
    AddPostComponent,
    PostItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
