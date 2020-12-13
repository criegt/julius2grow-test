import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent implements OnInit {
  postForm: FormGroup;

  @Output()
  added: EventEmitter<any> = new EventEmitter();

  @ViewChild('imageInput')
  imageInputRef: ElementRef;
  isLoading: boolean;

  constructor(private formBuilder: FormBuilder,
              private postService: PostService) {
    this.createPostForm();
  }

  private createPostForm(){
    this.postForm = this.formBuilder.group({
      title: ['', Validators.required],
      content: ['', Validators.required],
      image: ['', Validators.required],
    });

    if (this.imageInputRef) {
      this.imageInputRef.nativeElement.value = '';
    }
  }

  ngOnInit(): void {
  }

  onSubmit(){
    this.isLoading = true;
    this.postService.add(this.postForm.value.title,
      this.postForm.value.content,
      this.postForm.value.image)
      .then(a => {
        this.createPostForm();
        this.added.emit(null);
      })
      .finally(() => this.isLoading = false);
  }

  onFileSelected(event){
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.postForm.get('image').setValue(file);
    }
  }
}
