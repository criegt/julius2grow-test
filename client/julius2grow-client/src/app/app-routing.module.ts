import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListPostsComponent } from './features/posts/list-posts/list-posts.component';
import { SignInComponent } from './features/users/sign-in/sign-in.component';
import { SignOutComponent } from './features/users/sign-out/sign-out.component';
import { SignUpComponent } from './features/users/sign-up/sign-up.component';
import { AuthGuard } from './shared/guards/auth-guard';
import { UnAuthGuard } from './shared/guards/unauth-guard';

const routes: Routes = [
  { path: 'users/sign-in', component: SignInComponent, canActivate:[UnAuthGuard] },
  { path: 'users/sign-up', component: SignUpComponent, canActivate:[UnAuthGuard] },
  { path: 'users/sign-out', component: SignOutComponent, canActivate:[AuthGuard] },
  { path: 'posts', component: ListPostsComponent, canActivate: [AuthGuard] },
  { path: '', redirectTo: 'posts', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
